using System;
using SwinGameSDK;

namespace MyGame
{
	public class Wish
	{
		private Sprite _wishBackground;
		private Sprite _wishFood;
		private string _wishName;
		private Sprite _love;

		public Wish (string wishName)
		{
			//to show gratitude
			SwinGame.LoadBitmapNamed ("love", "love.png");
			_love = SwinGame.CreateSprite (SwinGame.BitmapNamed ("love"));
			//

			//wish background
			SwinGame.LoadBitmapNamed ("wish", "wish.png");
			_wishBackground = SwinGame.CreateSprite (SwinGame.BitmapNamed ("wish"));
			//

			//record the wish image name then create the wish food
			_wishName = wishName;
			SwinGame.LoadBitmapNamed (wishName, wishName);
			_wishFood = SwinGame.CreateSprite (SwinGame.BitmapNamed (wishName));
			//
		}

		//b1 = 15, b2 = 10, b3 = 185, b4 = 270
		//f1 = 19, f2 = 104, f3 = 189, f4 = 274
		//l1 = 22, l2 = 107, l3 = 192, l4 = 277
		public void SetX (float x)
		{
			SwinGame.SpriteSetX (_wishBackground, x-10);
			SwinGame.SpriteSetX (_wishFood, x -6);
			SwinGame.SpriteSetX (_love, x -3);
		}

		//b = 5
		//f = 12
		//l = 0
		public void SetY (float y)
		{
			SwinGame.SpriteSetY (_wishBackground, y-40);
			SwinGame.SpriteSetY (_wishFood, y -33);
			SwinGame.SpriteSetY (_love, y - 45);
		}

		public string WishName {
			get { return _wishName; }
			set { _wishName = value; }
		}

		public void Draw ()
		{
			if (_wishName != "") {
				SwinGame.DrawSprite (_wishBackground);
				SwinGame.DrawSprite (_wishFood);
			} else SwinGame.DrawSprite (_love);
		}

	}
}
