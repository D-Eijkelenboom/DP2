﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler
{
    class DoNothingNode : Node
    {
        public override Node Execute()
        {

            return this;
        }
    }
}
