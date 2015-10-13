using Compiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler
{
    public abstract class AbstractFunctionCallNode : Node
    {
        public abstract List<string> Parameters { get; set; }
    }
}
