using System;
using SwinGameSDK;

namespace MyGame
{
    public class MWMarioDiningTable
    {
        private Sprite _mariodiningTable;
        private Sprite _mariofood;

        private MWStatusBar _mariostatusBar;

        private Timer _mariogameTime;
        private int _marioticks;
        private bool _mariowaiting;

        private MWCustomer _mariocustomer;
        /// <summary>
        /// Michael
        /// </summary>
        private MWSideBarMarioUpdate _mariosideBar;*/

        public MWMarioDiningTable()
        {
            //Dining Table
            SwinGame.LoadBitmapNamed("diningTable.png", "diningTable.png");
            _mariodiningTable = SwinGame.CreateSprite(SwinGame.BitmapNamed("diningTable.png"));
            //

            //initialize a food sprite without image
            _mariofood = SwinGame.CreateSprite(SwinGame.BitmapNamed(""));

            //get a new customer
            _mariocustomer = MWMarioCustomerGenerator.NewMarioCustomer();

            //initialize Timer and start it for the first customer, set ticks to 0 and set the state of customer as waiting
            _mariogameTime = SwinGame.CreateTimer();
            SwinGame.StartTimer(_mariogameTime);
            _marioticks = 0;
            _mariowaiting = true;
            //

            //initiate a new red status bar
            _mariostatusBar = new MWStatusBar("emptyThick.png");
            _mariostatusBar.SetFillingImage("redThick.png");
            //
        }


        // x1 = 5, x2 = 90, x3 = 175, x4 = 260
        
        
        public void SetX(int x)
        {
            SwinGame.SpriteSetX(_mariodiningTable, x);

            // s1 = 27, s2 = 112, s3 = 197, s4 = 282
            _mariostatusBar.SetX(x + 22);

            // c1 = 25, c2 = 110, c3 = 195, c4 = 280
            _mariocustomer.SetX(x + 20);
        }


        // x = 85
        public void SetY(int y)
        {
            SwinGame.SpriteSetY(_mariodiningTable, y);

            // s = 110
            _mariostatusBar.SetY(y + 25);

            //c = 45
            _mariocustomer.SetY(y - 40);
        }


        // register side bar to show decreased game life
        /// <summary>
        /// Michael Added
        /// </summary>
        /// <param name="sideBar">Side bar.</param>
        public void RegisterSideBar(MWSideBarMarioUpdate sidebarupdate)
        {
            _mariosideBar = sidebarupdate;
        }

        public void Draw()
        {
            _mariocustomer.Draw();
            SwinGame.DrawSprite(_mariodiningTable);
            SwinGame.DrawSprite(_mariofood);
            _mariostatusBar.Draw(_marioticks, _mariodiningTable.X + 22, _mariodiningTable.Y + 25);
        }

        public bool Waiting
        {
            get { return _mariowaiting; }
            set { _mariowaiting = value; }
        }

        public MWCustomer Customer
        {
            get { return _mariocustomer; }
            set { _mariocustomer = value; }
        }

        //for unit test
        public Sprite DiningTableSprite
        {
            get { return _mariodiningTable; }
            set { _mariodiningTable = value; }
        }

        public void MarioSetFood(string foodImage)
        {
            SwinGame.LoadBitmapNamed(foodImage, foodImage);
            _mariofood = SwinGame.CreateSprite(SwinGame.BitmapNamed(foodImage));
            SwinGame.SpriteSetX(_mariofood, _mariodiningTable.X + 20);
            SwinGame.SpriteSetY(_mariofood, _mariodiningTable.Y - 10);
        }

        /// <summary>
        /// Michael Added
        /// </summary>
        public void AddScore()
        {
            _mariosideBar.AddScore();
        }

        public void ProcessEvent()
        {
            if (_mariowaiting)
            {
                //keep add time and increase the bar if the customer is waiting
                if (SwinGame.TimerTicks(_mariogameTime) > 700)
                {
                    _marioticks = _marioticks + 1;
                    SwinGame.ResetTimer(_mariogameTime);
                }
                //old customer rage and leave if the bar reach full. Decrease 0.5 heart life and get a new customer.
                if (_marioticks >= 42)
                {
                    _mariocustomer = MWMarioCustomerGenerator.NewMarioCustomer();
                    _mariocustomer.SetX(_mariodiningTable.X + 20);
                    _mariocustomer.SetY(_mariodiningTable.Y - 40);
                    _marioticks = 0;
                    _mariosideBar.DecreaseGameLife();
                }
            }
            else
            {
                //reduce the bar when the customer is eating. Clear the table and get a new customer when the bar reach empty. Then set the waiting to be true. 
                if (SwinGame.TimerTicks(_mariogameTime) > 150)
                {
                    _marioticks = _marioticks - 1;
                    SwinGame.ResetTimer(_mariogameTime);
                }
                if (_marioticks < 0)
                {
                    MarioSetFood("");
                    _mariocustomer = MWMarioCustomerGenerator.NewMarioCustomer();
                    _mariocustomer.SetX(_mariodiningTable.X + 20);
                    _mariocustomer.SetY(_mariodiningTable.Y - 40);
                    _mariowaiting = true;
                }
            }
        }
    }
}
