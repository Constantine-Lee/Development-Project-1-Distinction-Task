using System;
using SwinGameSDK;

namespace MyGame
{
	public class Button
	{
		private int _width, _height, _textPosX, _textPosY;

		private Sprite _button;
		public bool Selected;
		private string _text;
		private int _size;

		public Button (string buttonImage)
		{
			SwinGame.LoadBitmapNamed(buttonImage, buttonImage);
			_button = SwinGame.CreateSprite (SwinGame.BitmapNamed (buttonImage));
		}

		public void SetX (int x)
		{

			SwinGame.SpriteSetX (_button, x);
		}

		public void SetY (int y)
		{

			SwinGame.SpriteSetY (_button, y);
		}

		public void SetWidth (int width)
		{
			_width = width;
		}

		public void SetHeight (int height)
		{
			_height = height;
		}

		public void SetText (string text, int size)
		{
			_text = text;
			_size = size;
		}

		public void SetTextPositionX (int x)
		{
			_textPosX = x;
		}

		public void SetTextPositionY (int y)
		{
			_textPosY = y;
		}


		public bool IsAt (Point2D pt)
		{
			if (SwinGame.PointInRect (pt, _button.X, _button.Y, _width, _height)) {
				return true;
			} else {
				return false;
			}
		}

		public void Draw ()
		{
			SwinGame.DrawSprite (_button);
			SwinGame.DrawText (_text, Color.Black, "Arial", _size, _textPosX, _textPosY);
		}

	}
}
