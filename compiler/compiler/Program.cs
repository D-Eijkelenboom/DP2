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
            string[] lines = File.ReadAllLines(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "//snippets//example.txt");
            Tokenizer tokenizer = new Tokenizer(lines);
            Compiler compiler = new Compiler();
            compiler.compile(tokenizer.getTokens());
            VirtualMachine vm = new VirtualMachine();
            vm.Run(compiler.Nodes);

			Console.ReadLine();
        }
    }
}
