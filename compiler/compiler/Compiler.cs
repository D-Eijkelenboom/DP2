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
        public Compiler(string path)
        {
            string[] lines = File.ReadAllLines(path);
            Tokenizer tokenizer = new Tokenizer(lines);
        }
    }
}
