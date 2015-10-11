using compiler.nodes;
using Compiler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler
{
    class Compiler
    {
        public Compiler()
        {
            Nodes = new LinkedList<Node>();
        }

        public void compile(List<Token> tokens)
        {
            List<List<Token>> parts = createParts(tokens);

            foreach(List<Token> part in parts)
            {
                compilePart(part);
            }
        }

        public void compilePart(List<Token> part)
        {
            switch (part[0].Type)
            { 
                case TokenType.IDENTIFIER:
                    
                    Token identifier = part[0];

                    if (part[1].Type == TokenType.EQUALS)
                    {
                        if (part.Count == 3)
                        {
                            Nodes.AddLast(new DirectFunctionCallNode(part));
                        }
                        else
                        {
                            Nodes.AddLast(new FunctionCallNode(part));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Compile error: \"=\"  not found at lineNR: " + part[1].LineNr + ", linePos: " + part[1].PositionNr);
                    }
                    break;
                case TokenType.WHILE:
                    CompileWhile compileWhile = new CompileWhile(this);
                    compileWhile.compile(part);
                    break;
                case TokenType.IF:
                    break;
            }
        }           
        
        public List<List<Token>> createParts(List<Token> tokens)
        {
            List<List<Token>> parts = new List<List<Token>>();

            List<Token> part = new List<Token>();

            foreach (Token token in tokens)
            {
                part.Add(token);
                if (token.Type == TokenType.BRACKETCLOSE || (token.Type == TokenType.SEMICOLON && token.Level == part[0].Level))
                {
                    parts.Add(part);
                    part = new List<Token>();
                }
            }
            return parts;
        }

        public List<List<Token>> compileBody(List<Token> part)
        {
            List<Token> bodyParts = new List<Token>();
            bool open = false;

            foreach (Token t in part)
            {
                if (t.Type == TokenType.BRACKETOPEN)
                {
                    open = true;
                }

                if (open && t.Type != TokenType.BRACKETOPEN)
                {
                    if (t.Type == TokenType.BRACKETCLOSE)
                    {
                        break;
                    }
                    bodyParts.Add(t);
                }
            }

            return createParts(bodyParts);
        }

        public LinkedList<Node> Nodes { get; set; }
    }
}
