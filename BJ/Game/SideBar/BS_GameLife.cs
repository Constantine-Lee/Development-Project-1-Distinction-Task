using System;
using SwinGameSDK;

namespace MyGame
{
	public class BS_GameLife
	{
		private Bitmap _fullBar;
		private Rectangle _partRect;
		private int _width;

		public BS_GameLife ()
		{
			_width = 100;
			SwinGame.LoadBitmapNamed ("EmptyHeart.png", "EmptyHeart.png");
			_fullBar = SwinGame.LoadBitmapNamed ("FullHeart.png", "FullHeart.png");
		}

		public int Width {
			get {return _width;}
			set {_width = value;}
		}

		public void Draw ()
		{
			SwinGame.DrawBitmap ("EmptyHeart.png", 378, 80);
			_partRect = SwinGame.RectangleFrom (0, 0, _width, 180);
			SwinGame.DrawBitmapPart (_fullBar, _partRect, 378, 80);
		}
	}
}
