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
using DuckHunt2.Model;

namespace DuckHunt2.View
{
	/// <summary>
	/// Interaction logic for GameWindow.xaml
	/// </summary>
	public partial class GameWindow : Window
	{
		private Model.Game game;
		public GameWindow(Model.Game game)
			: base()
		{
			InitializeComponent();
			this.game = game;
			this.Closing += closeGameScreen;
		}

		public void closeGameScreen(object sender, EventArgs e)
		{
			game.Running = false;
		}
	}
}
