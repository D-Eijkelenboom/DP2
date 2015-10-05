using DuckHunt2.Model;
using DuckHunt2.Model.Entities;

namespace DuckHunt2.Controller.Actions
{
	class SlowMotionAction : ControllerAction
	{
		public SlowMotionAction(DuckHunt2.Model.Game game)
		{
			this.game = game;
		}

		public override void execute()
		{
			game.Player.SoundLocation = "data\\Sounds\\Flame woosh.wav";
			game.Player.Play();
			foreach (Entity e in game.MainContainer[Behaviour.Visible])
			{
				e.slowDown();
			}
		}
	}
}
