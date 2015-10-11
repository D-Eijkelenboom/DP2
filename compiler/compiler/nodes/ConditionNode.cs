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

            List<Token> statement = checkCondition(tokens);

            this.LValue = statement[0];
            this.condition = statement[1];
            this.RValue = statement[2];
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

        public List<Token> checkCondition(List<Token> tokens)
        {
            List<Token> returnValue = new List<Token>();
            bool isCondition = false;

            foreach (Token token in tokens)
            {
                switch (token.Type)
                {
                    case TokenType.ELIPSISOPEN:
                        isCondition = true;
                        break;
                    case TokenType.ELIPSISCLOSE:
                        return returnValue;
                }
                if (isCondition && token.Type != TokenType.ELIPSISOPEN)
                {
                    returnValue.Add(token);
                }
            }
            return returnValue;
        }

        public Token LValue { get; set; }
        public Token condition { get; set; }
        public Token RValue { get; set; }
    }
}
