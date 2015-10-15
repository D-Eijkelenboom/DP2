using compiler.compileBlocks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler
{
    public class Compiler
    {
        public Compiler()
        {
            Nodes = new LinkedList<Node>();
            Nodes.AddLast(new DoNothingNode());
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
                        if (part[part.Count - 1].Type != TokenType.SEMICOLON)
                        {
                            Console.WriteLine("Compile error: \";\" not found at: " + part[part.Count - 1].LineNr + ", linePos: " + part[part.Count - 1].PositionNr);
                        }

                        if (part.Count <= 3)
                        {
                            Console.WriteLine("Compile error: Incorrect assignment at lineNR: " + part[1].LineNr + ", linePos: " + part[1].PositionNr);
                        }
                        else if (part.Count == 4)
                        {
                            Nodes.AddLast(new FunctionCallNode("ConstantToVariable", new List<string>() {part[0].Value, part[2].Value}));
                            Nodes.Last.Previous.Value.Next = Nodes.Last.Value;
                            Nodes.Last.Value.Prev = Nodes.Last.Previous.Value;
                        }
                        else
                        {
                            Nodes.AddLast(new FunctionCallNode(part));
                            Nodes.Last.Previous.Value.Next = Nodes.Last.Value;
                            Nodes.Last.Value.Prev = Nodes.Last.Previous.Value;
                        }
                    }
                    break;
                case TokenType.WHILE:
                    CompileWhile compileWhile = new CompileWhile(this);
                    compileWhile.compile(part);
                    break;
                case TokenType.IF:
                    CompileIf compileIf = new CompileIf(this);
                    compileIf.compile(part);
                    break;
                case TokenType.ELSE:
                    CompileElse compileElse = new CompileElse(this);
                    compileElse.compile(part);
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
