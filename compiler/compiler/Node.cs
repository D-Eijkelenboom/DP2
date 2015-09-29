using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler
{
    class Node
    {
        public Node(Node next)
        {
            Next = next;
        }
        public Node Next { get; set; }
        public virtual Node Execute()
        {
            return null;
        }
    }
}
