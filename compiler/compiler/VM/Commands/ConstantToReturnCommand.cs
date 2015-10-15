using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace compiler
{
    class ConstantToReturnCommand : BaseCommand
    {
        public override void Execute(VirtualMachine vm, IList<string> parameters)
        {
            vm.ReturnValue = parameters[1];
        }
    }
}
