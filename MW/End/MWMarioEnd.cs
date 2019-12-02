using System;
using SwinGameSDK;

namespace MyGame
{
    public class MWMarioEnd : View
    {
        private string _marioimage;
        private MWButton _mariogotoMenuButton;
        private Sprite _mariomenu;

        public MWMarioEnd(ViewManager viewManager)
            : base(viewManager)
        {
            //background Image
            _marioimage = "game_over.jpg";
            SwinGame.LoadBitmapNamed(_marioimage, _marioimage);
            _mariomenu = SwinGame.CreateSprite(SwinGame.BitmapNamed(_marioimage));
            //

            //Go to menu
            _mariogotoMenuButton = new MWButton("grey_button06.png");
            _mariogotoMenuButton.SetWidth(191);
            _mariogotoMenuButton.SetHeight(49);
            _mariogotoMenuButton.SetText("-Back to Menu-", 25);
            //
        }

        public override void Draw()
        {
            SwinGame.DrawSprite(_mariomenu);
            SwinGame.DrawText("Game Over!", Color.Black, "Arial", 35, 280, 50);
            SwinGame.DrawText("Score :" + MWSideBarUpdate.Score, Color.Black, "Arial", 35, 280, 90);
            _mariogotoMenuButton.Draw();
        }

        public override void Update()
        {
        }

        public override void ProcessEvent()
        {
            SwinGame.StopMusic();
            if (SwinGame.MouseClicked(MouseButton.LeftButton))
            {
                if (_mariogotoMenuButton.IsAt(SwinGame.MousePosition()))
                {
                    _viewManager.View = _viewManager.Menu;
                    SwinGame.PlayMusic("Mountain.mp3");
                }
            }
            if (SwinGame.KeyTyped(KeyCode.vk_F12))
            {
                SwinGame.ToggleFullScreen();
            }
        }

        //x = 0
        public void SetX(int x)
        {
            _mariogotoMenuButton.SetX(x + 290);
            _mariogotoMenuButton.SetTextPositionX(x + 297);
        }

        //y = 0
        public void SetY(int y)
        {
            _mariogotoMenuButton.SetY(y + 300);
            _mariogotoMenuButton.SetTextPositionY(y + 310);
        }
    }
}
