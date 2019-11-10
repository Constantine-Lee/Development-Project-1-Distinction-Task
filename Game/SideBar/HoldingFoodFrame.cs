using System;
using SwinGameSDK;

namespace MyGame
{
	public class HoldingFoodFrame
	{
		private Sprite _frame;
		private Sprite _holdingFood;
		private string _foodName;

		public HoldingFoodFrame ()
		{
			SwinGame.LoadBitmapNamed ("frame", "frame.png");
			_frame = SwinGame.CreateSprite (SwinGame.BitmapNamed ("frame"));

			SwinGame.SpriteSetX (_frame, 362);
			SwinGame.SpriteSetY (_frame, 140);

			_foodName = "";
			SwinGame.LoadBitmapNamed (_foodName, _foodName);
			_holdingFood = SwinGame.CreateSprite (SwinGame.BitmapNamed (_foodName));

			SwinGame.SpriteSetX (_holdingFood, 384);
			SwinGame.SpriteSetY (_holdingFood, 178);
		}

		public void Draw ()
		{
			SwinGame.DrawSprite (_frame);
			SwinGame.DrawSprite (_holdingFood);
		}

		public void SetFood (string foodName)
		{
			_foodName = foodName;
			SwinGame.LoadBitmapNamed (foodName, foodName);
			_holdingFood = SwinGame.CreateSprite (SwinGame.BitmapNamed (foodName));
			SwinGame.SpriteSetX (_holdingFood, 383);
			SwinGame.SpriteSetY (_holdingFood, 178);
		}
	}
}
