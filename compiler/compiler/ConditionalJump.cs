using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace compiler
{
    class ConditionalJump : Node
    {
        public Node Next2 { get; set; }

        public override Node Execute()
        {
            //if() // <- hier moet iets???
            //{
            //    Next.Execute();
            //}
            //else 
            //{
            //    Next2.Execute();
            //}            
            return this;
        }
    }
}
