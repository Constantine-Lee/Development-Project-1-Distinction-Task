using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
    public class MediumMode : View
    {
        private ServingArea _servingArea;
        private EasyModeSideBar _sideBar;
        private BottomBar _btmBar;
        private Button _giveUpButton;

        private Timer _gameTime;
        private uint _ticks;
        private StatusBar _statusBar;

        public MediumMode(ViewManager viewManager) : base(viewManager)
        {
            _sideBar = new EasyModeSideBar(_viewManager);
            _servingArea = new ServingArea();
            
            _btmBar = new BottomBar();

            _giveUpButton = new Button("blue_button07.png");
            _giveUpButton.SetWidth(80);
            _giveUpButton.SetHeight(80);
            _giveUpButton.SetText("Exit", 35);

            //Register for Observer Pattern
            foreach (DiningTable diningTable in _servingArea.DiningTable)
            {
                diningTable.RegisterSideBar(_sideBar);
            }
            _btmBar.RegisterStove(_servingArea.Stoves);
            _servingArea.Player.RegisterHoldingFrame(_sideBar.HoldingFoodFrame);
            //

            //initiate _gameTime
            _gameTime = SwinGame.CreateTimer();
            SwinGame.StartTimer(_gameTime);

            //initiate new BlUE status bar
            _statusBar = new StatusBar("Border_1.png");
            _statusBar.SetFillingImage("Health_1.png");
            //
        }

        public void SetSpeed()
        {
            DiningTable.sSPEED = 50;
        }

        public override void Draw()
        {
            _servingArea.Draw();
            _sideBar.Draw();
            _btmBar.Draw();
            _giveUpButton.Draw();
            SwinGame.DrawText("Medium", Color.Black, "Arial", 15, 370, 10);
            SwinGame.DrawText("Difficult", Color.Black, "Arial", 15, 440, 50);
            //draw the part of full bar based on the time passed. 
            _statusBar.Draw((int)_ticks, 365, 20);
        }

        public override void Update()
        {
            _servingArea.Update();
        }

        public override void ProcessEvent()
        {
            _btmBar.ProcessEvent();
            _servingArea.ProcessEvent();
            _sideBar.ProcessEvent();

            // get the ticks from time passed
            _ticks = SwinGame.TimerTicks(_gameTime) / 100;

            //change view to end if give up button clicked
            if (SwinGame.MouseClicked(MouseButton.LeftButton))
            {
                if (_giveUpButton.IsAt(SwinGame.MousePosition()))
                {
                    _viewManager.View = _viewManager.End;
                }
            }
        }

        // x = 0
        public void SetX(int x)
        {
            _servingArea.SetX(x);
            _btmBar.SetX(x + 10);
            _giveUpButton.SetX(x + 400);
            _giveUpButton.SetTextPositionX(x + 410);
            _sideBar.SetX(x + 350);

            _statusBar.SetX(x + 370);
        }

        // x = 0
        public void SetY(int y)
        {
            _servingArea.SetY(y);
            _btmBar.SetY(y + 280);
            _giveUpButton.SetY(y + 295);
            _giveUpButton.SetTextPositionY(y + 310);

            _statusBar.SetY(y + 30);
        }

    }
}