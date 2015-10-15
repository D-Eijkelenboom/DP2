using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler
{
    public class CompiledStatement
    {
        private static int lastUniqueID;

        public CompiledStatement()
        { 
        }

        public virtual CompiledStatement Clone()
        {
            return new CompiledStatement();
        }

        public virtual void Compile(Token currentToken)
        { 
        
        }

        public virtual void Compile(List<Token> tokens)
        {

        }

        public virtual bool IsMatch(Token currentToken)
        {
            return false;
        }


        public string GetNextUniqueId()
        {
            if (lastUniqueID == null)
            {
                lastUniqueID = 0;
            }
            else
            {
                lastUniqueID++;
            }
            return "$" + lastUniqueID;
        }
    }
}
