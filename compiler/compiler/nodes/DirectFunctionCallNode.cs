using Compiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler
{
    class DirectFunctionCallNode : AbstractFunctionCallNode
    {
        public DirectFunctionCallNode(List<Token> tokens)
        {
            Identifier = tokens[0].Value;
            ReturnValue = tokens[2].Value;
        }

        public string Identifier;

        public string ReturnValue { get; set; }
    }
}
