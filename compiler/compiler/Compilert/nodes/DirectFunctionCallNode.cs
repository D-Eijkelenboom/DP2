using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler
{
    public class DirectFunctionCallNode : AbstractFunctionCallNode
    {
        public DirectFunctionCallNode(string variableName, string param)
        {
            Parameters = new List<string>();

            Parameters.Add(variableName);
            Parameters.Add(param);
        }

        public override void Accept(NodeVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override List<string> Parameters  { get; set; }
    }
}
