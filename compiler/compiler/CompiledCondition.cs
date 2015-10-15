using CSharpCompiler.Compiler.Nodes;
using CSharpCompiler.Tokenizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompiler.Compiler
{
    public class CompiledCondition : CompiledStatement
    {
        public override CompiledStatement Clone()
        {
            return new CompiledCondition();
        }

        public override void Compile(ref LinkedListNode<Tokenizer.Token> currentToken)
        {
            // x == 2
            // y >= 0
            // 2 == x
            // etc
            // even kort door de bocht.

            Token leftToken = currentToken.Value;
            string leftName = leftToken.TokenValue;
            currentToken = currentToken.Next;
            Token operatorToken = currentToken.Value;
            currentToken = currentToken.Next;
            Token rightToken = currentToken.Value;
            string rightName = rightToken.TokenValue;

            if(leftToken.TokenType != Tokenizer.TokenType.IDENTIFIER)
            {
                leftName = base.GetNextUniqueId();
                Compiled.Add(new DirectFunctionCallNode("ConstantToReturn", leftToken.TokenValue));
                Compiled.Add(new DirectFunctionCallNode("ReturnToVariable", leftName));
            }
            // ... hetzelfde voor rightname

            switch (operatorToken.TokenType)
            {
                case TokenType.DOUBLE_EQUALS: Compiled.Add(new FunctionCallNode("AreEqual", leftName, rightName));
                // etc.
                default:
                    break;
            }
            Compiled.Add(new DirectFunctionCallNode("ReturnToVariable", "x"));
        }

        public override bool IsMatch(LinkedListNode<Tokenizer.Token> currentToken)
        {
            return currentToken.Next.Value.TokenType == Tokenizer.TokenType.DOUBLE_EQUALS /*|| etc */;
        }
    }    
}
