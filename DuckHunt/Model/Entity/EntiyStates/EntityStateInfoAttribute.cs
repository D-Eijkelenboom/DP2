using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckHunt.Model.Entity.EntiyStates
{
	public class EntityStateInfoAttribute: Attribute
	{
		private Type type;

		public EntityStateInfoAttribute(Type type)
		{
			this.type = type;
		}

		public Type Type { get { return this.type; } }
	}
}
