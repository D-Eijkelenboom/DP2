using DuckHunt.Main;
using System.Windows;

namespace DuckHunt.View
{
	/// <summary>
	/// Interaction logic for GameWindow.xaml
	/// </summary>
	public partial class GameWindow : Window
	{
		private Game game;
		private GameCanvas gameCanvas;
		public GameCanvas GameCanvas { get { return gameCanvas; } set { gameCanvas = value; this.mainGrid.Children.Add(value); } }


		public GameWindow(Game game)
			: base()
		{
			InitializeComponent();

			this.game = game;
		}

		private void Close_GameWindow(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this.game.Running = false;
		}
	}
}
