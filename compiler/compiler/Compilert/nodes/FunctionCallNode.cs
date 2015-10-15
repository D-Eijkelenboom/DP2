using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler
{
    public class FunctionCallNode : AbstractFunctionCallNode
    {
        public FunctionCallNode(string variableName, List<string> parameters)
        {
            Parameters = new List<string>();

            Parameters.Add(variableName);
            Parameters.AddRange(parameters);
        }
        
        public override void Accept(NodeVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override List<string> Parameters { get; set; }
        public int ReturnValue { get; set; }
    }    
}
