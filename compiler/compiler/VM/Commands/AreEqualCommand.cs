﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace compiler
{
    class AreEqualCommand : BaseCommand
    {
        public override void Execute(VirtualMachine vm, IList<string> parameters)
        {
            vm.ReturnValue = Convert.ToString(vm.getVariable(parameters[1]) == vm.getVariable(parameters[2]));
        }
    }
}
