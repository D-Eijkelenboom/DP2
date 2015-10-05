using DuckHunt2.Controller;
using DuckHunt2.Controller.Actions;
using DuckHunt2.Model.Containers;
using DuckHunt2.Model.Entities;
using DuckHunt2.View;
using Game.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Threading;

namespace DuckHunt2.Model
{
	public class Game
	{
		#region Helpers
		private Helper.Timer hqTimer;

		private bool gameRunning;
		public bool GameRunning { get { return gameRunning; } set { gameRunning = value; } }

		private bool running;
		public bool Running { get { return running; } set { running = value; } }

		private SoundPlayer player;
		public SoundPlayer Player { get { return player; } set { player = value; } }
		#endregion

		#region Models
		private StatTracker statusTracker;
		public StatTracker StatusTracker { get { return statusTracker; } set { statusTracker = value; } }

		public MainContainer MainContainer { get; set; }

		private List<Chicken> chickens;
		public List<Chicken> Chickens { get { return chickens; } set { chickens = value; } }

		private List<Bullet> bullets;
		public List<Bullet> Bullets { get { return bullets; } set { bullets = value; } }
		#endregion

		#region Views
		private GameWindow gameWindow;
		public GameWindow GameWindow { get { return gameWindow; } set { gameWindow = value; } }

		private GamePanel gamePanel;
		public GamePanel GamePanel { get { return gamePanel; } set { gamePanel = value; } }
		#endregion

		#region Controllers
		private bool processInput;
		public bool ProcessInput { get { return processInput; } set { processInput = value; } }

		private ActionContainer actionsContainer;
		public ActionContainer ActionsContainer { get { return actionsContainer; } set { actionsContainer = value; } }

		private ShootController shootControl;
		public ShootController ShootControl { get { return shootControl; } set { shootControl = value; } }

		private BulletTimeController bulletTimeControl;
		public BulletTimeController BulletTimeControl { get { return bulletTimeControl; } set { bulletTimeControl = value; } }
		#endregion

		#region Threads
		private Thread gameLoopThread;
		public Thread GameLoopThread { get { return gameLoopThread; } set { gameLoopThread = value; } }

		private Thread controllerThread;
		public Thread ControllerThread { get { return controllerThread; } set { controllerThread = value; } }
		#endregion

		public Game()
		{
			initModels();
			initView();
			this.Running = true;
			runGameLoop();
		}

		public void restartGame()
		{
			if (StatusTracker.GameRunning == false)
			{
				gameLoopThread.Abort();
				initModels();

				runGameLoop();
			}
		}

		public void runGameLoop()
		{
			gameLoopThread = new Thread(new ThreadStart(gameLoop));
			gameLoopThread.Name = "Game_Loop";
			gameLoopThread.IsBackground = true;
			gameLoopThread.Start();
			this.StatusTracker.GameRunning = true;
		}

		public void initModels()
		{
			//Create Action Container
			actionsContainer = new ActionContainer();

			//Create Entities
			Entity c1 = EntityFactory.createEntity(EntityTypes.Chicken);
			Entity b1 = EntityFactory.createEntity(EntityTypes.Balloon);

			//Create Entity Containers         
			MainContainer = new MainContainer();
			MainContainer.addEntity(c1);
			MainContainer.addEntity(b1);

			bullets = new List<Bullet>();

			//Game Status
			statusTracker = new StatTracker();
			statusTracker.MAX_SCORE = MainContainer[Behaviour.Shootable].OfType<Chicken>().ToList().Count;
			//Timer
			hqTimer = new Helper.Timer();
		}

		public void initView()
		{
			gameWindow = new GameWindow(this);
			gamePanel = new GamePanel(this, gameWindow);
			gameWindow.Show();

			player = new SoundPlayer();
		}

		/**
		 * Game loop
		 */
		public void gameLoop()
		{
			double TARGET_FPS = 60;
			double OPTIMAL_TIME = 1000 / TARGET_FPS;

			hqTimer.Start();
			long lastLoopTime = hqTimer.ElapsedMilliSeconds;

			long lastFpsTime = 0;
			int fps = 0;
			while (this.running)
			{
				long now = hqTimer.ElapsedMilliSeconds;
				long updateLength = now - lastLoopTime;
				lastLoopTime = now;
				double delta = updateLength / OPTIMAL_TIME;

				lastFpsTime += updateLength;
				fps++;

				if (lastFpsTime >= 1000)
				{
					StatusTracker.RealTimeFps = fps;
					lastFpsTime = 0;
					fps = 0;
				}

				if (StatusTracker.GameRunning)
				{
					this.gameLogic(delta);
					this.handleInput();
				}

				this.renderGame(delta);
				this.checkGameStatus();

				if (lastLoopTime - hqTimer.ElapsedMilliSeconds + OPTIMAL_TIME > 0)
				{
					Thread.Sleep(TimeSpan.FromMilliseconds(lastLoopTime - hqTimer.ElapsedMilliSeconds + OPTIMAL_TIME));
				}
			}
		}

		/**
		 * Handle the input from the controllers
		 */
		public void handleInput()
		{
			if (!this.ProcessInput)
			{
				return;
			}
			ControllerAction action;
			lock (actionsContainer)
			{
				while (actionsContainer.Count > 0)
				{
					actionsContainer.TryDequeue(out action);
					if (action == null)
						continue;

					action.execute();
				}
			}
			this.ProcessInput = false;
		}


		/**
		 * Update Models
		 */
		public void gameLogic(double dt)
		{
			statusTracker.GameTime = hqTimer.ElapsedMilliSeconds;
			MainContainer.update(dt);
		}

		/**
		 * Update View
		 */
		public void renderGame(double dt)
		{
			this.gamePanel.update();
		}

		/**
		 * Check the game status
		 */
		public void checkGameStatus()
		{
			if (StatusTracker.Score == StatusTracker.MAX_SCORE)
			{
				this.StatusTracker.StatusMsg = "Congratulations, you won! Press 'T' to start over!";
				this.StatusTracker.GameRunning = false;
			}
			else if (StatusTracker.Bullets == 0)
			{
				this.StatusTracker.StatusMsg = "Too bad, you lost (no bullets left)! Press 'T' to start over!";
				this.StatusTracker.GameRunning = false;
			}
		}
	}
}
