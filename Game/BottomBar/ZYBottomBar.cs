using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
	public class ZYBottomBar
	{
		private Sprite _bottomBarBackground;
		private ZYSampleFood [] _sampleFood;
		private string _selection;
		private List<ZYStove> _stove;

		public ZYBottomBar ()
		{
			//make the initial selection to NULL
			_selection = "";

			//for observer pattern 
			_stove = new List<ZYStove> ();

			//Background
			SwinGame.LoadBitmapNamed ("btm_background", "btm_background.jpg");
			_bottomBarBackground = SwinGame.CreateSprite (SwinGame.BitmapNamed ("btm_background"));
			//

			//initialize 4 sample food
			_sampleFood = new ZYSampleFood [3];
			_sampleFood[0] = new ZYSampleFood ("BlueCandy.png");
			_sampleFood [1] = new ZYSampleFood ("GreenCandy.png");
			_sampleFood [2] = new ZYSampleFood ("RedCandy.png");
			//
		}

		// x1 = 10, x2 = 130, x3 = 250
		public void SetX (int x)
		{
			for (int i = 0, x_axis = x; i < 3; i++, x_axis += 120) {
				_sampleFood [i].SetX (x_axis);
			}
		}

		// y = 280 , sampleFood = 310
		public void SetY (int y)
		{
			SwinGame.SpriteSetY (_bottomBarBackground, y);
			for (int i = 0, y_axis = y+30; i < 3; i++) {
				_sampleFood [i].SetY (y_axis);
			}
		}

		public void Draw ()
		{
			SwinGame.DrawSprite (_bottomBarBackground);
			foreach (ZYSampleFood sampleFood in _sampleFood) {
				sampleFood.Draw ();
			}		
		}

		public string SelectFoodAt (Point2D pt)
		{
			//check through sampleFood 
			foreach (ZYSampleFood sampleFood in _sampleFood) {
				if (sampleFood.IsAt (pt)) {
					sampleFood.Selected = true;
					return sampleFood.Image;
				} else sampleFood.Selected = false;
			}
			return "";
		}

		public void ProcessEvent ()
		{
			//get selected food if clicked left button. 
			if (SwinGame.MouseClicked (MouseButton.LeftButton)) {
				_selection = SelectFoodAt (SwinGame.MousePosition ());
			}
			//first check is there a food selected. Prioritise the usage of stove 1 over stove 2. If there is already occupied by food, discard selection. 
			if (_selection != "") {
				if (_stove [1].Cooking == false && _stove [1].TableOfStove.FoodName =="") {
					_stove [1].SetFoodToCook (_selection);
				} else if (_stove [0].Cooking == false && _stove [0].TableOfStove.FoodName == "") {
					_stove [0].SetFoodToCook (_selection);
				} 
				_selection = "";
			}
		}

		public void RegisterStove (ZYStove[] stoveList)
		{
			foreach (ZYStove stove in stoveList) {
				_stove.Add (stove);
			}
		}
	}
}
