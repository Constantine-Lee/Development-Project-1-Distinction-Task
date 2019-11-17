using System;
using SwinGameSDK;

namespace MyGame
{
	public class GameMode : View
	{
		private MWButton _classicButton;

		private Sprite _gameMode;
		private string _backgroundImage;

        public string BackgroundImage { get => _backgroundImage; set => _backgroundImage = value; }

        public GameMode (ViewManager viewManager) : base (viewManager)
		{
			_backgroundImage = "Tutorial-game-interface-001.jpg";
			SwinGame.LoadBitmapNamed (_backgroundImage, _backgroundImage);
			_gameMode = SwinGame.CreateSprite (SwinGame.BitmapNamed (_backgroundImage));

			_classicButton = new MWButton ("grey_button06.png");
			_classicButton.SetWidth (191);
			_classicButton.SetHeight (49);
			_classicButton.SetText (" Classic ", 30);

		}

		public override void Draw ()
		{
			SwinGame.DrawSprite (_gameMode);
			_classicButton.Draw2 ();
		}

        public override void Update()
        {
        }

        public override void ProcessEvent()
        {
            if (SwinGame.MouseClicked(MouseButton.LeftButton))
            {
                if (_classicButton.IsAt(SwinGame.MousePosition()))
                {
                    _viewManager.View = _viewManager.MWNewClassicGame();
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
            _classicButton.SetX(x + 90);
            _classicButton.SetTextPositionX(x + 128);
        }

        //y = 0
        public void SetY(int y)
        {
            _classicButton.SetY(y + 100);
            _classicButton.SetTextPositionY(y + 108);
        }
    }
}

