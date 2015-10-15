using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace compiler
{
    class ConstantToVariableCommand : BaseCommand
    {
        public override void Execute(VirtualMachine vm, IList<string> parameters)
        {
            vm.setVariable(parameters[1], parameters[2]);
        }
    }
}
