using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler.Compilert.compiledBlocks
{
    public class CompiledAssignment : CompiledStatement
    {
        public override CompiledStatement Clone()
        {
            return new CompiledAssignment();
        }

        public override void Compile(ref LinkedListNode<Token> currentToken)
        {
            Compiled.Add(new DirectFunctionCallNode("ReturnToVariable", currentToken.Value.Value));
        }

        public override bool IsMatch(LinkedListNode<Token> currentToken)
        {
            bool value = false;
            if (currentToken.Next.Value.Type == TokenType.EQUALS)
            {
                value = true;
            }

            return value;
        }

        public List<Node> Compiled { get; set; }
    }
}
