using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
	public class ServingArea
	{
		private Timer _gameTime;

		private EnergyBall _energyPotion;

		private Sprite _sky;
		private Sprite _floor;
		private Sprite _dustbin;

		private Player _player;

		private TableOfStove [] _tableOfStoves;
		private DiningTable [] _diningTables;

		private DiningTableManager _diningTableManager;
		private StoveManager _stoveManager;

		Stove [] _stove;

		private static Random _random = new Random ();

		public ServingArea ()
		{
			_gameTime = SwinGame.CreateTimer ();

			// Random the first energy potion
			_energyPotion = new EnergyBall ();
			_energyPotion.SetX (_random.Next (10, 340));
			_energyPotion.SetY (_random.Next (115, 190));
			//

			// STOVE
			//2 table of stove
			_tableOfStoves = new TableOfStove [2];
			_tableOfStoves [0] = new TableOfStove ();
			_tableOfStoves [1] = new TableOfStove ();
			//
			//2 stove and bind corresponding table to it 
			_stove = new Stove [2];
			_stove [0] = new Stove (_tableOfStoves [0]);
			_stove [1] = new Stove (_tableOfStoves [1]);

			_stoveManager = new StoveManager (_stove);
			//

			// 4 Dining Tables
			_diningTables = new WoodenTable [4];
			for (int i = 0; i < 4; i++) {
				_diningTables [i] = new WoodenTable ();
			}
			_diningTableManager = new DiningTableManager (_diningTables);
			//

			// 
			SwinGame.LoadBitmapNamed ("floor", "white_floor.jpg");
			_floor = SwinGame.CreateSprite (SwinGame.BitmapNamed ("floor"));
			//

			//
			SwinGame.LoadBitmapNamed ("sky", "sky_background.jpg");
			_sky = SwinGame.CreateSprite (SwinGame.BitmapNamed ("sky"));
			//

			//
			SwinGame.LoadBitmapNamed ("sink", "Dustbin.png");
			_dustbin = SwinGame.CreateSprite (SwinGame.BitmapNamed ("sink"));
			//

			_player = new Player ();
			_player.SetX (140);
			_player.SetY (120);
		}

		//x = 0
		public void SetX (int x)
		{


			_diningTableManager.SetX (x + 5);
			SwinGame.SpriteSetX (_floor, x - 5);
			_stoveManager.SetX (x);
			SwinGame.SpriteSetX (_dustbin, x + 275);
		}

		// y = 0
		public void SetY (int y)
		{
			_diningTableManager.SetY (85);
			SwinGame.SpriteSetY (_floor, y + 85);
			_stoveManager.SetY (y + 225);
			SwinGame.SpriteSetY (_dustbin, y + 210);
		}

		public Stove [] Stoves {
			get { return _stove; }
			set { _stove = value; }
		}

		public Player Player {
			get { return _player; }
			set { _player = value; }
		}

		public DiningTable [] DiningTable {
			get { return _diningTables; }
			set { _diningTables = value; }
		}

		public void Draw ()
		{
			//draw background
			SwinGame.DrawSprite (_sky);
			SwinGame.DrawSprite (_floor);
			//

			//
			SwinGame.DrawSprite (_dustbin);
			_diningTableManager.Draw ();
			_player.Draw ();
			_stoveManager.Draw ();
			_energyPotion.Draw ();
			//
		}

		public void Update ()
		{
			_player.Update ();
		}

		public void ProcessEvent ()
		{
			_player.ProcessEvent ();
			_stoveManager.ProcessEvent ();
			_diningTableManager.ProcessEvent ();
			CheckCollision ();
		}

		public void CheckCollision ()
		{
			//check collision between table of stove and player. If collision happen, give the player the food if food exist. 
			foreach (TableOfStove tableOfStove in _tableOfStoves) {
				if (SwinGame.SpriteCollision (_player.PlayerSprite, tableOfStove.FoodSprite) && (_player.HoldingFoodName == "")) {
					SwinGame.DrawText ("small_" + _player.HoldingFoodName, Color.Black, 10, 10);
					if (tableOfStove.FoodName == "small_BlueCandy.png") {
						_player.SetFood ("BlueCandy.png");
					} else if (tableOfStove.FoodName == "small_GreenCandy.png") {
						_player.SetFood ("GreenCandy.png");
					} else if (tableOfStove.FoodName == "small_RedCandy.png") {
						_player.SetFood ("RedCandy.png");
					}
					tableOfStove.SetFood ("");
				}
			}

			//check collision between dining table and player. If the wish food match with the food hold by player, give the food to the customer. 
			foreach (DiningTable diningTable in _diningTables) {
				if (SwinGame.SpriteCollision (_player.PlayerSprite, diningTable.Customer.CustomerSprite)) {
					if (("small_" + _player.HoldingFoodName) == diningTable.Customer.WishName) {
						diningTable.SetFood (diningTable.Customer.WishName);
						diningTable.Waiting = false;
						diningTable.Customer.WishName = "";
						_player.SetFood ("");
					}
				}
			}

			//check collision between energy ball and player. Refill energy if collision happen.
			if (SwinGame.SpriteCollision (_energyPotion.EnergyPotionSprite, _player.PlayerSprite) && (_energyPotion.EnergyImage == "ball.png")) {
				_player.Movement.Ticks += 30;
				_energyPotion.ResetEnergyBall ();
				SwinGame.StartTimer (_gameTime);
			}

			//If no energy ball exist then generate new energy ball after 5 second 
			if ((SwinGame.TimerTicks (_gameTime) / 1000) > 5) {
				_energyPotion.NewEnergyBall ();
				_energyPotion.ResetEnergyBallPosition ();
				SwinGame.StopTimer (_gameTime);
			}

			//throw away holding food if collide with dustbin. 
			if (SwinGame.SpriteCollision (_player.PlayerSprite, _dustbin)) {
				_player.SetFood ("");
			}
	}
	}}
