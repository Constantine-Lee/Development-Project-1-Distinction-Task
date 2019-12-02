using System;
using SwinGameSDK;

namespace MyGame
{
    public class MWCustomerSelection: View
    {
        private string _image;
        private MWButton _pokemonButton;
        private MWButton _superMarioButton;
        private Sprite _menu;

        public MWCustomerSelection()
        {
        }

        public MWCustomerSelection(ViewManager viewManager) : base(viewManager)
        {
            //background Image
            _image = BS_bgSelector.bg_img();
            SwinGame.LoadBitmapNamed(_image, _image);
            _menu = SwinGame.CreateSprite(SwinGame.BitmapNamed(_image));
            //

            //Male Button
            _pokemonButton = new MWButton("grey_button06.png");
            _pokemonButton.SetWidth(191);
            _pokemonButton.SetHeight(49);
            _pokemonButton.SetText("Pokemon", 25);
            //

            _superMarioButton = new MWButton("grey_button06.png");
            _superMarioButton.SetWidth(191);
            _superMarioButton.SetHeight(49);
            _superMarioButton.SetText("SuperMario", 25);

        }

        public override void Draw()
        {
            SwinGame.DrawSprite(_menu);
            SwinGame.DrawText("Please Select Your Customer", Color.Black, "Arial", 25, 90, 150);
            _pokemonButton.Draw();
            _superMarioButton.Draw();
        }

        public override void Update()
        {
        }

        public override void ProcessEvent()
        {
            if (SwinGame.MouseClicked(MouseButton.LeftButton))
            {
                if (_pokemonButton.IsAt(SwinGame.MousePosition()))
                {
                    //add pokemon character
                    _viewManager.View = _viewManager.MWNewMarioClassicGame();
                }
                if (_superMarioButton.IsAt(SwinGame.MousePosition()))
                {
                    //add mario character
                    _viewManager.View = _viewManager.MWNewClassicGame();
                }
            }
        }

        //x = 0
        public void SetX(int x)
        {
            _pokemonButton.SetX(x + 40);
            _pokemonButton.SetTextPositionX(x + 85);
            _superMarioButton.SetX(x + 270);
            _superMarioButton.SetTextPositionX(x + 300);
        }

        //y = 0
        public void SetY(int y)
        {
            _pokemonButton.SetY(y + 220);
            _pokemonButton.SetTextPositionY(y + 230);

            _superMarioButton.SetY(y + 220);
            _superMarioButton.SetTextPositionY(y + 230);
        }
    }
}
