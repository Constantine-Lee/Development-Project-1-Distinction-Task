using System;
using SwinGameSDK;

namespace MyGame
{
	public class ZYButton
	{
		private int _width, _height, _textPosX, _textPosY;

		private Sprite _button;
		public bool Selected;
		private string _text;
		private int _size;

		public ZYButton (string buttonImage)
		{
			SwinGame.LoadBitmapNamed(buttonImage, buttonImage);
			_button = SwinGame.CreateSprite (SwinGame.BitmapNamed (buttonImage));
		}

		public Boolean SetX (int x)
		{
            try
            {
                SwinGame.SpriteSetX(_button, x);
                return true;
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
		}

		public Boolean SetY (int y)
		{
            try
            {
                SwinGame.SpriteSetY(_button, y);
                return true;
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
		}

		public Boolean SetWidth (int width)
		{
            try
            {
                _width = width;
                return true;
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
		}

		public Boolean SetHeight (int height)
		{
            try {
                _height = height;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
			
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
