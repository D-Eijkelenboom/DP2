using Compiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler
{
    class JumpNode : Node
    {
        public JumpNode(LinkedListNode<Node> jumpToNode)
        {
            JumpToNode = jumpToNode;
        }

        public LinkedListNode<Node> jump()
        {
            return JumpToNode;
        }

        public LinkedListNode<Node> JumpToNode { get; set; }
    }
}
