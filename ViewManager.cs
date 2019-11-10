using System;
using SwinGameSDK;

namespace MyGame
{
    public class ViewManager
    {
        private static ViewManager sViewManager;
        private Menu _menu;
        private Instruction _instruction;
        private End _end;
        private View _view;
        private EasyMode _easyMode;
        private MediumMode _mediumMode;

        private ViewManager()
        {
            SwinGame.LoadResourceBundle("bundle.txt");
            _menu = new Menu(this);
            _instruction = new Instruction(this);
            _end = new End(this);
            _easyMode = new EasyMode(this);
            _mediumMode = new MediumMode(this);
            _easyMode.SetSpeed();
            _view = _easyMode;
        }

        public static ViewManager getInstance()
        {
            if (sViewManager == null)
            {
                sViewManager = new ViewManager();
            }
            return sViewManager;
        }

        public void SetX(int x)
        {
            _menu.SetX(0);
            _instruction.SetX(0);
            _end.SetX(0);
            _easyMode.SetX(0);
            _mediumMode.SetX(0);
        }

        public void SetY(int y)
        {
            _menu.SetY(0);
            _instruction.SetY(0);
            _end.SetY(0);
            _easyMode.SetY(0);
            _mediumMode.SetY(0);
        }

        public View View {
            get { return _view; }
            set { _view = value; }
        }

        public Menu Menu {
            get { return _menu; }
            set { _menu = value; }
        }

        public Instruction Instruction {
            get { return _instruction; }
            set { _instruction = value; }
        }

        public End End {
            get { return _end; }
            set { _end = value; }
        }

        public MediumMode MediumMode
        {
            get { return _mediumMode;}
            set { _mediumMode = value; }
            }

		public void Draw ()
		{
			_view.Draw ();
		}

		public void Update ()
		{
			_view.Update ();
		}

		public void ProcessEvent ()
		{
			_view.ProcessEvent ();
		}

		public Game NewGame ()
		{
			Game game = new Game (this);
			game.SetX (0);
			game.SetY (0);
			return game;
		}
	}
}
