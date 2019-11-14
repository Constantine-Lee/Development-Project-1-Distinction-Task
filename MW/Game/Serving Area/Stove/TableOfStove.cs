using System;
using SwinGameSDK;

namespace MyGame
{
	public class TableOfStove
	{
		private Sprite _tableOfStove;
		private Sprite _food;
		private string _foodName;

		public TableOfStove ()
		{
			//set the initial food to null
			_foodName = "";
			SwinGame.LoadBitmapNamed (_foodName, _foodName);
			_food = SwinGame.CreateSprite (SwinGame.BitmapNamed (_foodName));
			//

			//Table SPRITE
			SwinGame.LoadBitmapNamed ("tablePixel", "table_pixel.png");
			_tableOfStove = SwinGame.CreateSprite (SwinGame.BitmapNamed ("tablePixel"));
			//
		}

		// food = 40, table = 15
		public void SetX (int x)
		{
			SwinGame.SpriteSetX (_tableOfStove, x + 15);
			SwinGame.SpriteSetX (_food, x + 40);
		}

		// food = 200, table = 210
		public void SetY (int y)
		{
			SwinGame.SpriteSetY (_tableOfStove, y - 15);
			SwinGame.SpriteSetY (_food, y - 25);
		}

		//Food SPRITE
		public Sprite FoodSprite {
			get { return _food; }
			set { _food = value; }
		}

		//food name
		public string FoodName {
			get {return _foodName;}
			set {_foodName = value;}
		}

		//Set the food by using food name
		public void SetFood (string foodName)
		{
			_foodName = foodName;
			SwinGame.LoadBitmapNamed (_foodName, _foodName);
			_food = SwinGame.CreateSprite (SwinGame.BitmapNamed (_foodName));
			SwinGame.SpriteSetX (_food, _tableOfStove.X+25);
			SwinGame.SpriteSetY (_food, _tableOfStove.Y-10);
		}

		public void Draw ()
		{
			SwinGame.DrawSprite (_tableOfStove);
			SwinGame.DrawSprite (_food);
		}


	}
}
