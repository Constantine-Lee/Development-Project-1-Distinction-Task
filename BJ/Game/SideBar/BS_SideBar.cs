using System;
using SwinGameSDK;

namespace MyGame
{
	public class BS_SideBar
	{
		private Sprite _sideBar;
		private BS_GameLife _gameLife;
		private static int _life;

		private BS_HoldingFoodFrame _holdingFoodFrame;

		private Timer _gameTime;
		private static uint _ticks;

		private ViewManager _viewManager;

		public BS_SideBar (ViewManager viewManager)
		{
			_holdingFoodFrame = new BS_HoldingFoodFrame ();

			_viewManager = viewManager;

			_gameTime = SwinGame.CreateTimer ();
			SwinGame.StartTimer (_gameTime);

			_life = 6;
			_gameLife = new BS_GameLife ();

			SwinGame.LoadBitmapNamed ("side", "side_menu.png");
			_sideBar = SwinGame.CreateSprite (SwinGame.BitmapNamed ("side"));

		}

		public BS_SideBar ()
		{
            _life = 6;
		}

		public void SetX (int x)
		{
			SwinGame.SpriteSetX (_sideBar, x);
		}

		public BS_HoldingFoodFrame HoldingFoodFrame {
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

		/*Check to see if the player's life
		 * is full or not
		*/
		public bool FullLifeCheck () {
			if (_life >= 6) {
				return true;
			} else {
				return false;
			}
		}

		public int Life {
			get { return _life; }
			set { _life = value; }
		}

		public BS_GameLife gameLife { 
			get { return _gameLife;}
			set { _gameLife = value;}
		}

		public void ProcessEvent ()
		{
			if (_life <= 0) {
				_viewManager.View = _viewManager.BS_End;
			}
		}

	}
}
