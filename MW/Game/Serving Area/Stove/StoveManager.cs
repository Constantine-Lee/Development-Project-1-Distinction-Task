using System;
using SwinGameSDK;

namespace MyGame
{
	public class StoveManager
	{
		private Stove [] _stove;

		public StoveManager (Stove [] stove)
		{
			_stove = stove;
		}

		// x = 0
		public void SetX (int x)
		{
			// x1 = 0, x2 = 105
			for (int i = 0, x_axis = x; i < 2; i++, x_axis += 105) {
				_stove [i].SetX (x_axis);
			}
		}

		// y = 225
		public void SetY (int y)
		{
			for (int i = 0, y_axis = y; i < 2; i++) {
				_stove [i].SetY (y_axis);
			}
		}

		public void Draw ()
		{
			foreach (Stove stove in _stove) {
				stove.Draw ();
			}
		}

		public void ProcessEvent ()
		{
			_stove [0].ProcessEvent ();
			_stove [1].ProcessEvent ();
		}
	}
}
