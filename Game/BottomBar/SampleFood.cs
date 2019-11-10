using System;
using SwinGameSDK;

namespace MyGame
{
	public class SampleFood
	{
		private int _width, _height;
		private string _foodImage;
		private Sprite _food;
		private bool _selected;

		public SampleFood (string foodImage)
		{
			_width = 88;
			_height = 48;

			//food image
			_foodImage = foodImage;
			SwinGame.LoadBitmapNamed (_foodImage, _foodImage);
			_food = SwinGame.CreateSprite (SwinGame.BitmapNamed (_foodImage));
			//
		}

		// x1 = 10, x2 = 130, x3 = 250
		public void SetX (int x)
		{
			SwinGame.SpriteSetX (_food, x);
		}

		// sampleFood = 310
		public void SetY (int y)
		{
			SwinGame.SpriteSetY (_food, y);
		}

		public bool Selected {
			get { return _selected; }
			set { _selected = value; }
		}

		public bool IsAt (Point2D pt)
		{
			if (SwinGame.PointInRect (pt, _food.X, _food.Y, _width, _height)) {
				return true;
			}
			return false;
		}

		public void Draw ()
		{
			SwinGame.DrawSprite (_food);
		}

		public string Image {
			get { return _foodImage; }
			set { _foodImage = value; }
		}
	}
}
