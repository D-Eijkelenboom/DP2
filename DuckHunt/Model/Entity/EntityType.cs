
namespace DuckHunt.Model.Entity
{
	public enum EntityType
	{
		[EntityInfoAttribute(typeof(Chicken))]
		Chicken,
		[EntityInfoAttribute(typeof(Balloon))]
		Balloon,
		[EntityInfoAttribute(typeof(Bullet))]
		Bullet,
	}
}
