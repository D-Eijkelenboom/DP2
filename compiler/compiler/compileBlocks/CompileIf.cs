using compiler.nodes;
using Compiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler
{
    class CompileIf
    {
         private Compiler compiler;

        public CompileIf(Compiler compiler)
        {
            this.compiler = compiler;
        }

        public void compile(List<Token> tokens)
        {
            DoNothingNode nothingStart = new DoNothingNode();
            compiler.Nodes.AddLast(nothingStart);
            LinkedListNode<Node> nothingStartNode = compiler.Nodes.Last;

            ConditionNode condition = new ConditionNode(tokens);
            compiler.Nodes.AddLast(condition);

            ConditionalJump conditionalJump = new ConditionalJump();
            compiler.Nodes.AddLast(conditionalJump);

            DoNothingNode nothingTrue = new DoNothingNode();
            compiler.Nodes.AddLast(nothingTrue);
            conditionalJump.OnTrue = compiler.Nodes.Last;

            List<List<Token>> body = compiler.compileBody(tokens);
            foreach (List<Token> bodyPart in body)
            {
                compiler.compilePart(bodyPart);
            }
            DoNothingNode nothingFalse = new DoNothingNode();
            compiler.Nodes.AddLast(nothingFalse);
            conditionalJump.OnFalse = compiler.Nodes.Last;
        }
    }
}
