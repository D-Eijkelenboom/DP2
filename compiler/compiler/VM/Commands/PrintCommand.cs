using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler.VM.Commands
{
    class PrintCommand : BaseCommand
    {
        public override void Execute(VirtualMachine vm, IList<string> parameters)
        {
            Console.WriteLine(vm.getVariable(parameters[1]));
        }
    }
}
