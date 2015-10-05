using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckHunt2.Controller.Actions
{
	public class ActionContainer : System.Collections.Concurrent.ConcurrentQueue<ControllerAction>
	{
		public ActionContainer()
		{ }
	}
}
