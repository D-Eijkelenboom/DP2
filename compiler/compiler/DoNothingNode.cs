using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler
{
    class DoNothingNode : Node
    {
        public DoNothingNode(Node next)
            : base(next)
        { 
        
        }

        public override Node Execute()
        {
            Next.Execute();
            return this;
        }
    }
}
