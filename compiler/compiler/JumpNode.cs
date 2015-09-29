using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler
{
    class JumpNode : Node
    {
        public Node JumpToNode { get; set; }
        //public override Node Execute()
        //{
        //    Next.Execute();
        //    return this;
        //}
    }
}
