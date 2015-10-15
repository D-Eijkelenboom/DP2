using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler
{
    class MultiplyCommand : BaseCommand
    {
        public MultiplyCommand() { }

        public override void Execute(VirtualMachine vm, IList<string> parameterNames)
        {
            var variable1 = vm.getVariable(parameterNames[1]);
            var variable2 = vm.getVariable(parameterNames[2]);

            int var1;
            int var2;

            if (Int32.TryParse(variable1, out var1) && Int32.TryParse(variable2, out var2))
                vm.ReturnValue = (var1 * var2)
                                  .ToString();
            else
                Console.WriteLine("Specified operation could not be completed, given variable not a integer");
        }
    }
}
