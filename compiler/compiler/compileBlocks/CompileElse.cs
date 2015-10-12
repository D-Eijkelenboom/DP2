using Compiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler.compileBlocks
{
    class CompileElse
    {
        private Compiler compiler;

        public CompileElse(Compiler compiler)
        {
            this.compiler = compiler;
        }

        public void compile(List<Token> tokens)
        {
            DoNothingNode nothingStart = new DoNothingNode();
            compiler.Nodes.AddLast(nothingStart);
            
            List<List<Token>> body = compiler.compileBody(tokens);
            foreach (List<Token> bodyPart in body)
            {
                compiler.compilePart(bodyPart);
            }
        }
    }
}
