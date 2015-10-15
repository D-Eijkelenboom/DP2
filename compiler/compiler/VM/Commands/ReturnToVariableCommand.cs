using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace compiler
{
    class ReturnToVariableCommand : BaseCommand
    {
        public override void Execute(VirtualMachine vm, IList<string> parameters)
        {
            vm.setVariable(parameters[1], vm.ReturnValue);
        }
    }
}
