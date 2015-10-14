using Compiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace compiler
{
    public class ConditionalJump : Node
    {
        public ConditionalJump()
        { }

        public override void Accept(NodeVisitor visitor)
        {
            visitor.Visit(this);
        }

        public LinkedListNode<Node> OnTrue { get; set; }

        public LinkedListNode<Node> OnFalse { get; set; }

        public bool Result { get; set; }
    }
}
