using DuckHunt.Controller;
using DuckHunt.Controller.Actions;
using DuckHunt.Model.Container;
using DuckHunt.Model.Entity;
using System.Collections.Generic;

namespace DuckHunt.Model.GameState
{
	public class Level1State : GameState
	{
		private static Level1State instance;

		public GameStateManager GSM { get; set; }
		public GameController GameController { get; set; }
		public MainContainer MainContainer { get; set; }
		public ActionContainer ActionContainer { get; set; }

		int lvlBulletes;

		public Level1State() { }

		public static Level1State Instance()
		{
			if (instance == null)
				instance = new Level1State();

			return instance;
		}

		public void init(GameStateManager gsm)
		{
			lvlBulletes = 10;
			this.GSM = gsm;

			this.GSM.Stats.Bullets = lvlBulletes;

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
					GSM.Stats.substractBullets();
					GSM.Stats.increaseShots();
				}
			}
		}

		public void update(double dt)
		{
			if (this.GSM.Stats.Bullets < 1)
			{
				this.GSM.changeGameState(GameStateFactory.createGameState(GameStateType.gameOver));
				return;
			}

			if (this.MainContainer[Behaviour.Shootable].Count < 1)
			{
				this.GSM.changeGameState(GameStateFactory.createGameState(GameStateType.level2));
				return;
			}
			MainContainer.update(dt);
		}

		public void draw()
		{
			this.GSM.GameCanvas.draw(MainContainer[Behaviour.Visible]);
			this.GSM.GameCanvas.drawUiLabels(bullets: this.GSM.Stats.Bullets, score: this.GSM.Stats.Shots,
				gameTime: this.GSM.Stats.GameTime, FPS: this.GSM.Stats.FPS);
		}

		public void pause()
		{
			this.GameController.cleanup();
		}

		public void resume()
		{
			this.GameController.init();
		}
	}
}
