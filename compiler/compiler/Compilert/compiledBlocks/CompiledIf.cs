using compiler.compileBlocks;
using compiler.nodes;
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
            compiler.Nodes.Last.Previous.Value.Next = compiler.Nodes.Last.Value;
            compiler.Nodes.Last.Value.Prev = compiler.Nodes.Last.Previous.Value;
            LinkedListNode<Node> nothingStartNode = compiler.Nodes.Last;

            CompiledCondition condition = new CompiledCondition();
            condition.Compile(tokens[2]);
            while (condition.Compiled.Count > 0)
            {
                LinkedListNode<Node> node = condition.Compiled.First;
                condition.Compiled.RemoveFirst();
                compiler.Nodes.AddLast(node);
                compiler.Nodes.Last.Previous.Value.Next = compiler.Nodes.Last.Value;
                compiler.Nodes.Last.Value.Prev = compiler.Nodes.Last.Previous.Value;
            }

            ConditionalJump conditionalJump = new ConditionalJump();
            compiler.Nodes.AddLast(conditionalJump);
            compiler.Nodes.Last.Previous.Value.Next = compiler.Nodes.Last.Value;
            compiler.Nodes.Last.Value.Prev = compiler.Nodes.Last.Previous.Value;

            DoNothingNode nothingTrue = new DoNothingNode();
            compiler.Nodes.AddLast(nothingTrue);
            compiler.Nodes.Last.Previous.Value.Next = compiler.Nodes.Last.Value;
            compiler.Nodes.Last.Value.Prev = compiler.Nodes.Last.Previous.Value;
            conditionalJump.OnTrue = compiler.Nodes.Last;

            List<List<Token>> body = compiler.compileBody(tokens);
            foreach (List<Token> bodyPart in body)
            {
                compiler.compilePart(bodyPart);
            }
            DoNothingNode nothingFalse = new DoNothingNode();
            compiler.Nodes.AddLast(nothingFalse);
            compiler.Nodes.Last.Previous.Value.Next = compiler.Nodes.Last.Value;
            compiler.Nodes.Last.Value.Prev = compiler.Nodes.Last.Previous.Value;
            conditionalJump.OnFalse = compiler.Nodes.Last;
        }
    }
}
