using DuckHunt2.Controller.Actions;
using DuckHunt2.View;
using System;
using System.Windows.Input;

namespace DuckHunt2.Controller
{
	public class BulletTimeController
	{
		private DuckHunt2.Model.Game game;
		private GameWindow gameWindow;
		private Boolean hasEvents;
		public Boolean HasEvents { get { return hasEvents; } set { hasEvents = value; } }

		public BulletTimeController(DuckHunt2.Model.Game game, GameWindow gameWindow)
		{
			this.game = game;
			this.gameWindow = gameWindow;
			this.game.BulletTimeControl = this;
			this.addMouseListener();
		}

		public void addMouseListener()
		{
			game.GamePanel.MouseDown += new MouseButtonEventHandler(shootEvent);
		}

		public void shootEvent(object sender, MouseButtonEventArgs e)
		{
			if (e.ChangedButton == MouseButton.Right)
			{
				game.ActionsContainer.Enqueue(new SlowMotionAction(this.game));
				this.hasEvents = true;
				game.ProcessInput = true;
			}
		}

	}
}
