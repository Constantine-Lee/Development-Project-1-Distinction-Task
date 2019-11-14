using System;
using SwinGameSDK;

namespace MyGame
{
	public class MWDiningTableManager
	{
		private MWDiningTable [] _diningTable;

		public MWDiningTableManager (MWDiningTable [] diningTable)
		{
			_diningTable = diningTable;
		}

		// x = 5
		public void SetX (int x)
		{
			for (int i = 0, x_axis = x; i < 4; i++, x_axis += 85) {
				_diningTable [i].SetX (x_axis);
			}
		}

		//y = 85
		public void SetY (int y)
		{
			for (int i = 0, y_axis = y; i < 4; i++) {
				_diningTable [i].SetY (y_axis);
			}
		}

		public void Draw ()
		{
			foreach (MWDiningTable servingTable in _diningTable) {
				servingTable.Draw ();
			}
		}

		public void ProcessEvent ()
		{
			foreach (MWDiningTable diningTable in _diningTable) {
				diningTable.ProcessEvent ();
			}
		}
	}
}
