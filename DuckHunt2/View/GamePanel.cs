using DuckHunt2.Controller;
using DuckHunt2.Model.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DuckHunt2.View
{
	public class GamePanel : Canvas
	{
		private GameWindow gameWindow;
		private Model.Game game;
		private Label lblBulletCount;
		private Label lblHitCount;
		private Label lblTime;
		private Label lblFps;
		private Label lblStatus;

		private BitmapImage chickenImage = new BitmapImage(new Uri("..\\data\\Images\\chicken.png", UriKind.RelativeOrAbsolute));
		private BitmapImage bulletImage = new BitmapImage(new Uri("..\\data\\Images\\gunshot-clipart-bullet-hole-hi.png", UriKind.RelativeOrAbsolute));
		private BitmapImage hitsplatImage = new BitmapImage(new Uri("..\\data\\Images\\hitsplat.png", UriKind.RelativeOrAbsolute));
		private BitmapImage balloonImage = new BitmapImage(new Uri("..\\data\\Images\\balloon.png", UriKind.RelativeOrAbsolute));

		public GamePanel(Model.Game game, GameWindow gameWindow)
			: base()
		{
			this.game = game;
			this.gameWindow = gameWindow;

			this.Name = "pnlGamePanel";
			this.Background = new SolidColorBrush(Colors.White);
			this.SetValue(Grid.ColumnProperty, 1);
			this.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
			this.MaxWidth = 500;
			this.MaxHeight = 300;
			this.SetValue(Grid.ColumnSpanProperty, 2);

			this.createInfoLabels();

			gameWindow.mainGrid.Children.Add(this);

			game.ControllerThread = new Thread(makeController);
			game.ControllerThread.Name = "Controller Thread";
			game.ControllerThread.Start();
			 
		}

		public void createInfoLabels()
		{
			if (lblBulletCount == null)
				lblBulletCount = new Label();

			lblBulletCount.Content = "Bullets: " + game.StatusTracker.Bullets;
			lblBulletCount.Name = "lblBulletCount";
			lblBulletCount.Width = 114;
			Canvas.SetZIndex(lblBulletCount, 100);
			Canvas.SetTop(lblBulletCount, 248);
			this.Children.Add(lblBulletCount);

			if (lblHitCount == null)
				lblHitCount = new Label();

			lblHitCount.Name = "lblHitCount";
			lblHitCount.Content = "Hits: " + game.StatusTracker.Score;
			Canvas.SetZIndex(lblHitCount, 100);
			Canvas.SetTop(lblHitCount, 274);
			lblHitCount.Width = 114;
			this.Children.Add(lblHitCount);

			if (lblTime == null)
				lblTime = new Label();

			lblTime.Name = "lblTime";
			lblTime.Content = "Time: " + game.StatusTracker.GameTime;
			Canvas.SetZIndex(lblTime, 100);
			Canvas.SetTop(lblTime, -1);
			this.Children.Add(lblTime);

			if (lblFps == null)
				lblFps = new Label();

			lblFps.Name = "lblFps";
			this.lblFps.Content = "FPS: " + game.StatusTracker.RealTimeFps;
			Canvas.SetLeft(lblFps, 421);
			Canvas.SetZIndex(lblFps, 100);
			Canvas.SetTop(lblFps, -1);
			this.Children.Add(lblFps);

			if (lblStatus == null)
				lblStatus = new Label();

			lblStatus.Name = "lblStatus";
			lblStatus.Content = game.StatusTracker.StatusMsg;
			lblStatus.Width = this.MaxWidth;
			lblStatus.FontSize = 18;
			lblStatus.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
			lblStatus.Height = 36;
			Canvas.SetTop(lblStatus, Math.Round(this.MaxHeight / 2) - lblStatus.Height);
			Canvas.SetZIndex(lblStatus, 150);
			this.Children.Add(lblStatus);
		}

		public void makeController()
		{
			ShootController sc = new ShootController(game, gameWindow);
			BulletTimeController bc = new BulletTimeController(game, gameWindow);

			while (this.game.Running)
			{
				Thread.Sleep(10);
			}
		}

		public void renderSingleChicken(Chicken chicken)
		{
			Image chickenIcon = new Image();
			chickenIcon.Source = chickenImage;
			chickenIcon.Width = chicken.Width;
			chickenIcon.Height = chicken.Height;
			Canvas.SetLeft(chickenIcon, chicken.X);
			Canvas.SetTop(chickenIcon, chicken.Y);
			this.Children.Add(chickenIcon);
		}

		public void renderBullet(Bullet bullet)
		{
			Image bulletIcon = new Image();
			bulletIcon.Source = bulletImage;
			bulletIcon.Width = bullet.Width;
			bulletIcon.Height = bullet.Height;
			Canvas.SetLeft(bulletIcon, bullet.X - bullet.Width / 2);
			Canvas.SetTop(bulletIcon, bullet.Y - bullet.Height / 2);
			Canvas.SetZIndex(bulletIcon, -1);
			this.Children.Add(bulletIcon);
		}

		public void renderHitsplat(Chicken chicken)
		{
			Image hitsplatIcon = new Image();
			hitsplatIcon.Source = hitsplatImage;
			hitsplatIcon.Width = chicken.Width;
			hitsplatIcon.Height = chicken.Height;
			Canvas.SetLeft(hitsplatIcon, chicken.X);
			Canvas.SetTop(hitsplatIcon, chicken.Y);
			Canvas.SetZIndex(hitsplatIcon, 0);
			this.Children.Add(hitsplatIcon);
		}


		public void renderBalloon(Balloon balloon)
		{
			Image balloonIcon = new Image();
			balloonIcon.Source = balloonImage;
			balloonIcon.Width = balloon.Width;
			balloonIcon.Height = balloon.Height;
			Canvas.SetLeft(balloonIcon, balloon.X);
			Canvas.SetTop(balloonIcon, balloon.Y);
			Canvas.SetZIndex(balloonIcon, -1);
			this.Children.Add(balloonIcon);
		}

		public void renderChickens()
		{
			foreach (Chicken chicken in game.MainContainer[Behaviour.Visible].OfType<Chicken>())
			{
				if (chicken.IsAlive)
				{
					renderSingleChicken(chicken);
				}
				else
				{
					renderHitsplat(chicken);
				}
			}
		}


		public void renderBalloons()
		{
			foreach (Balloon balloon in game.MainContainer[Behaviour.Visible].OfType<Balloon>())
			{
				renderBalloon(balloon);
			}
		}

		public void renderBullets()
		{
			foreach (Bullet bullet in game.Bullets)
			{
				renderBullet(bullet);
			}
		}

		public void update()
		{
			//Utilize UI Thread to update GUI
			this.Dispatcher.Invoke(new Action(() =>
			{
				clearCanvas();
				renderChickens();
				renderBalloons();
				renderBullets();
			}));
		}

		public void clearCanvas()
		{
			this.Children.Clear();
			createInfoLabels();
		}
	}
}
