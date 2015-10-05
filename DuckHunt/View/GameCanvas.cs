using DuckHunt.Model.Container;
using DuckHunt.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DuckHunt.View
{
	public class GameCanvas : Canvas
	{
		private Label statusLabel;

		private BitmapImage chickenImage = new BitmapImage(new Uri("..\\Images\\chicken.png", UriKind.RelativeOrAbsolute));
		private BitmapImage bulletImage = new BitmapImage(new Uri("..\\Images\\gunshot-clipart-bullet-hole-hi.png", UriKind.RelativeOrAbsolute));
		private BitmapImage hitsplatImage = new BitmapImage(new Uri("..\\Images\\hitsplat.png", UriKind.RelativeOrAbsolute));
		private BitmapImage balloonImage = new BitmapImage(new Uri("..\\Images\\balloon.png", UriKind.RelativeOrAbsolute));

		public GameCanvas()
			: base()
		{
			this.Background = new SolidColorBrush(Colors.White);
			this.SetValue(Grid.ColumnProperty, 1);
			this.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
			this.MaxWidth = 500;
			this.MaxHeight = 300;

		}

		public void clearCanvas()
		{
			this.Dispatcher.Invoke(new Action(() =>
			{
				this.Children.Clear();
			}));

		}

		public void draw(EntityContainer ec)
		{
			this.Dispatcher.Invoke(new Action(() =>
			{
				drawEntities(ec);
			}));
		}

		public void drawStatusLabel(String message)
		{
			this.Dispatcher.Invoke(new Action(() =>
			{
				if (statusLabel == null)
				{
					statusLabel = new Label();
				}
				statusLabel.Name = "statusLabel";
				statusLabel.Content = message;
				statusLabel.Width = this.MaxWidth;
				statusLabel.FontSize = 18;
				statusLabel.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
				statusLabel.Height = 36;
				Canvas.SetTop(statusLabel, Math.Round(this.MaxHeight / 2) - statusLabel.Height);
				Canvas.SetZIndex(statusLabel, 150);
				if (!this.Children.Contains(statusLabel))
				{
					this.Children.Add(statusLabel);
				}
			}));
		}

		public void drawEntities(EntityContainer ec)
		{
			this.clearCanvas();
			foreach (Entity e in ec)
			{
				Image entityIcon = new Image();
				if (e is Chicken)
				{
					entityIcon.Source = chickenImage;
				}
				else if (e is Bullet)
				{
					entityIcon.Source = bulletImage;
				}
				else if (e is Balloon)
				{
					entityIcon.Source = balloonImage;
				}
				entityIcon.Width = e.Width;
				entityIcon.Height = e.Height;
				Canvas.SetLeft(entityIcon, e.X);
				Canvas.SetTop(entityIcon, e.Y);
				Canvas.SetZIndex(entityIcon, -1);
				this.Children.Add(entityIcon);

			}
		}

	}
}
