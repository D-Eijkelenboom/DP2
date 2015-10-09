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
        private LinkedList<Node> list;

        public Compiler(List<Token> tokens)
        {
            list = new LinkedList<Node>();  
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
                    createFunctionNode(part);
                    break;
                case TokenType.WHILE:
                    break;
                case TokenType.IF:
                    break;
            }
        }

        public void createFunctionNode(List<Token> part)
        {
            part.RemoveAt(part.Count - 1);
            nodes.AddLast(new DirectFunctionCallNode(part));
        }
        public List<Token> createCondition(List<Token> part)
        {
            List<Token> returnValue = new List<Token>();
            bool condition = false;

            foreach (Token t in part)
            {
                switch (t.Type)
                {
                    case TokenType.ELIPSISOPEN:
                        condition = true;
                        break;
                    case TokenType.ELIPSISCLOSE:
                        return returnValue;
                }
                if (condition && t.Type != TokenType.ELIPSISOPEN)
                {
                    returnValue.Add(t);
                }
            }
            return returnValue;
        }

        public void createWhile(List<Token> part)
        {
            DoNothingNode nothingStart = new DoNothingNode();
            nodes.AddLast(nothingStart);
            LinkedListNode<Node> nothingStartNode = nodes.Last;

            ConditionNode condition = new ConditionNode(createCondition(part));
            nodes.AddLast(condition);

            ConditionalJump condJump = new ConditionalJump();
            nodes.AddLast(condJump);

            DoNothingNode nothingTrue = new DoNothingNode();
            nodes.AddLast(nothingTrue);
            condJump.OnTrue = nodes.Last;

            List<List<Token>> body = processBody(part);
            foreach (List<Token> bodyPart in body)
            {
                compilePart(bodyPart);
            }
            nodes.AddLast(new JumpNode(nothingStartNode));

            DoNothingNode nothingFalse = new DoNothingNode();
            nodes.AddLast(nothingFalse);
            condJump.OnFalse = nodes.Last;

        }

        public List<List<Token>> processBody(List<Token> part)
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

        public LinkedList<Node> nodes { get; set; }
    }
}
