using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
	public class MWGame: View
	{
		private MWServingArea _servingArea;
		private MWSideBarUpdate _sideBar;
		private MWBottomBar _btmBar;
		private MWButton _giveUpButton;

		public MWGame (ViewManager viewManager): base(viewManager)
		{
			_sideBar = new MWSideBarUpdate (_viewManager);
			_servingArea = new MWServingArea ();
			_btmBar = new MWBottomBar ();

			_giveUpButton = new MWButton ("blue_button07.png");
			_giveUpButton.SetWidth (80);
			_giveUpButton.SetHeight (80);
			_giveUpButton.SetText ("Exit", 35);

			//Register for Observer Pattern
			foreach(MWDiningTable diningTable in _servingArea.DiningTable)
			{
				diningTable.RegisterSideBar (_sideBar);
			}
			_btmBar.RegisterStove (_servingArea.Stoves);
			_servingArea.Player.RegisterHoldingFrame (_sideBar.HoldingFoodFrame);
			//
		}

		public override void Draw ()
		{
			_servingArea.Draw ();
			_sideBar.Draw ();
			_btmBar.Draw ();
			_giveUpButton.Draw ();
		}

		public override void Update ()
		{
			_servingArea.Update ();
		}

		public override void ProcessEvent ()
		{
			_btmBar.ProcessEvent ();
			_servingArea.ProcessEvent ();
			_sideBar.ProcessEvent ();

			if (SwinGame.KeyTyped (KeyCode.vk_F12)) {
				SwinGame.ToggleFullScreen ();
			}
			//change view to end if give up button clicked
			if (SwinGame.MouseClicked (MouseButton.LeftButton)) {
				if (_giveUpButton.IsAt (SwinGame.MousePosition ())) {
					_viewManager.View = _viewManager.MWEnd;
				}
			}
		}

		// x = 0
		public void SetX (int x)
		{
			_servingArea.SetX (x);
			_btmBar.SetX (x + 10);
			_giveUpButton.SetX (x + 400);
			_giveUpButton.SetTextPositionX (x + 410);
			_sideBar.SetX (x + 350);
		}

		// x = 0
		public void SetY (int y)
		{
			_servingArea.SetY (y);
			_btmBar.SetY (y + 280);
			_giveUpButton.SetY (y + 295);
			_giveUpButton.SetTextPositionY (y + 310);
		}

	}
}
