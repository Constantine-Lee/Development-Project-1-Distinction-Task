﻿using System;
using SwinGameSDK;

namespace MyGame
{
    public class ViewManager
    {
        private static ViewManager sViewManager;
        private Menu _menu;
        private Instruction _instruction;
       
        private BS_End _BSEnd;
        private ZYEnd _end;
        private MWEnd _MWEnd;
        private MWMarioEnd _MWMarioEnd;
        private View _view;
        private ZYEasyMode _easyMode;
        private ZYMediumMode _mediumMode;
        private ZYStartMedium _startMedium;
        private ZYDifficultMode _difficultMode;
        private ZYStartDifficult _startDifficult;
        private Settings _settings;
        private MWGame _MWGame;
        private MWmarioGame _MWmarioGame;
        private GameMode _gameMode;
        private BS_Game _BSGame;
        private PauseScreenForEasy _pauseScreenForEasy;
        private PauseScreenForMedium _pauseScreenForMedium;
        private ZYCharacterInterface _zYcharacterSelection;
        private MWCustomerSelection _mWCustomerSelection;
        public ViewManager()
        {
            SwinGame.LoadResourceBundle("bundle.txt");
            _menu = new Menu(this);
            _instruction = new Instruction(this);
            _settings = new Settings(this);
            
            _BSEnd = new BS_End(this);
            _end = new ZYEnd(this);
            _MWEnd = new MWEnd(this);
            _MWMarioEnd = new MWMarioEnd(this);
            _easyMode = new ZYEasyMode(this);
            _mediumMode = new ZYMediumMode(this);
            _startMedium = new ZYStartMedium(this);
            _difficultMode = new ZYDifficultMode(this);
            _startDifficult = new ZYStartDifficult(this);
            _MWGame = new MWGame(this);
            _MWmarioGame = new MWmarioGame(this);
            _gameMode = new GameMode(this);
            _BSGame = new BS_Game(this);
            _pauseScreenForEasy = new PauseScreenForEasy(this);
            _pauseScreenForMedium = new PauseScreenForMedium(this);
            _zYcharacterSelection = new ZYCharacterInterface(this);
            _mWCustomerSelection = new MWCustomerSelection(this);
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
            _settings.SetX(0);
           
            _BSEnd.SetX(0);
            _end.SetX(0);
            _MWEnd.SetX(0);
            _MWMarioEnd.SetX(0);
            _easyMode.SetX(0);
            _mediumMode.SetX(0);
            _startMedium.SetX(0);
            _startDifficult.SetX(0);
            _MWGame.SetX(0);
            _MWmarioGame.SetX(0);
            _gameMode.SetX(0);
            _BSGame.SetX(0);
            _pauseScreenForEasy.SetX(0);
            _pauseScreenForMedium.SetX(0);
            _zYcharacterSelection.SetX(0);
            _mWCustomerSelection.SetX(0);
        }

        public void SetY(int y)
        {
            _menu.SetY(0);
            _instruction.SetY(0);
            _settings.SetY(0);
            
            _BSEnd.SetY(0);
            _end.SetY(0);
            _MWEnd.SetY(0);
            _MWMarioEnd.SetY(0);
            _easyMode.SetY(0);
            _mediumMode.SetY(0);
            _startMedium.SetY(0);
            _startDifficult.SetY(0);
            _MWGame.SetY(0);
            _MWmarioGame.SetY(0);
            _gameMode.SetY(0);
            _BSGame.SetY(0);
            _pauseScreenForEasy.SetY(0);
            _pauseScreenForMedium.SetY(0);
            _zYcharacterSelection.SetY(0);
            _mWCustomerSelection.SetY(0);
        }
        public MWCustomerSelection MWCustomerSelection
        {
            get { return _mWCustomerSelection; }
            set { _mWCustomerSelection = value; }
        }

        public ZYCharacterInterface ZYCharacterInterface
        {
            get { return _zYcharacterSelection; }
            set { _zYcharacterSelection = value; }
        }

        public PauseScreenForEasy PauseScreenForEasy
        {
            get { return _pauseScreenForEasy; }
            set { _pauseScreenForEasy = value; }
        }

        public PauseScreenForMedium PauseScreenForMedium
        {
            get { return _pauseScreenForMedium; }
            set { _pauseScreenForMedium = value; }
        }

        public Settings Settings {
            get { return _settings; }
            set { _settings = value; }
        }

        public MWGame MWNewClassicGame()
        {
            MWGame game = new MWGame(this);
            game.SetX(0);
            game.SetY(0);
            return game;
        }
        public MWmarioGame MWNewMarioClassicGame()
        {
            MWmarioGame game = new MWmarioGame(this);
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

        public BS_End BS_End
        {
            get { return _BSEnd; }
            set { _BSEnd = value; }
        }

        public MWMarioEnd MWMarioEnd
        {
            get { return _MWMarioEnd; }
            set { _MWMarioEnd = value; }
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
            _easyMode = new ZYEasyMode(this);
            _mediumMode = new ZYMediumMode(this);
            _difficultMode = new ZYDifficultMode(this);
            _easyMode.SetX(0);
            _easyMode.SetY(0);
            _mediumMode.SetX(0);
            _mediumMode.SetY(0);
            _difficultMode.SetX(0);
            _difficultMode.SetY(0);
            return _easyMode;
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

        public ZYEasyMode EasyMode { get { return _easyMode; } set { _easyMode = value; } }
        public MWEnd MWEnd { get { return _MWEnd; } set { _MWEnd = value; } }
    }
}
