using System;
using SwinGameSDK;

namespace MyGame
{
	public class DiningTable
	{
		private Sprite _diningTable;
		private Sprite _food;

		private StatusBar _statusBar;

		private Timer _gameTime;
		private int _ticks;
		private bool _waiting;

		private Customer _customer;
		private SideBar _sideBar;

		public DiningTable ()
		{
			//Dining Table
			SwinGame.LoadBitmapNamed ("diningTable.png", "diningTable.png");
			_diningTable = SwinGame.CreateSprite (SwinGame.BitmapNamed ("diningTable.png"));
			//

			//initialize a food sprite without image
			_food = SwinGame.CreateSprite (SwinGame.BitmapNamed (""));

			//get a new customer
			_customer = PokemonCustomerGenerator.NewCustomer ();

			//initialize Timer and start it for the first customer, set ticks to 0 and set the state of customer as waiting
			_gameTime = SwinGame.CreateTimer ();
			SwinGame.StartTimer (_gameTime);
			_ticks = 0;
			_waiting = true;
			//

			//initiate a new red status bar
			_statusBar = new StatusBar ("emptyThick.png");
			_statusBar.SetFillingImage ("redThick.png");
			//
		}


		// x1 = 5, x2 = 90, x3 = 175, x4 = 260
		public void SetX (int x)
		{
			SwinGame.SpriteSetX (_diningTable, x);

			// s1 = 27, s2 = 112, s3 = 197, s4 = 282
			_statusBar.SetX (x + 22);

			// c1 = 25, c2 = 110, c3 = 195, c4 = 280
			_customer.SetX (x + 20);
		}


		// x = 85
		public void SetY (int y)
		{
			SwinGame.SpriteSetY (_diningTable, y);

			// s = 110
			_statusBar.SetY (y + 25);

			//c = 45
			_customer.SetY (y - 40);
		}


		// register side bar to show decreased game life
		public void RegisterSideBar (SideBar sideBar)
		{
			_sideBar = sideBar;
		}

		public void Draw ()
		{
			_customer.Draw ();
			SwinGame.DrawSprite (_diningTable);
			SwinGame.DrawSprite (_food);
			_statusBar.Draw (_ticks, _diningTable.X + 22, _diningTable.Y + 25);
		}

		public bool Waiting {
			get { return _waiting; }
			set { _waiting = value; }
		}

		public Customer Customer {
			get { return _customer; }
			set { _customer = value; }
		}

		//for unit test
		public Sprite DiningTableSprite {
			get {return _diningTable;}
			set {_diningTable = value;}
		}

		public void SetFood (string foodImage)
		{
			SwinGame.LoadBitmapNamed (foodImage, foodImage);
			_food = SwinGame.CreateSprite (SwinGame.BitmapNamed (foodImage));
			SwinGame.SpriteSetX (_food, _diningTable.X + 20);
			SwinGame.SpriteSetY (_food, _diningTable.Y - 10);
		}

		public void ProcessEvent ()
		{
			if (_waiting) {
				//keep add time and increase the bar if the customer is waiting
				if (SwinGame.TimerTicks (_gameTime) > 700) {
					_ticks = _ticks + 1;
					SwinGame.ResetTimer (_gameTime);
				}
				//old customer rage and leave if the bar reach full. Decrease 0.5 heart life and get a new customer.
				if (_ticks >= 42) {
					_customer = PokemonCustomerGenerator.NewCustomer ();
					_customer.SetX (_diningTable.X + 20);
					_customer.SetY (_diningTable.Y - 40);
					_ticks = 0;
					_sideBar.DecreaseGameLife ();
				}
			} else {
				//reduce the bar when the customer is eating. Clear the table and get a new customer when the bar reach empty. Then set the waiting to be true. 
				if (SwinGame.TimerTicks (_gameTime) > 150) {
					_ticks = _ticks - 1;
					SwinGame.ResetTimer (_gameTime);
				}
				if (_ticks < 0) {
					SetFood ("");
					_customer = PokemonCustomerGenerator.NewCustomer ();
					_customer.SetX (_diningTable.X + 20);
					_customer.SetY (_diningTable.Y - 40);
					_waiting = true;
				}
			}
		}
	}
}
