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
        }

        public void Run(LinkedList<Node> list)
        {
            CurrentNode = list.First.Value;
            NextNodeVisitor visitor = new NextNodeVisitor();

            while (CurrentNode != null)
            {
                Console.WriteLine(CurrentNode.GetType().ToString());
                // Doe iets met de huidige node: 
                switch (CurrentNode.GetType().ToString())
                { 

                    default:
                        break;
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
            return Variables[variableName];
        }

        public string ReturnValue { get; set; }

        public Dictionary<string, string> Variables { get; set; }

        public Node CurrentNode { get; set; }
    }
}
