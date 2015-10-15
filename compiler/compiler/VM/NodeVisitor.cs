using compiler.nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler
{
    public abstract class NodeVisitor
    {
        public abstract void Visit(JumpNode node);
        public abstract void Visit(FunctionCallNode node);
        public abstract void Visit(DirectFunctionCallNode node);
        public abstract void Visit(DoNothingNode node);
        public abstract void Visit(ConditionalJump node);
        public abstract void Visit(ConditionNode node);

    }
}
