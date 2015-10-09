using Compiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler.nodes
{
    class ConditionNode : Node
    {
        public ConditionNode(List<Token> tokens)
        {
            this.Tokens = tokens;

            this.LValue = Tokens[0];
            this.condition = Tokens[1];
            this.RValue = Tokens[2];
        }

        public bool execute()
        {
            switch (condition.Type)
            {
                case TokenType.EQUALS:
                    return LValue.Value == RValue.Value;
                case TokenType.NOTEQUALS:
                    return LValue.Value != RValue.Value;
                case TokenType.LESSEREQUALS:
                    return int.Parse(LValue.Value) <= int.Parse(RValue.Value);
                case TokenType.GREATEREQUALS:
                    return int.Parse(LValue.Value) >= int.Parse(RValue.Value);
                default:
                    throw new ArgumentException("Not supported in our compiler");
            }
        }

        public Token LValue { get; set; }
        public Token condition { get; set; }
        public Token RValue { get; set; }
    }
}
