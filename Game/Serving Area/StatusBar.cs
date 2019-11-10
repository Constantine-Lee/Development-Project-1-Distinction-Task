using System;
using SwinGameSDK;

namespace MyGame
{
	public class StatusBar
	{
		private Bitmap _fullBar;
		private Rectangle _partRect;
		private Sprite _statusBar;

		public StatusBar (string emptyBar)
		{
			SwinGame.LoadBitmapNamed (emptyBar, emptyBar);
			_statusBar = SwinGame.CreateSprite (SwinGame.BitmapNamed (emptyBar));
		}

		public Sprite StatusBarSprite {
			get {return _statusBar;}
			set {_statusBar = value;}
		}

		public void SetX (float x)
		{	
			SwinGame.SpriteSetX (_statusBar, x);
		}

		public void SetY (float y)
		{
			SwinGame.SpriteSetY (_statusBar, y);
		}

		public void SetFillingImage (string fillingImage)
		{
			_fullBar = SwinGame.LoadBitmapNamed (fillingImage, fillingImage);
		}

		public void Draw (int ticks, float x, float y)
		{
			SetX (x);
			SetY (y);
			SwinGame.DrawSprite (_statusBar);
			_partRect = SwinGame.RectangleFrom (0, 0, ticks, 128);
			SwinGame.DrawBitmapPart (_fullBar, _partRect, x, y);
		}
	}
}
