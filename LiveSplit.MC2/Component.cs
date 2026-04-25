using System;
using System.Windows.Forms;
using System.Xml;
using LiveSplit.Model;
using LiveSplit.UI;
using LiveSplit.UI.Components;

namespace LiveSplit.MC2
{
    class Component : LogicComponent
    {
        public override string ComponentName => "Midnight Club 2 Autosplitter";
        
        LiveSplitState _state;
        Hooks _hooks;
        Timer _timer;
        Settings _settings;
        TimerModel _timermodel;

        public Component(LiveSplitState state)
        {
            _state = state;
            _hooks = new Hooks(this);
            _hooks.OnLoadStartAfterFrontend += On_LoadStartAfterFrontend;
            _hooks.OnRaceStart += On_RaceStart;

            _settings = new Settings();

            _timer = new Timer { Interval = 15, Enabled = true };
            _timer.Tick += UpdateHook;

            _timermodel = new TimerModel {CurrentState = state};
            _timermodel.CurrentState.OnStart += On_Start;


        }

        public override void Dispose()
        {
            _timer.Enabled = false;
            _timer.Dispose();
            _hooks.Dispose();
            _timermodel.CurrentState.OnStart -= On_Start;
        }

        private void UpdateHook(object sender, EventArgs e)
        {
            _timer.Enabled = false;
            _hooks.Update();
            _timer.Enabled = true;
        }

        void On_Start(object sender, EventArgs e)
        {
            _timermodel.InitializeGameTime();
        }

        void On_LoadStartAfterFrontend(object sender, EventArgs e) //TODO: Not working First time? Cuz of hook != 2 on first stasrt?
        {
            _timermodel.Start();
        }

        void On_RaceStart(object sender, EventArgs e)
        {
            _timermodel.Split();
        }
        public void On_Loading(bool loading) => _state.IsGameTimePaused = loading;

        public override void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode) { }

        public override XmlNode GetSettings(XmlDocument document) => _settings.GetSettings(document);

        public override Control GetSettingsControl(LayoutMode mode) => _settings;

        public override void SetSettings(XmlNode settings) => _settings.SetSettings(settings);
    }
}
