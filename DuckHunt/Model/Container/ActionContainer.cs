using DuckHunt.Controller.Actions;
using System.Collections.Concurrent;

namespace DuckHunt.Model.Container
{
	public class ActionContainer : ConcurrentQueue<ControllerAction>
	{ }
}
