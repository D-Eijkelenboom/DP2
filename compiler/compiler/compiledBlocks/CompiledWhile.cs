using compiler.nodes;
using Compiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler
{
    class CompileWhile
    {
        private Compiler compiler;

        public CompileWhile(Compiler compiler)
        {
            this.compiler = compiler;
        }

        public void compile(List<Token> tokens)
        {
            DoNothingNode nothingStart = new DoNothingNode();
            compiler.Nodes.AddLast(nothingStart);
            compiler.Nodes.Last.Previous.Value.Next = compiler.Nodes.Last.Value;
            LinkedListNode<Node> nothingStartNode = compiler.Nodes.Last;

            ConditionNode condition = new ConditionNode(tokens);
            compiler.Nodes.AddLast(condition);
            compiler.Nodes.Last.Previous.Value.Next = compiler.Nodes.Last.Value;

            ConditionalJump conditionalJump = new ConditionalJump();
            compiler.Nodes.AddLast(conditionalJump);
            compiler.Nodes.Last.Previous.Value.Next = compiler.Nodes.Last.Value;

            DoNothingNode nothingTrue = new DoNothingNode();
            compiler.Nodes.AddLast(nothingTrue);
            compiler.Nodes.Last.Previous.Value.Next = compiler.Nodes.Last.Value;
            conditionalJump.OnTrue = compiler.Nodes.Last;

            List<List<Token>> body = compiler.compileBody(tokens);
            foreach (List<Token> bodyPart in body)
            {
                compiler.compilePart(bodyPart);
            }
            compiler.Nodes.AddLast(new JumpNode(nothingStartNode));
            compiler.Nodes.Last.Previous.Value.Next = compiler.Nodes.Last.Value;

            DoNothingNode nothingFalse = new DoNothingNode();
            compiler.Nodes.AddLast(nothingFalse);
            compiler.Nodes.Last.Previous.Value.Next = compiler.Nodes.Last.Value;
            conditionalJump.OnFalse = compiler.Nodes.Last;
        }        
    }
}
