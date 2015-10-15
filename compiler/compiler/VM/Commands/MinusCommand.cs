using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler
{
    class MinusCommand : BaseCommand
    {
        public MinusCommand() { }

        public override void Execute(VirtualMachine vm, IList<string> parameterNames)
        {
            var variable1 = vm.getVariable(parameterNames[1]);
            var variable2 = vm.getVariable(parameterNames[2]);

            int var1;
            int var2;

            if (Int32.TryParse(variable1, out var1) && Int32.TryParse(variable2, out var2))
                vm.ReturnValue = (var1 - var2)
                                  .ToString();
            else
                if(variable1.Contains(variable2))
                {
                    variable1.Replace(variable2, "");
                }
                else
                {
                    Console.WriteLine("String does not contain substring");
                }
        }
    }
}
