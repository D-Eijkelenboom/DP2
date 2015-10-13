using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler
{
    public abstract class BaseCommand
    {

        public BaseCommand(Compiler compiler)
        {
            Compiler = compiler;
        }        

        public abstract void Execute(VirtualMachine vm, IList<string> parameters);

        public Compiler Compiler { get; set; }

    }
}
