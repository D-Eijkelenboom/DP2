using DuckHunt.Controller.Actions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckHunt.Model.Container
{
	public class ActionContainer : ConcurrentQueue<ControllerAction>
	{ }
}
