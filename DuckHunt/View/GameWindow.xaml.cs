using DuckHunt.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
