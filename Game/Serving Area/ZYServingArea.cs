﻿using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
	public class ZYServingArea
	{
		private Timer _gameTime;
        private Timer _soundTime;
		private ZYEnergyBall _energyPotion;
        private Boolean[] hits = new Boolean[4];
        private Boolean[] notCorrects = new Boolean[4];        

		private Sprite _sky;
		private Sprite _floor;
		private Sprite _dustbin;

		private ZYEasyPlayer _player;

		private ZYTableOfStove [] _tableOfStoves;
		private ZYDiningTable [] _diningTables;

		private ZYDiningTableManager _diningTableManager;
		private ZYStoveManager _stoveManager;

		ZYStove [] _stove;

		private static Random _random = new Random ();

		public ZYServingArea ()
		{
			_gameTime = SwinGame.CreateTimer ();
            _soundTime = SwinGame.CreateTimer();
			// Random the first energy potion
			_energyPotion = new ZYEnergyBall ();
			_energyPotion.SetX (_random.Next (10, 340));
			_energyPotion.SetY (_random.Next (115, 190));
            //

            SwinGame.StartTimer(_soundTime);
			// STOVE
			//2 table of stove
			_tableOfStoves = new ZYTableOfStove [2];
			_tableOfStoves [0] = new ZYTableOfStove ();
			_tableOfStoves [1] = new ZYTableOfStove ();
			//
			//2 stove and bind corresponding table to it 
			_stove = new ZYStove [2];
			_stove [0] = new ZYStove (_tableOfStoves [0]);
			_stove [1] = new ZYStove (_tableOfStoves [1]);

			_stoveManager = new ZYStoveManager (_stove);
			//

			// 4 Dining Tables
			_diningTables = new ZYWoodenTable [4];
			for (int i = 0; i < 4; i++) {
				_diningTables [i] = new ZYWoodenTable ();
			}
			_diningTableManager = new ZYDiningTableManager (_diningTables);
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

			_player = new ZYEasyPlayer ();
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

		public ZYStove [] Stoves {
			get { return _stove; }
			set { _stove = value; }
		}

		public ZYEasyPlayer Player {
			get { return _player; }
			set { _player = value; }
		}

		public ZYDiningTable [] DiningTable {
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
			foreach (ZYTableOfStove tableOfStove in _tableOfStoves) {
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
			for (int k = 0; k<_diningTables.Length; k++) {
				if (SwinGame.SpriteCollision (_player.PlayerSprite, _diningTables[k].Customer.CustomerSprite)) {
                    hits[k] = true;
                    notCorrects[k] = false;
					if (("small_" + _player.HoldingFoodName) == _diningTables[k].Customer.WishName) {                       
                        SwinGame.LoadSoundEffect("success.wav");
                        SwinGame.PlaySoundEffect("success.wav");
                        _diningTables[k].SetFood (_diningTables[k].Customer.WishName);
                        _diningTables[k].Ticks = 41;
                        _diningTables[k].Waiting = false;
                        _diningTables[k].Customer.WishName = "";
						_player.SetFood ("");
                       
					}
                    else 
                    {
                        if (_player.HoldingFoodName == "")
                        {

                        }
                        else
                        {                            
                            if ((SwinGame.TimerTicks(_soundTime) / 1000) > 3)
                            {
                                SwinGame.LoadSoundEffect("wrong.wav");
                                SwinGame.PlaySoundEffect("wrong.wav");
                                SwinGame.ResetTimer(_soundTime);
                            }
                        }
                        notCorrects[k] = true;
                    }
				}
                else
                {
                    hits[k] = false;
                    notCorrects[k] = false;
                }
			}

           /* for(int i = 0; i<hits.Length; i++)
            {
                if (hits[i] == true)
                {
                    if (notCorrects[i] == true)
                    {
                        if ((SwinGame.TimerTicks(_soundTime) / 1000) > 2)
                        {
                            SwinGame.LoadSoundEffect("error.wav");
                            SwinGame.PlaySoundEffect("error.wav");

                        }
                    }
                }
            }*/

			//check collision between energy ball and player. Refill energy if collision happen.
			if (SwinGame.SpriteCollision (_energyPotion.EnergyPotionSprite, _player.PlayerSprite) && (_energyPotion.EnergyImage == "ball.png")) {
                _player.SetFillingImage("normalEmoji.png");
				_energyPotion.ResetEnergyBall ();
				SwinGame.StartTimer (_gameTime);
                SwinGame.LoadSoundEffect("chargeEnergy.wav");
                SwinGame.PlaySoundEffect("chargeEnergy.wav");
            }

			//If no energy ball exist then generate new energy ball after 5 second 
			if ((SwinGame.TimerTicks (_gameTime) / 1000) > 5) {
				_energyPotion.NewEnergyBall ();
				_energyPotion.ResetEnergyBallPosition ();
				SwinGame.StopTimer (_gameTime);
			}

			//throw away holding food if collide with dustbin. 
			if (SwinGame.SpriteCollision (_player.PlayerSprite, _dustbin)) {
                if (_player.HoldingFoodName != "")
                {
                    SwinGame.LoadSoundEffect("drop.wav");
                    SwinGame.PlaySoundEffect("drop.wav");
                }
				_player.SetFood ("");
			}
	}
	}}
