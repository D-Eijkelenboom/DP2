using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler.compileBlocks
{
    public class CompiledCondition : CompiledStatement
    {
        public CompiledCondition()
        {
            Compiled = new LinkedList<Node>();
        }

        public override CompiledStatement Clone()
        {
            return new CompiledCondition();
        }

        public override void Compile(Token currentToken)
        {
            // x == 2
            // y >= 0
            // 2 == x
            // etc
            // even kort door de bocht.

            Token leftToken = currentToken;
            string leftName = leftToken.Value;
            currentToken = currentToken.Next;
            Token operatorToken = currentToken;
            currentToken = currentToken.Next;
            Token rightToken = currentToken;
            string rightName = rightToken.Value;

            if(leftToken.Type != TokenType.IDENTIFIER)
            {
                leftName = base.GetNextUniqueId();
                Compiled.AddLast(new DirectFunctionCallNode("ConstantToReturn", leftToken.Value));
                if (Compiled.Count > 1)
                    Compiled.Last.Previous.Value.Next = Compiled.Last.Value;
                Compiled.AddLast(new DirectFunctionCallNode("ReturnToVariable", leftName));
                if (Compiled.Count > 1)
                    Compiled.Last.Previous.Value.Next = Compiled.Last.Value;
            }
            if (rightToken.Type != TokenType.IDENTIFIER)
            {
                rightName = base.GetNextUniqueId();
                Compiled.AddLast(new DirectFunctionCallNode("ConstantToReturn", rightToken.Value));
                if (Compiled.Count > 1)
                    Compiled.Last.Previous.Value.Next = Compiled.Last.Value;
                Compiled.AddLast(new DirectFunctionCallNode("ReturnToVariable", rightName));
                if (Compiled.Count > 1)
                    Compiled.Last.Previous.Value.Next = Compiled.Last.Value;
            }

            switch (operatorToken.Type)
            {
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
            
        }

        public override bool IsMatch(Token currentToken)
        {
            bool value = false;
            if(currentToken.Next.Type == TokenType.COMPARE || currentToken.Next.Type == TokenType.NOTEQUALS || currentToken.Next.Type == TokenType.GREATEREQUALS || currentToken.Next.Type == TokenType.LESSEREQUALS)
            {
                value = true;
            }

            return value;
        }

        public LinkedList<Node> Compiled { get; set; }
    }    
}
