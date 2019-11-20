using System;
using SwinGameSDK;

namespace MyGame
{
	public class BS_Customer
	{
		private Sprite _customer;
		private BS_Wish _wish;

		public BS_Customer (string image)
		{
			//customer sprite
			SwinGame.LoadBitmapNamed (image, image);
			_customer = SwinGame.CreateSprite (SwinGame.BitmapNamed (image));
			//
			//get new wish from Wish Generator
			_wish = BS_WishGenerator.NewWish ();
		}

		//c1 = 25, c2 = 110, c3 = 195, c4 = 280
		public void SetX (float x)
		{
			_wish.SetX (x);
			SwinGame.SpriteSetX (_customer, x);
		}

		//c = 45
		public void SetY (float y)
		{
			_wish.SetY (y);
			SwinGame.SpriteSetY (_customer, y);
		}


		public Sprite CustomerSprite {
			get { return _customer; }
			set { _customer = value; }
		}

		public string WishName {
			get { return _wish.WishName; }
			set { _wish.WishName = value; }
		}

		public void Draw ()
		{
			SwinGame.DrawSprite (_customer);
			_wish.Draw ();
		}
	}
}
