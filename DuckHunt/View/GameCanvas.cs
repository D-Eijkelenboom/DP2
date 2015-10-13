using DuckHunt.Model.Container;
using DuckHunt.Model.Entity;
using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DuckHunt.View
{
	public class GameCanvas : Canvas
	{
		private Label lblBulletCount;
		private Label lblShotsFired;
		private Label lblTime;
		private Label lblFps;
		private Label lblStatus;

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

		public void drawStatusLabel(String message, int lblHight = 36)
		{
			this.Dispatcher.Invoke(new Action(() =>
			{
				if (lblStatus == null)
					lblStatus = new Label();

				lblStatus.Name = "lblStatus";
				lblStatus.Content = message;
				lblStatus.Width = this.MaxWidth;
				lblStatus.FontSize = 18;
				lblStatus.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
				lblStatus.Height = lblHight;
				Canvas.SetTop(lblStatus, Math.Round(this.MaxHeight / 2) - lblStatus.Height);
				Canvas.SetZIndex(lblStatus, 150);
				if (!this.Children.Contains(lblStatus))
				{
					this.Children.Add(lblStatus);
				}
			}));
		}

		public void drawUiLabels(int bullets = 0, int score = 0, long gameTime = 0, double FPS = 0)
		{
			this.Dispatcher.Invoke(new Action(() =>
			{
				if (lblBulletCount == null)
					lblBulletCount = new Label();

				lblBulletCount.Name = "lblBulletCount";
				//lblBulletCount.Content = "Bullets: " + game.StatusTracker.Bullets;
				lblBulletCount.Content = "Bullets: " + bullets;
				lblBulletCount.Width = 114;
				Canvas.SetZIndex(lblBulletCount, 100);
				Canvas.SetTop(lblBulletCount, 248);
				if (!this.Children.Contains(lblBulletCount))
					this.Children.Add(lblBulletCount);

				if (lblShotsFired == null)
					lblShotsFired = new Label();

				lblShotsFired.Name = "lblShotsFired";
				//lblHitCount.Content = "Hits: " + game.StatusTracker.Score;
				lblShotsFired.Content = "Shots: " + score;
				Canvas.SetZIndex(lblShotsFired, 100);
				Canvas.SetTop(lblShotsFired, 274);
				lblShotsFired.Width = 114;
				if (!this.Children.Contains(lblShotsFired))
					this.Children.Add(lblShotsFired);
				

				if (lblTime == null)
					lblTime = new Label();

				lblTime.Name = "lblTime";
				//lblTime.Content = "Time: " + game.StatusTracker.GameTime;
				lblTime.Content = "Time: " + gameTime;
				Canvas.SetZIndex(lblTime, 100);
				Canvas.SetTop(lblTime, -1);
				if (!this.Children.Contains(lblTime))
					this.Children.Add(lblTime);
				

				if (lblFps == null)
					lblFps = new Label();

				lblFps.Name = "lblFps";
				//this.lblFps.Content = "FPS: " + game.StatusTracker.RealTimeFps;
				this.lblFps.Content = "FPS: " + FPS;
				Canvas.SetLeft(lblFps, 421);
				Canvas.SetZIndex(lblFps, 100);
				Canvas.SetTop(lblFps, -1);
				if (!this.Children.Contains(lblFps))
					this.Children.Add(lblFps);
			}));
		}
		public void createUiLabels(int bullets = 0, int hits = 0, long gameTime = 0, int FPS = 0)
		{
			if (lblBulletCount == null)
				lblBulletCount = new Label();

			lblBulletCount.Name = "lblBulletCount";
			//lblBulletCount.Content = "Bullets: " + game.StatusTracker.Bullets;
			lblBulletCount.Content = "Bullets: " + bullets;
			lblBulletCount.Width = 114;
			Canvas.SetZIndex(lblBulletCount, 100);
			Canvas.SetTop(lblBulletCount, 248);
			if (!this.Children.Contains(lblBulletCount))
				this.Children.Add(lblBulletCount);

			if (lblShotsFired == null)
				lblShotsFired = new Label();

			lblShotsFired.Name = "lblHitCount";
			//lblHitCount.Content = "Hits: " + game.StatusTracker.Score;
			lblShotsFired.Content = "Hits: " + hits; 
			Canvas.SetZIndex(lblShotsFired, 100);
			Canvas.SetTop(lblShotsFired, 274);
			lblShotsFired.Width = 114;
			if (!this.Children.Contains(lblShotsFired))
				this.Children.Add(lblShotsFired);

			if (lblTime == null)
				lblTime = new Label();

			lblTime.Name = "lblTime";
			//lblTime.Content = "Time: " + game.StatusTracker.GameTime;
			lblTime.Content = "Time: " + gameTime;
			Canvas.SetZIndex(lblTime, 100);
			Canvas.SetTop(lblTime, -1);
			if (!this.Children.Contains(lblTime))
				this.Children.Add(lblTime);

			if (lblFps == null)
				lblFps = new Label();

			lblFps.Name = "lblFps";
			//this.lblFps.Content = "FPS: " + game.StatusTracker.RealTimeFps;
			this.lblFps.Content = "FPS: " + FPS;
			Canvas.SetLeft(lblFps, 421);
			Canvas.SetZIndex(lblFps, 100);
			Canvas.SetTop(lblFps, -1);
			if (!this.Children.Contains(lblFps))
				this.Children.Add(lblFps);
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
