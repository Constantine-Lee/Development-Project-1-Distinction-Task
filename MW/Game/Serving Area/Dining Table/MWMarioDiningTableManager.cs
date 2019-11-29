using System;
using SwinGameSDK;

namespace MyGame
{
    public class MWMarioDiningTableManager
    {
        private MWMarioDiningTable[] _mariodiningTable;

        public MWMarioDiningTableManager(MWMarioDiningTable[] diningTable)
        {
            _mariodiningTable = diningTable;
        }

        // x = 5
        public void SetX(int x)
        {
            for (int i = 0, x_axis = x; i < 4; i++, x_axis += 85)
            {
                _mariodiningTable[i].SetX(x_axis);
            }
        }

        //y = 85
        public void SetY(int y)
        {
            for (int i = 0, y_axis = y; i < 4; i++)
            {
                _mariodiningTable[i].SetY(y_axis);
            }
        }

        public void Draw()
        {
            foreach (MWMarioDiningTable servingTable in _mariodiningTable)
            {
                servingTable.Draw();
            }
        }

        public void ProcessEvent()
        {
            foreach (MWMarioDiningTable diningTable in _mariodiningTable)
            {
                diningTable.ProcessEvent();
            }
        }
    }
}
