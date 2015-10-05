using DuckHunt.Model.GameState;
using DuckHunt.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DuckHunt.Controller
{
	public class MenuController : BaseController
	{
		public MenuController(GameWindow gameWindow, GameState gameState)
			: base(gameWindow, gameState)
		{
		}

		public override void addListeners()
		{
			this.GameWindow.GameCanvas.MouseDown += new MouseButtonEventHandler(MouseDownEvent);
			this.GameWindow.KeyDown += new KeyEventHandler(KeyDownEvent);
		}

		public override void clearListeners()
		{
			this.GameWindow.GameCanvas.MouseDown -= MouseDownEvent;
			this.GameWindow.KeyDown -= KeyDownEvent;
		}


		public void MouseDownEvent(object sender, MouseButtonEventArgs e)
		{
			if (e.ChangedButton == MouseButton.Left)
			{

			}

			if (e.ChangedButton == MouseButton.Right)
			{

			}

		}

		public void KeyDownEvent(object sender, KeyEventArgs e)
		{

		}

	}
}
