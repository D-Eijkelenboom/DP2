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

        public virtual void Compile(ref LinkedListNode<Token> currentToken)
        { 
        
        }

        public virtual bool IsMatch(LinkedListNode<Token> currentToken)
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
