
using Compiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler
{
    class FunctionCallNode : AbstractFunctionCallNode
    {
        public FunctionCallNode(List<Token> tokens)
        {
            Parameters = new List<Token>();
            Identifier = tokens[0];

            int max = tokens.Count;
            if (tokens[tokens.Count - 1].Type == TokenType.SEMICOLON)
            {
                max = tokens.Count - 1;
            }

            for (int i = 2; i < max; i++)
            {
                this.Parameters.Add(tokens[i]);
            }
        }

        public void execute()
        {
            if (this.Parameters.Count == 1)
            {
                ReturnValue = Int32.Parse(Parameters[0].Value.ToString());
            }
            else
            {
                switch (Parameters[1].Type)
                {
                    case TokenType.PLUS:
                        ReturnValue = Int32.Parse(Parameters[0].Value.ToString()) + Int32.Parse(Parameters[2].Value.ToString());
                        break;
                    case TokenType.MINUS:
                        ReturnValue = Int32.Parse(Parameters[0].Value.ToString()) - Int32.Parse(Parameters[2].Value.ToString());
                        break;
                    case TokenType.MULTIPLY:
                        ReturnValue = Int32.Parse(Parameters[0].Value.ToString()) * Int32.Parse(Parameters[2].Value.ToString());
                        break;
                    case TokenType.DIVIDE:
                        ReturnValue = Int32.Parse(Parameters[0].Value.ToString()) / Int32.Parse(Parameters[2].Value.ToString());
                        break;
                }
            }
        }

        public Token Identifier;
        public List<Token> Parameters { get; set; }
        public int ReturnValue { get; set; }
    }    
}
