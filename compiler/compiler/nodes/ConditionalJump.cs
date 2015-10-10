using Compiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace compiler
{
    class ConditionalJump : Node
    {
        private bool conditionResult;

        public ConditionalJump()
        { }

        public LinkedListNode<Node> OnTrue { get; set; }

        public LinkedListNode<Node> OnFalse { get; set; }

        public Node NextOnFalse { get; set; }

    }
}
