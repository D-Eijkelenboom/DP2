
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
            Identifier = tokens[0].Value;

            string operation = tokens[1].Value;

            switch (operation)
            { 
                case "+":
                    Parameters.Add("PLUS");                    
                    break;
                case "-":
                    Parameters.Add("MINUS");
                    break;
                case "*":
                    Parameters.Add("MULTIPLY");
                    break;
                case "/":
                    Parameters.Add("DIVIDE");
                    break;
                case "++":
                    Parameters.Add("INCREMENT");
                    break;
                case "--":
                    Parameters.Add("DECREMENT");
                    break;
                default:
                    break;
            }
            Parameters.Add(tokens[0].Value);
            Parameters.Add(tokens[2].Value);
        }
        
        public override void Accept(NodeVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override List<string> Parameters { get; set; }
        public int ReturnValue { get; set; }
    }    
}
