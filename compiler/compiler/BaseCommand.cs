using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler
{
    public abstract class BaseCommand
    {

        public BaseCommand()
        {
        }        

        public abstract void Execute(VirtualMachine vm, IList<string> parameters);
    }
}
