using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
    public class MWMarioServingArea
    {
        private Timer _mariogameTime;

        private MWEnergyBall _marioenergyPotion;

        private Sprite _mariosky;
        private Sprite _mariofloor;
        private Sprite _mariodustbin;

        private MWPlayer _marioplayer;

        private TableOfStove[] _mariotableOfStoves;
        private MWMarioDiningTable[] _mariodiningTables;

        private MWMarioDiningTableManager _mariodiningTableManager;
        private StoveManager _mariostoveManager;

        Stove[] _mariostove;

        private static Random _mariorandom = new Random();

        public MWMarioServingArea()
        {
            _mariogameTime = SwinGame.CreateTimer();

            // Random the first energy potion
            _marioenergyPotion = new MWEnergyBall();
            _marioenergyPotion.SetX(_mariorandom.Next(10, 340));
            _marioenergyPotion.SetY(_mariorandom.Next(115, 190));
            //

            // STOVE
            //2 table of stove
            _mariotableOfStoves = new TableOfStove[2];
            _mariotableOfStoves[0] = new TableOfStove();
            _mariotableOfStoves[1] = new TableOfStove();
            //
            //2 stove and bind corresponding table to it 
            _mariostove = new Stove[2];
            _mariostove[0] = new Stove(_mariotableOfStoves[0]);
            _mariostove[1] = new Stove(_mariotableOfStoves[1]);

            _mariostoveManager = new StoveManager(_mariostove);
            //

            // 4 Dining Tables
            _mariodiningTables = new MWMarioWoodenTable[4];
            for (int i = 0; i < 4; i++)
            {
                _mariodiningTables[i] = new MWMarioWoodenTable();
            }
            _mariodiningTableManager = new MWMarioDiningTableManager(_mariodiningTables);
            //

            // 
            SwinGame.LoadBitmapNamed("floor", "white_floor.jpg");
            _mariofloor = SwinGame.CreateSprite(SwinGame.BitmapNamed("floor"));
            //

            //
            SwinGame.LoadBitmapNamed("sky", "sky_background.jpg");
            _mariosky = SwinGame.CreateSprite(SwinGame.BitmapNamed("sky"));
            //

            //
            SwinGame.LoadBitmapNamed("sink", "Dustbin.png");
            _mariodustbin = SwinGame.CreateSprite(SwinGame.BitmapNamed("sink"));
            //

            _marioplayer = new MWPlayer();
            _marioplayer.SetX(140);
            _marioplayer.SetY(120);
        }

        //x = 0
        public void SetX(int x)
        {


            _mariodiningTableManager.SetX(x + 5);
            SwinGame.SpriteSetX(_mariofloor, x - 5);
            _mariostoveManager.SetX(x);
            SwinGame.SpriteSetX(_mariodustbin, x + 275);
        }

        // y = 0
        public void SetY(int y)
        {
            _mariodiningTableManager.SetY(85);
            SwinGame.SpriteSetY(_mariofloor, y + 85);
            _mariostoveManager.SetY(y + 225);
            SwinGame.SpriteSetY(_mariodustbin, y + 210);
        }

        public Stove[] Stoves
        {
            get { return _mariostove; }
            set { _mariostove = value; }
        }

        public MWPlayer Player
        {
            get { return _marioplayer; }
            set { _marioplayer = value; }
        }

        public MWMarioDiningTable[] DiningTable
        {
            get { return _mariodiningTables; }
            set { _mariodiningTables = value; }
        }

        public void Draw()
        {
            //draw background
            SwinGame.DrawSprite(_mariosky);
            SwinGame.DrawSprite(_mariofloor);
            //

            //
            SwinGame.DrawSprite(_mariodustbin);
            _mariodiningTableManager.Draw();
            _marioplayer.Draw();
            _mariostoveManager.Draw();
            _marioenergyPotion.Draw();
            //
        }

        public void Update()
        {
            _marioplayer.Update();
        }

        public void ProcessEvent()
        {
            _marioplayer.ProcessEvent();
            _mariostoveManager.ProcessEvent();
            _mariodiningTableManager.ProcessEvent();
            CheckCollision();
        }

        public void CheckCollision()
        {
            //check collision between table of stove and player. If collision happen, give the player the food if food exist. 
            foreach (TableOfStove tableOfStove in _mariotableOfStoves)
            {
                if (SwinGame.SpriteCollision(_marioplayer.PlayerSprite, tableOfStove.FoodSprite) && (_marioplayer.HoldingFoodName == ""))
                {
                    SwinGame.DrawText("small_" + _marioplayer.HoldingFoodName, Color.Black, 10, 10);
                    if (tableOfStove.FoodName == "small_BlueCandy.png")
                    {
                        _marioplayer.SetFood("BlueCandy.png");
                    }
                    else if (tableOfStove.FoodName == "small_GreenCandy.png")
                    {
                        _marioplayer.SetFood("GreenCandy.png");
                    }
                    else if (tableOfStove.FoodName == "small_RedCandy.png")
                    {
                        _marioplayer.SetFood("RedCandy.png");
                    }
                    tableOfStove.SetFood("");
                }
            }

            //check collision between dining table and player. If the wish food match with the food hold by player, give the food to the customer. 
            foreach (MWMarioDiningTable diningTable in _mariodiningTables)
            {
                if (SwinGame.SpriteCollision(_marioplayer.PlayerSprite, diningTable.Customer.CustomerSprite))
                {
                    if (("small_" + _marioplayer.HoldingFoodName) == diningTable.Customer.WishName)
                    {
                        diningTable.MarioSetFood(diningTable.Customer.WishName);
                        diningTable.Waiting = false;
                        diningTable.Customer.WishName = "";
                        _marioplayer.SetFood("");
                        diningTable.AddScore();
                    }
                }
            }

            //check collision between energy ball and player. Refill energy if collision happen.
            if (SwinGame.SpriteCollision(_marioenergyPotion.EnergyPotionSprite, _marioplayer.PlayerSprite) && (_marioenergyPotion.EnergyImage == "ball.png"))
            {
                _marioplayer.Movement.Ticks += 30;
                _marioenergyPotion.ResetEnergyBall();
                SwinGame.StartTimer(_mariogameTime);
            }

            //If no energy ball exist then generate new energy ball after 5 second 
            if ((SwinGame.TimerTicks(_mariogameTime) / 1000) > 5)
            {
                _marioenergyPotion.NewEnergyBall();
                _marioenergyPotion.ResetEnergyBallPosition();
                SwinGame.StopTimer(_mariogameTime);
            }

            //throw away holding food if collide with dustbin. 
            if (SwinGame.SpriteCollision(_marioplayer.PlayerSprite, _mariodustbin))
            {
                _marioplayer.SetFood("");
            }
        }
    }
}
