using System;
using SwinGameSDK;

namespace MyGame
{
    public class ViewManager
    {
        private static ViewManager sViewManager;
        private Menu _menu;
        private Instruction _instruction;

        private View _view;


        private ViewManager()
        {
            SwinGame.LoadResourceBundle("bundle.txt");
            _menu = new Menu(this);
            _instruction = new Instruction(this);

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

        }

        public void SetY(int y)
        {
            _menu.SetY(0);
            _instruction.SetY(0);

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

        public ZYEnd ZYEnd
        {
            get { return ZYEnd; }
            set { ZYEnd = value;  }
        }
	}
}
