using DuckHunt.Model.Entity;
using System;
using System.Collections.Generic;

namespace DuckHunt.Model.Container
{
	public class MainContainer : Dictionary<Behaviour, EntityContainer>
	{
		public MainContainer()
		{
			foreach (Behaviour behaviour in Enum.GetValues(typeof(Behaviour)))
			{
				switch (behaviour.ToString())
				{
					case "Movable":
						this[behaviour] = new MovableContainer();
						break;
					case "Shootable":
						this[behaviour] = new ShootableContainer();
						break;
					case "Destroyable":
						this[behaviour] = new DestroyableContainer();
						break;
					case "Visible":
						this[behaviour] = new VisibleContainer();
						break;
				}
			}
		}

		public void addEntity(Entity.Entity e)
		{
			foreach (Behaviour b in e.BehaviourList)
			{
				this[b].Add(e);
			}
		}

		public void removeEntity(Entity.Entity e)
		{
			foreach (Behaviour b in e.BehaviourList)
			{
				if (this[b].Contains(e))
					this[b].Remove(e);
			}
		}

		public void update(double dt)
		{
			foreach (EntityContainer ec in this.Values)
			{
				ec.update(dt);
			}
		}
	}
}
