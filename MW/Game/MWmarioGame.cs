using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
    public class MWmarioGame : View
    {
        /*
        private MWMarioServingArea _marioservingArea;
        private MWSideBarMarioUpdate _mariosideBar;
        private MWBottomBar _mariobtmBar;
        private MWButton _mariogiveUpButton;
        */
        public MWmarioGame(ViewManager viewManager)
            : base(viewManager)
        {
            /*
            _mariosideBar = new MWSideBarMarioUpdate(_viewManager);
            _marioservingArea = new MWMarioServingArea();
            _mariobtmBar = new MWBottomBar();

            _mariogiveUpButton = new MWButton("blue_button07.png");
            _mariogiveUpButton.SetWidth(80);
            _mariogiveUpButton.SetHeight(80);
            _mariogiveUpButton.SetText("Exit", 35);

            //Register for Observer Pattern
            foreach (MWMarioDiningTable diningTable in _marioservingArea.DiningTable)
            {
                diningTable.RegisterSideBar(_mariosideBar);
            }
            _mariobtmBar.RegisterStove(_marioservingArea.Stoves);
            _marioservingArea.Player.RegisterHoldingFrame(_mariosideBar.HoldingFoodFrame);
            //
            */
        }

        /*
        public override void Draw()
        {
            _marioservingArea.Draw();
            _mariosideBar.Draw();
            _mariobtmBar.Draw();
            _mariogiveUpButton.Draw();
        }

        public override void Update()
        {
            _marioservingArea.Update();
        }

        public override void ProcessEvent()
        {
            _mariobtmBar.ProcessEvent();
            _marioservingArea.ProcessEvent();
            _mariosideBar.ProcessEvent();

            if (SwinGame.KeyTyped(KeyCode.vk_F12))
            {
                SwinGame.ToggleFullScreen();
            }
            //change view to end if give up button clicked
            if (SwinGame.MouseClicked(MouseButton.LeftButton))
            {
                if (_mariogiveUpButton.IsAt(SwinGame.MousePosition()))
                {
                    _viewManager.View = _viewManager.MWMarioEnd;
                }
            }
        }

        // x = 0
        public void SetX(int x)
        {
            _marioservingArea.SetX(x);
            _mariobtmBar.SetX(x + 10);
            _mariogiveUpButton.SetX(x + 400);
            _mariogiveUpButton.SetTextPositionX(x + 410);
            _mariosideBar.SetX(x + 350);
        }

        // x = 0
        public void SetY(int y)
        {
            _marioservingArea.SetY(y);
            _mariobtmBar.SetY(y + 280);
            _mariogiveUpButton.SetY(y + 295);
            _mariogiveUpButton.SetTextPositionY(y + 310);
        }
        */
    }
}
