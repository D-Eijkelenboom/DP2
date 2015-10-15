using Compiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler
{
    public class DirectFunctionCallNode : AbstractFunctionCallNode
    {
        public DirectFunctionCallNode(List<Token> tokens)
        {
            Identifier = tokens[0].Value;
            Parameters = new List<string>() { "V2R", tokens[0].Value, tokens[2].Value};
        }

        public override void Accept(NodeVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override List<string> Parameters  { get; set; }
    }
}
