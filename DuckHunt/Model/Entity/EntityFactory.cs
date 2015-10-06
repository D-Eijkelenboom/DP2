using System;
using DuckHunt.Helper;

namespace DuckHunt.Model.Entity
{
	public class EntityFactory
	{
		public static Entity createEntity(EntityType entity)
		{
			var entityAttribute = entity.GetAttribute<EntityInfoAttribute>();
			if (entityAttribute == null)
			{
				return null;
			}
			var type = entityAttribute.Type;
			Entity result = Activator.CreateInstance(type) as Entity;
			return result;
		}

		public static Entity createEntity(EntityType entity, double x, double y)
		{
			var entityAttribute = entity.GetAttribute<EntityInfoAttribute>();
			if (entityAttribute == null)
			{
				return null;
			}
			var type = entityAttribute.Type;
			Entity result = Activator.CreateInstance(type) as Entity;
			result.X = x;
			result.Y = y;
			return result;
		}

		public static Bullet createBullet(double x, double y)
		{
			var entityAttribute = EntityType.Bullet.GetAttribute<EntityInfoAttribute>();
			if (entityAttribute == null)
			{
				return null;
			}
			var type = entityAttribute.Type;
			Bullet result = Activator.CreateInstance(type, x, y) as Bullet;
			return result;
		}
	}
}
