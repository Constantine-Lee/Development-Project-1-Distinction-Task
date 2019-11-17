using System;
using SwinGameSDK;

namespace MyGame
{
	public class MWSideBarUpdate
	{
		private Sprite _sideBar;
		private MWGameLife _gameLife;
		private static int _life;

		private MWHoldingFoodFrame _holdingFoodFrame;

		//private Timer _gameTime;
		//private static uint _ticks;
		private static int _score = 0;

		private ViewManager _viewManager;

		public MWSideBarUpdate (ViewManager viewManager)
		{
			_holdingFoodFrame = new MWHoldingFoodFrame ();

			_viewManager = viewManager;

			//_gameTime = SwinGame.CreateTimer ();
			//SwinGame.StartTimer (_gameTime);
			_life = 6;
			_gameLife = new MWGameLife ();
			SwinGame.LoadBitmapNamed ("side", "side_menu.png");
			_sideBar = SwinGame.CreateSprite (SwinGame.BitmapNamed ("side"));

		}
		public void SetX (int x)
		{
			SwinGame.SpriteSetX (_sideBar, x);
		}

		public MWHoldingFoodFrame HoldingFoodFrame {
			get { return _holdingFoodFrame; }
			set { _holdingFoodFrame = value; }
		}

		public static int Score {
			get { return _score; }
			set { _score = value; }
		}

		public void AddScore ()
		{
			_score += 100;
		}

		public void Draw ()
		{
			//_ticks = SwinGame.TimerTicks (_gameTime) / 100;
			SwinGame.DrawSprite (_sideBar);
			_gameLife.Draw ();
			SwinGame.DrawText ("" + _score, Color.Black, "Arial", 35, 400, 20);
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
				_viewManager.View = _viewManager.ZYEnd;
			}
		}
	}
}
