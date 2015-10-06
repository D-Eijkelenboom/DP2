using System;

namespace DuckHunt.Model.GameState
{
	public class GameStateInfoAttribute : Attribute
	{
		private Type type;

		public GameStateInfoAttribute(Type type)
		{
			this.type = type;
		}

		public Type Type { get { return this.type; } }
	}
}
