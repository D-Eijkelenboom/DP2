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
                    createFunctionNode(part);
                    break;
                case TokenType.WHILE:
					createWhile(part);
                    break;
                case TokenType.IF:
					createIf(part);
                    break;
            }
        }

        public void createFunctionNode(List<Token> part)
        {
            part.RemoveAt(part.Count - 1);
            Nodes.AddLast(new DirectFunctionCallNode(part));
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
            Nodes.AddLast(nothingStart);
            LinkedListNode<Node> nothingStartNode = Nodes.Last;

            ConditionNode condition = new ConditionNode(createCondition(part));
            Nodes.AddLast(condition);

            ConditionalJump condJump = new ConditionalJump();
            Nodes.AddLast(condJump);

            DoNothingNode nothingTrue = new DoNothingNode();
            Nodes.AddLast(nothingTrue);
            condJump.OnTrue = Nodes.Last;

            List<List<Token>> body = processBody(part);
            foreach (List<Token> bodyPart in body)
            {
                compilePart(bodyPart);
            }
            Nodes.AddLast(new JumpNode(nothingStartNode));

            DoNothingNode nothingFalse = new DoNothingNode();
            Nodes.AddLast(nothingFalse);
            condJump.OnFalse = Nodes.Last;
        }

		public void createIf(List<Token> part)
		{
			DoNothingNode nothingStart = new DoNothingNode();
			Nodes.AddLast(nothingStart);
			LinkedListNode<Node> nothingStartNode = Nodes.Last;

			ConditionNode condition = new ConditionNode(createCondition(part));
			Nodes.AddLast(condition);

			ConditionalJump condJump = new ConditionalJump();
			Nodes.AddLast(condJump);

			DoNothingNode nothingTrue = new DoNothingNode();
			Nodes.AddLast(nothingTrue);
			condJump.OnTrue = Nodes.Last;

			List<List<Token>> body = processBody(part);
			foreach (List<Token> bodyPart in body)
			{
				compilePart(bodyPart);
			}
			Nodes.AddLast(new JumpNode(nothingStartNode));

			DoNothingNode nothingFalse = new DoNothingNode();
			Nodes.AddLast(nothingFalse);
			condJump.OnFalse = Nodes.Last;
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

        public LinkedList<Node> Nodes { get; set; }
    }
}
