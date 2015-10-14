using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler
{
    public class NextNodeVisitor : NodeVisitor
    {     

        public override void Visit(DoNothingNode node) 
        {
             NextNode = node.Next;
        }

        public override void Visit(JumpNode node) 
        {
             NextNode = node.JumpToNode.Value;
        }

        public override void Visit(ConditionalJump node) 
        { 
            
        }
 
        public override void Visit(DirectFunctionCallNode node) 
        {
            NextNode = node.Next;
        }
        public override void Visit(FunctionCallNode node)
        {
            NextNode = node.Next;
        }

        public override void Visit(nodes.ConditionNode node)
        {
            NextNode = node.Next;
        }
 
        public Node NextNode { get; private set; }
        
    }
}
