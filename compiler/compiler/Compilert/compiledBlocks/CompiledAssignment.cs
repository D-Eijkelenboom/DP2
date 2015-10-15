using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler.Compilert.compiledBlocks
{
    public class CompiledAssignment : CompiledStatement
    {
        public CompiledAssignment()
        {
            Compiled = new LinkedList<Node>();
        }

        public override CompiledStatement Clone()
        {
            return new CompiledAssignment();
        }

        public override void Compile(Token currentToken)
        {
            Token constantToken = currentToken;
            string constantValue = constantToken.Value;
            currentToken = currentToken.Next.Next;

            while (currentToken.Type != TokenType.SEMICOLON)
            {
                Token leftToken = currentToken;
                string leftName = leftToken.Value;
                currentToken = currentToken.Next;
                Token operatorToken = currentToken;
                currentToken = currentToken.Next;
                Token rightToken = currentToken;
                string rightName = rightToken.Value;

                if (leftToken.Type != TokenType.IDENTIFIER && leftToken.Type != TokenType.SEMICOLON)
                {
                    leftName = base.GetNextUniqueId();
                    Compiled.AddLast(new DirectFunctionCallNode("ConstantToReturn", leftToken.Value));
                    if (Compiled.Count > 1)
                        Compiled.Last.Previous.Value.Next = Compiled.Last.Value;

                    Compiled.AddLast(new DirectFunctionCallNode("ReturnToVariable", leftName));
                    if (Compiled.Count > 1)
                        Compiled.Last.Previous.Value.Next = Compiled.Last.Value;
                }
                if (rightToken.Type != TokenType.IDENTIFIER && rightToken.Type != TokenType.SEMICOLON)
                {
                    rightName = base.GetNextUniqueId();
                    Compiled.AddLast(new DirectFunctionCallNode("ConstantToReturn", rightToken.Value));
                    if(Compiled.Count > 1)
                        Compiled.Last.Previous.Value.Next = Compiled.Last.Value;
                    Compiled.AddLast(new DirectFunctionCallNode("ReturnToVariable", rightName));
                    if (Compiled.Count > 1)
                        Compiled.Last.Previous.Value.Next = Compiled.Last.Value;
                }

                switch (operatorToken.Type)
                {
                    case TokenType.PLUS:
                        Compiled.AddLast(new FunctionCallNode("PLUS", new List<string>() { leftName, rightName }));
                        if (Compiled.Count > 1)
                            Compiled.Last.Previous.Value.Next = Compiled.Last.Value;
                        break;
                    case TokenType.MINUS:
                        Compiled.AddLast(new FunctionCallNode("MINUS", new List<string>() { leftName, rightName }));
                        if (Compiled.Count > 1)
                            Compiled.Last.Previous.Value.Next = Compiled.Last.Value;
                        break;
                    case TokenType.MULTIPLY:
                        Compiled.AddLast(new FunctionCallNode("MULTIPLY", new List<string>() { leftName, rightName }));
                        if (Compiled.Count > 1)
                            Compiled.Last.Previous.Value.Next = Compiled.Last.Value;
                        break;
                    case TokenType.DIVIDE:
                        Compiled.AddLast(new FunctionCallNode("DIVIDE", new List<string>() { leftName, rightName }));
                        if (Compiled.Count > 1)
                            Compiled.Last.Previous.Value.Next = Compiled.Last.Value;
                        break;
                    case TokenType.INCREMENT:
                        Compiled.AddLast(new FunctionCallNode("INCREMENT", new List<string>() { leftName, rightName }));
                        if (Compiled.Count > 1)
                            Compiled.Last.Previous.Value.Next = Compiled.Last.Value;
                        break;
                    case TokenType.DECREMENT:
                        Compiled.AddLast(new FunctionCallNode("DECREMENT", new List<string>() { leftName, rightName }));
                        if (Compiled.Count > 1)
                            Compiled.Last.Previous.Value.Next = Compiled.Last.Value;
                        break;
                    case TokenType.COMPARE:
                        Compiled.AddLast(new FunctionCallNode("AreEqual", new List<string>() { leftName, rightName }));
                        if (Compiled.Count > 1)
                            Compiled.Last.Previous.Value.Next = Compiled.Last.Value;
                        break;
                    case TokenType.NOTEQUALS:
                        Compiled.AddLast(new FunctionCallNode("NotEqual", new List<string>() { leftName, rightName }));
                        if (Compiled.Count > 1)
                            Compiled.Last.Previous.Value.Next = Compiled.Last.Value;
                        break;
                    case TokenType.LESSEREQUALS:
                        Compiled.AddLast(new FunctionCallNode("LesserEqual", new List<string>() { leftName, rightName }));
                        if (Compiled.Count > 1)
                            Compiled.Last.Previous.Value.Next = Compiled.Last.Value;
                        break;
                    case TokenType.GREATEREQUALS:
                        Compiled.AddLast(new FunctionCallNode("GreaterEqual", new List<string>() { leftName, rightName }));
                        if (Compiled.Count > 1)
                            Compiled.Last.Previous.Value.Next = Compiled.Last.Value;
                        break;
                    default:
                        break;
                }
                currentToken = currentToken.Next;
            }
            
            Compiled.AddLast(new DirectFunctionCallNode("ReturnToVariable", constantToken.Value));
            if (Compiled.Count > 1)
                Compiled.Last.Previous.Value.Next = Compiled.Last.Value;
        }

        public override bool IsMatch(Token currentToken)
        {
            bool value = false;
            if (currentToken.Next.Type == TokenType.EQUALS)
            {
                value = true;
            }

            return value;
        }

        public LinkedList<Node> Compiled { get; set; }
    }
}
