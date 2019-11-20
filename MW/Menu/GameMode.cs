using System;
using SwinGameSDK;

namespace MyGame
{
	public class GameMode : View
	{
		private MWButton _classicButton;
        private MWButton _survivalButton;
        private MWButton _casualButton;
        private MWButton _gotoMenuButton;

        private Sprite _gameMode;
		private string _backgroundImage;

        public string BackgroundImage { get {return _backgroundImage; } set { _backgroundImage = value; } }
        public MWButton ClassicButton { get {return _classicButton; } set { _classicButton = value; } }

        public GameMode (ViewManager viewManager) : base (viewManager)
		{
			_backgroundImage = "Tutorial-game-interface-001.jpg";
			SwinGame.LoadBitmapNamed (_backgroundImage, _backgroundImage);
			_gameMode = SwinGame.CreateSprite (SwinGame.BitmapNamed (_backgroundImage));

			_classicButton = new MWButton ("grey_button06.png");
			_classicButton.SetWidth (191);
			_classicButton.SetHeight (49);
			_classicButton.SetText (" Classic ", 30);

            _survivalButton = new MWButton("grey_button06.png");
            _survivalButton.SetWidth(191);
            _survivalButton.SetHeight(49);
            _survivalButton.SetText(" Survival ", 30);

            _casualButton = new MWButton("grey_button06.png");
            _casualButton.SetWidth(191);
            _casualButton.SetHeight(49);
            _casualButton.SetText(" Casual ", 30);

            _gotoMenuButton = new MWButton("grey_button06.png");
            _gotoMenuButton.SetWidth(191);
            _gotoMenuButton.SetHeight(49);
            _gotoMenuButton.SetText(" Back to Menu ", 25);
        }

		public override void Draw ()
		{
			SwinGame.DrawSprite (_gameMode);
			_classicButton.Draw2 ();
            _survivalButton.Draw2();
            _casualButton.Draw2();
            _gotoMenuButton.Draw();
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
                if (_survivalButton.IsAt(SwinGame.MousePosition()))
                {
                    _viewManager.View = _viewManager.NewZYGame();
                }
                if (_casualButton.IsAt(SwinGame.MousePosition()))
                {
                    _viewManager.View = _viewManager.BSNewCasualGame();
                }
                if (_gotoMenuButton.IsAt(SwinGame.MousePosition()))
                {
                    _viewManager.View = _viewManager.Menu;
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

            _survivalButton.SetX(x + 90);
            _survivalButton.SetTextPositionX(x + 120);

            _casualButton.SetX(x + 90);
            _casualButton.SetTextPositionX(x + 130);

            _gotoMenuButton.SetX(x + 305);
            _gotoMenuButton.SetTextPositionX(x + 315);
        }

        //y = 0
        public void SetY(int y)
        {
            _classicButton.SetY(y + 100);
            _classicButton.SetTextPositionY(y + 108);

            _survivalButton.SetY(y + 170);
            _survivalButton.SetTextPositionY(y + 178);

            _casualButton.SetY(y + 240);
            _casualButton.SetTextPositionY(y + 248);

            _gotoMenuButton.SetY(y + 340);
            _gotoMenuButton.SetTextPositionY(y + 350);
        }
    }
}

