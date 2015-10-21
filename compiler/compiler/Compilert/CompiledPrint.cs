using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace compiler.Compilert
{
    class CompiledPrint
    {
        private Compiler compiler;

        public CompiledPrint(Compiler compiler)
        {
            this.compiler = compiler;
            Compiled = new LinkedList<Node>();
        }

        public void compile(Token currentToken)
        {
            currentToken = currentToken.Next.Next;

            if (currentToken.Type == TokenType.IDENTIFIER)
            {
                Compiled.AddLast(new DirectFunctionCallNode("Print", currentToken.Value));

                if (Compiled.Count > 1)
                    Compiled.Last.Previous.Value.Next = Compiled.Last.Value;
            }
            else
            {
                Console.WriteLine("Compile error: print function contains invalid parameters");
            }
        }

        public LinkedList<Node> Compiled { get; set; }
    }
}
