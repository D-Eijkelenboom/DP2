using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace compiler.VM
{
    class GreaterEqualCommand : BaseCommand
    {
        public override void Execute(VirtualMachine vm, IList<string> parameters)
        {
            int var1;
            int var2;

            if (Int32.TryParse(vm.getVariable(parameters[1]), out var1) && Int32.TryParse(vm.getVariable(parameters[2]), out var2))
                vm.ReturnValue = Convert.ToString(var1 >= var2);
            else
                Console.WriteLine("Compile error: Cannot compare strings to be greater or equal");
        }
    }
}
