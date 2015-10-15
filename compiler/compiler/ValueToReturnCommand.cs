using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace compiler
{
    class ValueToReturnCommand : BaseCommand
    {
        public override void Execute(VirtualMachine vm, IList<string> parameters)
        {
            vm.setVariable(parameters[0], parameters[1]);
        }
    }
}
