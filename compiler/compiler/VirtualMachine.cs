using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler
{
    public class VirtualMachine
    {
        public VirtualMachine()
        {
            Variables = new Dictionary<string, string>();
            Commands = new Dictionary<string, BaseCommand>()
            {
                {"PLUS", new PlusCommand()},
                {"MINUS", new MinusCommand()},
                {"MULTIPLY", new MultiplyCommand()},
                {"DIVIDE", new DivideCommand()},
                {"INCREMENT", new IncrementCommand()},
                {"DECREMENT", new DecrementCommand()},
                {"V2R", new ValueToReturnCommand()}

            };
        }

        public void Run(LinkedList<Node> list)
        {
            CurrentNode = list.First.Value;
            NextNodeVisitor visitor = new NextNodeVisitor();
            
            while (CurrentNode != null)
            {
                var node = CurrentNode as AbstractFunctionCallNode;
                
                if(node != null && Commands.ContainsKey(node.Parameters[0]))
                {
                    Commands[node.Parameters[0]].Execute(this, node.Parameters);
                }

                // Bepaal de volgende node: 
                CurrentNode.Accept(visitor);
                CurrentNode = visitor.NextNode;
            }
        }

        public void setVariable(string variableName, string returnValue)
        {
            if (Variables.ContainsKey(variableName))
            {
                Variables[variableName] = returnValue;
            }
            else
            {
                Variables.Add(variableName, returnValue);
            }
        }

        public string getVariable(string variableName)
        {
            if(Variables.ContainsKey(variableName))
            {
                return Variables[variableName];
            }
            else
            {
                return variableName;
            }            
        }

        public string ReturnValue { get; set; }

        public Dictionary<string, string> Variables { get; set; }

        public Node CurrentNode { get; set; }

        public Dictionary<string, BaseCommand> Commands { get; set; }
    }
}
