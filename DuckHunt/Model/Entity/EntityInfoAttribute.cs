using System;

namespace DuckHunt.Model.Entity
{
	public class EntityInfoAttribute : Attribute
	{
		private Type type;

		public EntityInfoAttribute(Type type)
		{
			this.type = type;
		}

		public Type Type { get { return this.type; } }
	}
}
