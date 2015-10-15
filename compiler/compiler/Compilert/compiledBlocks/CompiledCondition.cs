using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler.compileBlocks
{
    public class CompiledCondition : CompiledStatement
    {
        public override CompiledStatement Clone()
        {
            return new CompiledCondition();
        }

        public override void Compile(ref LinkedListNode<Token> currentToken)
        {
            // x == 2
            // y >= 0
            // 2 == x
            // etc
            // even kort door de bocht.

            Token leftToken = currentToken.Value;
            string leftName = leftToken.Value;
            currentToken = currentToken.Next;
            Token operatorToken = currentToken.Value;
            currentToken = currentToken.Next;
            Token rightToken = currentToken.Value;
            string rightName = rightToken.Value;

            if(leftToken.Type != TokenType.IDENTIFIER)
            {
                leftName = base.GetNextUniqueId();
                Compiled.Add(new DirectFunctionCallNode("ConstantToReturn", leftToken.Value));
                Compiled.Add(new DirectFunctionCallNode("ReturnToVariable", leftName));
            }
            if (rightToken.Type != TokenType.IDENTIFIER)
            {
                rightName = base.GetNextUniqueId();
                Compiled.Add(new DirectFunctionCallNode("ConstantToReturn", rightToken.Value));
                Compiled.Add(new DirectFunctionCallNode("ReturnToVariable", rightName));
            }

            switch (operatorToken.Type)
            {
                case TokenType.COMPARE:
                    Compiled.Add(new FunctionCallNode("AreEqual", new List<string>() {leftName, rightName}));
                    break;
                case TokenType.NOTEQUALS:
                    Compiled.Add(new FunctionCallNode("NotEqual", new List<string>() { leftName, rightName }));
                    break;
                case TokenType.LESSEREQUALS:
                    Compiled.Add(new FunctionCallNode("LesserEqual", new List<string>() { leftName, rightName }));
                    break;
                case TokenType.GREATEREQUALS:
                    Compiled.Add(new FunctionCallNode("GreaterEqual", new List<string>() { leftName, rightName }));
                    break;
                default:
                    break;
            }
            
        }

        public override bool IsMatch(LinkedListNode<Token> currentToken)
        {
            bool value = false;
            if(currentToken.Next.Value.Type == TokenType.COMPARE || currentToken.Next.Value.Type == TokenType.NOTEQUALS || currentToken.Next.Value.Type == TokenType.GREATEREQUALS || currentToken.Next.Value.Type == TokenType.LESSEREQUALS)
            {
                value = true;
            }

            return value;
        }

        public List<Node> Compiled { get; set; }
    }    
}
