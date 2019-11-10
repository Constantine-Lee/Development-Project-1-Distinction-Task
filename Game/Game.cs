using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
	public class Game: View
	{
		private ServingArea _servingArea;
		private SideBar _sideBar;
		private BottomBar _btmBar;
		private Button _giveUpButton;

		public Game (ViewManager viewManager): base(viewManager)
		{
			_sideBar = new SideBar (_viewManager);
			_servingArea = new ServingArea ();
			_btmBar = new BottomBar ();

			_giveUpButton = new Button ("blue_button07.png");
			_giveUpButton.SetWidth (80);
			_giveUpButton.SetHeight (80);
			_giveUpButton.SetText ("Exit", 35);

			//Register for Observer Pattern
			foreach(DiningTable diningTable in _servingArea.DiningTable)
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

			//change view to end if give up button clicked
			if (SwinGame.MouseClicked (MouseButton.LeftButton)) {
				if (_giveUpButton.IsAt (SwinGame.MousePosition ())) {
					_viewManager.View = _viewManager.End;
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
