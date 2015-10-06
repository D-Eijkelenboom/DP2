using DuckHunt.Controller;
using DuckHunt.Controller.Actions;
using DuckHunt.Model.Container;
using DuckHunt.Model.Entity;

namespace DuckHunt.Model.GameState
{
	public class Level2State : GameState
	{
		public static Level2State instance;

		public GameStateManager GSM { get; set; }
		public GameController GameController { get; set; }
		public MainContainer MainContainer { get; set; }
		public ActionContainer ActionContainer { get; set; }

		public static Level2State Instance()
		{
			if (instance == null)
				instance = new Level2State();

			return instance;
		}

		public void init(GameStateManager gsm)
		{
			this.GSM = gsm;

			this.ActionContainer = new ActionContainer();

			this.MainContainer = new MainContainer();
			this.MainContainer.addEntity(EntityFactory.createEntity(EntityType.Chicken, 250, 250));
			this.MainContainer.addEntity(EntityFactory.createEntity(EntityType.Chicken, 0, 0));
			this.MainContainer.addEntity(EntityFactory.createEntity(EntityType.Chicken, 100, 50));
			this.MainContainer.addEntity(EntityFactory.createEntity(EntityType.Balloon, 160, 106));

			this.GameController = new GameController(this.GSM.GameWindow, this);
			this.GameController.init();
		}
		public void cleanup()
		{
			this.GameController.cleanup();
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
			if (this.MainContainer[Behaviour.Shootable].Count < 1)
			{
				this.GSM.changeGameState(GameStateFactory.createGameState(GameStateType.finished));
				return;
			}
			MainContainer.update(dt);
		}

		public void draw()
		{
			this.GSM.GameCanvas.draw(MainContainer[Behaviour.Visible]);
		}


		public void pause()
		{
			//throw new NotImplementedException();
		}

		public void resume()
		{
			//throw new NotImplementedException();
		}
	}
}
