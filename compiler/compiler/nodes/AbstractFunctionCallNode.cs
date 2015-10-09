using Compiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler
{
    class AbstractFunctionCallNode : Node
    {
        public virtual List<string> Parameters { get; set; }

       // "x = 2;"

       // DirectFunctionCallNode ["C2R", "2"]
       //DirectFunctionCallNode ["R2V", "x"]

       // "x = Add(y, z);"

       // FunctionCallNode ["Add", "y", "z"]
       // DirectFunctionCallNode ["R2V", "x"]
    }
}
