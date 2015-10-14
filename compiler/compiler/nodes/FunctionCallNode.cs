
using Compiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler
{
    public class FunctionCallNode : AbstractFunctionCallNode
    {
        public FunctionCallNode(List<Token> tokens)
        {
            Parameters = new List<string>();

            int max = tokens.Count;
            if (tokens[tokens.Count - 1].Type == TokenType.SEMICOLON)
            {
                max = tokens.Count - 1;
            }

            for (int i = 0; i < max; i++)
            {
                this.Parameters.Add(tokens[i].Value);
            }
        }
        
        public override void Accept(NodeVisitor visitor)
        {
            visitor.Visit(this);
        }

        public Token Identifier;
        public override List<string> Parameters { get; set; }
        public int ReturnValue { get; set; }
    }    
}
