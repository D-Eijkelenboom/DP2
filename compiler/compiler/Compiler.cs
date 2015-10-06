using Compiler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler
{
    class Compiler
    {
        private LinkedList<Node> list;

        public Compiler(List<Token> tokens)
        {
            list = new LinkedList<Node>();  
        }

        public void compile(List<Token> tokens)
        {
            list.AddFirst(new DoNothingNode());
            list.AddLast(new DoNothingNode(null));
        }

        public Token getLastToken()
        {
            return null;
        }
    }
}
