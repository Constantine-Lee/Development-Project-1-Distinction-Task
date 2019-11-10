 using System;
using SwinGameSDK;

namespace MyGame
{
	public class Stove
	{
		private Sprite _stove;
		private TableOfStove _tableOfStove;
		private StatusBar _statusBar;
		private Timer _gameTime;
		private uint _ticks;

		private string _foodToCook;
		private bool _cooking;

		public Stove (TableOfStove tableOfStove)
		{
			//set the food to cook to null and cooking state as false
			_foodToCook = "";
			_cooking = false;
			//

			//bind the table
			_tableOfStove = tableOfStove;

			//create the stove SPRITE
			SwinGame.LoadBitmapNamed ("stove", "stove.png");
			_stove = SwinGame.CreateSprite (SwinGame.BitmapNamed ("stove"));
			//

			//initiate _gameTime
			_gameTime = SwinGame.CreateTimer ();

			//initiate new BlUE status bar
			_statusBar = new StatusBar ("emptyThick.png");
			_statusBar.SetFillingImage ("blueThick.png");
			//
		}

		// x1 = 0, x2 = 105
		public void SetX (int x)
		{
			SwinGame.SpriteSetX (_stove, x);
			_tableOfStove.SetX (x);

			// s1 = 35, s2 = 140
			_statusBar.SetX (x + 35);
		}

		// y = 225
		public void SetY (int y)
		{
			SwinGame.SpriteSetY (_stove, y);
			_tableOfStove.SetY (y);

			// y = 232
			_statusBar.SetY (y + 7);
		}

		public bool Cooking {
			get {return _cooking;}
			set {_cooking = value;}
		}

		public TableOfStove TableOfStove {
			get {return _tableOfStove;}
			set {_tableOfStove = value;}
		}

		public void SetFoodToCook (string foodToCook)
		{
			_foodToCook = foodToCook;
		}

		public void Draw ()
		{
			//first draw table
			_tableOfStove.Draw ();

			//second draw the stove sprite
			SwinGame.DrawSprite (_stove);

			//draw the part of full bar based on the time passed. 
			_statusBar.Draw ((int)_ticks, _stove.X+35, _stove.Y+7);
		}

		public void ProcessEvent ()
		{
			// get the ticks from time passed
			_ticks = SwinGame.TimerTicks (_gameTime) / 100;

			//check to see is there food to cook
			if (_foodToCook != "") {
				//if the stove is not cooking
				if (!_cooking) {
					//then we start the timer and set the stove to cooking state
					SwinGame.StartTimer (_gameTime);
					_cooking = true;
				}
				//if the food is cooked
				if (_ticks > 40) {
					//put the food on the stove
					_tableOfStove.SetFood ("small_" + _foodToCook);
					//set the stove to NOT cooking state
					_cooking = false;
					//clear the food to cook
					_foodToCook = "";
					//stop the timer and thus make status bar go to empty state. 
					SwinGame.StopTimer (_gameTime);
				}
			}
		}
	}
}
