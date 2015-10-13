using DuckHunt.Main;
using DuckHunt.View;
using System.Collections.Generic;
using System.Media;

namespace DuckHunt.Model.GameState
{
	public class GameStateManager
	{
		public Game Game { get; set; }

		public GameWindow GameWindow { get; set; }

		public GameCanvas GameCanvas { get; set; }

		public Stack<GameState> GameStates { get; set; }

		private StatusTracker stats;
		public StatusTracker Stats
		{
			get { return stats; }
			set { stats = value; }
		}

		private SoundPlayer sound;
		public SoundPlayer Sound
		{
			get { return sound; }
			set { sound = value; }
		}

		public GameStateManager(Game game)
		{
			this.Game = game;

			//View
			this.GameWindow = new GameWindow(this.Game);
			this.GameCanvas = new GameCanvas();
			this.GameWindow.GameCanvas = this.GameCanvas;
			this.GameWindow.Show();

			//Model
			stats = new StatusTracker();
			Sound = new SoundPlayer();

			GameStates = new Stack<GameState>();
			this.changeGameState(GameStateFactory.createGameState(GameStateType.menuState));
		}

		public void changeGameState(GameState gameState)
		{
			if (!(GameStates.Count < 1))
			{
				GameStates.Peek().cleanup();
				GameStates.Pop();
			}

			GameCanvas.clearCanvas();

			GameStates.Push(gameState);
			GameStates.Peek().init(this);
		}

		public void pushGameState(GameState gameState)
		{
			if (!(GameStates.Count < 1))
				GameStates.Peek().pause();

			GameStates.Push(gameState);
			GameStates.Peek().init(this);
		}

		public void popGameState()
		{
			if (!(GameStates.Count < 1))
			{
				GameStates.Peek().cleanup();
				GameStates.Pop();
			}

			if (!(GameStates.Count < 1))
				GameStates.Peek().resume();
		}

		public void handleInput()
		{
			GameStates.Peek().handleInput();
		}

		public void update(double dt)
		{
			GameStates.Peek().update(dt);
		}

		public void draw()
		{
			GameStates.Peek().draw();
		}

		public void quit()
		{
			this.Game.Running = false;
		}
	}
}
