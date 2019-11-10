using System;
using SwinGameSDK;

namespace MyGame
{
	public class GameMain
	{
		public static void Main ()
		{
			ViewManager _viewManager = new ViewManager ();
			_viewManager.SetX (0);
			_viewManager.SetY (0);

			//Open the game window
			SwinGame.OpenGraphicsWindow ("GameMain", 500, 400);

			//Run the game loop
			while (false == SwinGame.WindowCloseRequested ()) {
				//Clear the screen and draw the framerate
				SwinGame.ClearScreen (Color.White);

				_viewManager.Draw();
				SwinGame.RefreshScreen (60);

				_viewManager.Update();

				SwinGame.ProcessEvents ();
				_viewManager.ProcessEvent ();
				SwinGame.RefreshScreen (60);
				}
			}
	}
}