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
            Node currentNode = list.First.Value;
            NextNodeVisitor visitor = new NextNodeVisitor();

            while (currentNode != null)
            {
                // Doe iets met de huidige node: 
                //          Command pattern

                // Bepaal de volgende node: 
                currentNode.Accept(visitor);
                currentNode = visitor.NextNode;
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
    }
}
