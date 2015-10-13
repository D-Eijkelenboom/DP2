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
            Identifier = tokens[0];
            ReturnValue = tokens[2];
        }

        public override void Accept(NodeVisitor visitor)
        {
            visitor.Visit(this);
        }

        public Token Identifier;

        public Token ReturnValue { get; set; }

        public override List<string> Parameters  { get; set; }
    }
}
