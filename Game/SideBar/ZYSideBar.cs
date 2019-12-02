using System;
using SwinGameSDK;

namespace MyGame
{
	public class ZYSideBar: ZYSideBarInterface
	{
		private Sprite _sideBar;
        private Sprite star1, star2, star3, star4, star5, star6;
		private ZYGameLife _gameLife;
		private static int _life;
        public static int winStar;

		private ZYHoldingFoodFrame _holdingFoodFrame;

		private Timer _gameTime;
		private static uint _ticks;

		private ViewManager _viewManager;

		public ZYSideBar (ViewManager viewManager)
		{
			_holdingFoodFrame = new ZYHoldingFoodFrame ();

			_viewManager = viewManager;

			_gameTime = SwinGame.CreateTimer ();
			SwinGame.StartTimer (_gameTime);

            winStar = 0;
			_life = 6;
			_gameLife = new ZYGameLife ();

			SwinGame.LoadBitmapNamed ("side", "side_menu.png");
			_sideBar = SwinGame.CreateSprite (SwinGame.BitmapNamed ("side"));

            SwinGame.LoadBitmapNamed("star.png", "star.png");
            SwinGame.LoadBitmapNamed("yellowStar.png", "yellowStar.png");
            star1 = SwinGame.CreateSprite(SwinGame.BitmapNamed("star.png"));
            star2 = SwinGame.CreateSprite(SwinGame.BitmapNamed("star.png"));
            star3 = SwinGame.CreateSprite(SwinGame.BitmapNamed("star.png"));
            star4 = SwinGame.CreateSprite(SwinGame.BitmapNamed("yellowStar.png"));
            star5 = SwinGame.CreateSprite(SwinGame.BitmapNamed("yellowStar.png"));
            star6 = SwinGame.CreateSprite(SwinGame.BitmapNamed("yellowStar.png"));
        }

		public void SetX (int x)
		{
			SwinGame.SpriteSetX (_sideBar, x);
            SwinGame.SpriteSetX(star1, x+25);
            SwinGame.SpriteSetX(star2, x+60);
            SwinGame.SpriteSetX(star3, x+95);

            SwinGame.SpriteSetY(star1, 30);
            SwinGame.SpriteSetY(star2, 30);
            SwinGame.SpriteSetY(star3, 30);

            SwinGame.SpriteSetX(star4, x + 25);
            SwinGame.SpriteSetX(star5, x + 60);
            SwinGame.SpriteSetX(star6, x + 95);

            SwinGame.SpriteSetY(star4, 30);
            SwinGame.SpriteSetY(star5, 30);
            SwinGame.SpriteSetY(star6, 30);
        }

		public ZYHoldingFoodFrame HoldingFoodFrame {
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


            if (winStar == 0)
            {
                SwinGame.DrawSprite(star1);
                SwinGame.DrawSprite(star2);
                SwinGame.DrawSprite(star3);
            }
            else if(winStar == 1)
            {                
                SwinGame.DrawSprite(star4);
                SwinGame.DrawSprite(star2);
                SwinGame.DrawSprite(star3);
            }
            else if(winStar == 2)
            {
                SwinGame.DrawSprite(star4);
                SwinGame.DrawSprite(star5);
                SwinGame.DrawSprite(star3);
            }
            else if(winStar == 3)
            {
                SwinGame.DrawSprite(star4);
                SwinGame.DrawSprite(star5);
                SwinGame.DrawSprite(star6);
            }
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
