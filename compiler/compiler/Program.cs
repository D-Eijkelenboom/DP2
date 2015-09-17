using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace compiler
{
    class Program
    {
        static void Main(string[] args)
        {
            Compiler compiler = new Compiler(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "//snippets//example.txt");
        }
    }
}
