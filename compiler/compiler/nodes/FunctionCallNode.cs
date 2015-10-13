
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
            Identifier = tokens[0];

            int max = tokens.Count;
            if (tokens[tokens.Count - 1].Type == TokenType.SEMICOLON)
            {
                max = tokens.Count - 1;
            }

            for (int i = 2; i < max; i++)
            {
                this.Parameters.Add(tokens[i].Value);
            }
        }

        public void execute()
        {
            if (this.Parameters.Count == 1)
            {
                ReturnValue = Int32.Parse(Parameters[0]);
            }
            else
            {
                switch (Parameters[1])
                {
                    case "+":
                        ReturnValue = Int32.Parse(Parameters[0]) + Int32.Parse(Parameters[2]);
                        break;
                    case "-":
                        ReturnValue = Int32.Parse(Parameters[0]) - Int32.Parse(Parameters[2]);
                        break;
                    case "*":
                        ReturnValue = Int32.Parse(Parameters[0]) * Int32.Parse(Parameters[2]);
                        break;
                    case "/":
                        ReturnValue = Int32.Parse(Parameters[0]) / Int32.Parse(Parameters[2]);
                        break;
                }
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
