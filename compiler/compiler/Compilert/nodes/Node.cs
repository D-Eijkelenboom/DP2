﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler
{
    public abstract class Node
    {        
        public Node Next { get; set; }

        public Node Prev { get; set; }

        public abstract void Accept(NodeVisitor visitor);
    }
}