using System;
using SwinGameSDK;

namespace MyGame
{
	public class SideBar
	{
		private Sprite _sideBar;
		private GameLife _gameLife;
		private static int _life;

		private HoldingFoodFrame _holdingFoodFrame;

		private Timer _gameTime;
		private static uint _ticks;

		private ViewManager _viewManager;

		public SideBar (ViewManager viewManager)
		{
			_holdingFoodFrame = new HoldingFoodFrame ();

			_viewManager = viewManager;

			_gameTime = SwinGame.CreateTimer ();
			SwinGame.StartTimer (_gameTime);

			_life = 6;
			_gameLife = new GameLife ();

			SwinGame.LoadBitmapNamed ("side", "side_menu.png");
			_sideBar = SwinGame.CreateSprite (SwinGame.BitmapNamed ("side"));

		}

		public void SetX (int x)
		{
			SwinGame.SpriteSetX (_sideBar, x);
		}

		public HoldingFoodFrame HoldingFoodFrame {
			get { return _holdingFoodFrame; }
			set { _holdingFoodFrame = value; }
		}

		public static uint Ticks {
			get { return _ticks; }
			set { _ticks = value; }
		}

		public void Draw ()
		{
			_ticks = SwinGame.TimerTicks (_gameTime)/100;
			SwinGame.DrawSprite (_sideBar);
			_gameLife.Draw ();
			SwinGame.DrawText ("" + _ticks, Color.Black, "Arial", 35, 400, 20);
			_holdingFoodFrame.Draw ();
		}

		public void DecreaseGameLife ()
		{
			_life = _life - 1;
			_gameLife.Width = _gameLife.Width - 17;
		}

		public void ProcessEvent ()
		{
			if (_life <= 0) {
				_viewManager.View = _viewManager.End;
			}
		}

	}
}
