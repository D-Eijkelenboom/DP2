using DuckHunt.Controller;
using DuckHunt.Controller.Actions;
using DuckHunt.Model.Container;

namespace DuckHunt.Model.GameState
{
	public class MenuState : GameState
	{
		public GameStateManager GSM { get; set; }
		public MainContainer MainContainer { get; set; }
		public ActionContainer ActionContainer { get; set; }
		public GameOverController GameOverController { get; set; }

		public void init(GameStateManager gsm)
		{
			this.GSM = gsm;

			this.ActionContainer = new ActionContainer();

			this.MainContainer = new MainContainer();

			this.GameOverController = new GameOverController(this.GSM.GameWindow, this);
			this.GameOverController.init();
		}

		public void cleanup()
		{
			this.GameOverController.cleanup();
		}

		public void handleInput()
		{
			ControllerAction action;
			lock (this.ActionContainer)
			{
				while (this.ActionContainer.Count > 0)
				{
					this.ActionContainer.TryDequeue(out action);
					if (action == null)
						continue;

					action.execute();
				}
			}
		}

		public void update(double dt)
		{
			//throw new NotImplementedException();
		}

		public void draw()
		{
			this.GSM.GameCanvas.drawStatusLabel("Welcome! Press P to paly!");
		}

		public void pause()
		{
			this.GameOverController.cleanup();
		}

		public void resume()
		{
			this.GameOverController.init();
		}
	}
}
