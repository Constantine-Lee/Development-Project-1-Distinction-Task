using System;
using SwinGameSDK;

namespace MyGame
{
    public class ViewManager
    {
        private static ViewManager sViewManager;
        private Menu _menu;
        private Instruction _instruction;
        private ZYEnd _end;
        private MWEnd _MWEnd;
        private View _view;
        private ZYEasyMode _easyMode;
        private ZYMediumMode _mediumMode;
        private ZYStartMedium _startMedium;
        private ZYDifficultMode _difficultMode;
        private ZYStartDifficult _startDifficult;
        private MWGame _MWGame;
        private GameMode _gameMode;
        private BS_Game _BSGame;

        private ViewManager()
        {
            SwinGame.LoadResourceBundle("bundle.txt");
            _menu = new Menu(this);
            _instruction = new Instruction(this);
            _end = new ZYEnd(this);
            _easyMode = new ZYEasyMode(this);
            _mediumMode = new ZYMediumMode(this);
            _startMedium = new ZYStartMedium(this);
            _difficultMode = new ZYDifficultMode(this);
            _startDifficult = new ZYStartDifficult(this);
            _MWGame = new MWGame(this);
            _gameMode = new GameMode(this);
            _BSGame = new BS_Game(this);
            _easyMode.SetSpeed();
            _view = _menu;
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
            _startMedium.SetX(0);
            _startDifficult.SetX(0);
            _MWGame.SetX(0);
            _gameMode.SetX(0);
            _BSGame.SetX(0);
        }

        public void SetY(int y)
        {
            _menu.SetY(0);
            _instruction.SetY(0);
            _end.SetY(0);
            _easyMode.SetY(0);
            _mediumMode.SetY(0);
            _startMedium.SetY(0);
            _startDifficult.SetY(0);
            _MWGame.SetY(0);
            _gameMode.SetY(0);
            _BSGame.SetY(0);
        }

        public MWGame MWNewClassicGame()
        {
            MWGame game = new MWGame(this);
            game.SetX(0);
            game.SetY(0);
            return game;
        }

        public BS_Game BSNewCasualGame()
        {
            BS_Game game = new BS_Game(this);
            game.SetX(0);
            game.SetY(0);
            return game;
        }

        public ZYStartMedium StartMedium
        {
            get { return _startMedium; }
            set { _startMedium = value; }
        }

        public ZYStartDifficult StartDifficult
        {
            get { return _startDifficult; }
            set { _startDifficult = value; }
        }
        public View View
        {
            get { return _view; }
            set { _view = value; }
        }

        public Menu Menu
        {
            get { return _menu; }
            set { _menu = value; }
        }

        public Instruction Instruction
        {
            get { return _instruction; }
            set { _instruction = value; }
        }

        public ZYEnd ZYEnd
        {
            get { return _end; }
            set { _end = value; }
        }

        public ZYMediumMode MediumMode
        {
            get { return _mediumMode; }
            set { _mediumMode = value; }
        }

        public ZYDifficultMode DifficultMode
        {
            get { return _difficultMode; }
            set { _difficultMode = value; }
        }
        public void Draw()
        {
            _view.Draw();
        }

        public void Update()
        {
            _view.Update();
        }

        public void ProcessEvent()
        {
            _view.ProcessEvent();
        }

        public ZYEasyMode NewZYGame()
        {
            ZYEasyMode game = new ZYEasyMode(this);
            game.SetX(0);
            game.SetY(0);
            return game;
        }

        public ZYMediumMode NewMediumMode()
        {
            ZYMediumMode mediumMode = new ZYMediumMode(this);
            mediumMode.SetX(0);
            mediumMode.SetY(0);
            mediumMode.SetSpeed();
            return mediumMode;
        }

        public ZYDifficultMode NewDifficultMode()
        {
            ZYDifficultMode difficultMode = new ZYDifficultMode(this);
            difficultMode.SetX(0);
            difficultMode.SetY(0);
            difficultMode.SetSpeed();
            return difficultMode;
        }

        public GameMode GameMode
        {
            get { return _gameMode; }
            set { _gameMode = value; }
        }

        public ZYEasyMode EasyMode { get => _easyMode; set => _easyMode = value; }
        public MWEnd MWEnd { get => _MWEnd; set => _MWEnd = value; }
    }
}
