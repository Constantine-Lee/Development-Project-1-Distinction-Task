using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
    public class ZYDifficultMode : View
    {
        private ZYServingAreaDifficult _servingArea;
        private ZYSideBar _sideBar;
        private ZYBottomBar _btmBar;
        private ZYButton _giveUpButton;

        private ZYStatusBar _statusBar;


        public ZYDifficultMode(ViewManager viewManager) : base(viewManager)
        {
            _sideBar = new ZYSideBar(_viewManager);
            _servingArea = new ZYServingAreaDifficult();

            _btmBar = new ZYBottomBar();

            _giveUpButton = new ZYButton("blue_button07.png");
            _giveUpButton.SetWidth(80);
            _giveUpButton.SetHeight(80);
            _giveUpButton.SetText("Exit", 35);

            //Register for Observer Pattern
            foreach (ZYDiningTable diningTable in _servingArea.DiningTable)
            {
                diningTable.RegisterSideBar(_sideBar);
            }
            _btmBar.RegisterStove(_servingArea.Stoves);
            _servingArea.Player.RegisterHoldingFrame(_sideBar.HoldingFoodFrame);
            //

            //initiate new BlUE status bar
            _statusBar = new ZYStatusBar("blackprogressbar.png");
            _statusBar.SetFillingImage("blueprogressbar.png");
            //
        }

        public void SetSpeed()
        {
            ZYDiningTable.sSPEED = 300;
        }

        public override void Draw()
        {
            _servingArea.Draw();
            _sideBar.Draw();
            _btmBar.Draw();
            _giveUpButton.Draw();

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

            //change view to end if give up button clicked
            if (SwinGame.MouseClicked(MouseButton.LeftButton))
            {
                if (_giveUpButton.IsAt(SwinGame.MousePosition()))
                {
                    _viewManager.View = _viewManager.ZYEnd;
                }
            }

            if (ZYSideBar.winStar == 4)
            {
                ZYEnd.winOrLose = true;
                SwinGame.LoadSoundEffect("victory.wav");
                SwinGame.PlaySoundEffect("victory.wav");
                _viewManager.View = _viewManager.ZYEnd;
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