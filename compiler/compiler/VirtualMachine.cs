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
                    case "compiler.JumpNode":
                        break;
                    case "compiler.FunctionCallNode":
                        FunctionCallNode node = CurrentNode as FunctionCallNode;
                        setVariable(node.Identifier.Value, string.Empty);
                        sortParameters(node.Parameters);
                   
                        break;
                    case "compiler.DirectFunctionCallNode":
                        break;
                    case "compiler.ConditionNode":
                        break;
                    case "compiler.DoNothingNode":
                        break;
                    case "compiler.ConditionalJump":
                        break;
                    default:
                        break;
                }

                // Bepaal de volgende node: 
                CurrentNode.Accept(visitor);
                CurrentNode = visitor.NextNode;
            }
        }

        public void sortParameters(List<string> parameters)
        {
            Dictionary<string, BaseCommand> commands = new Dictionary<string, BaseCommand>()
            {
                {"+", new PlusCommand()},
                {"-", new MinusCommand()},
                {"*", new MultiplyCommand()},
                {"/", new DivideCommand()},
                {"++", new IncrementCommand()},
                {"--", new DecrementCommand()}
            };
            List<string> operations = new List<string>() { "+", "-", "/", "*", "++", "--" };
            bool prevWasOperation = false;

            foreach (string param in parameters)
            {
                if (operations.Contains(param))
                {
                    if (!prevWasOperation)
                    {
                        commands[param].Execute(this, parameters);
                    }
                    else
                    {
                        Console.WriteLine("Compile error: operation already given!");
                    }
                }
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
