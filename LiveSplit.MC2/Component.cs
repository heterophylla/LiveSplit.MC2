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
            _hooks.OnHookmanLastCutscene += On_HookmanLastCutscene;
            _hooks.OnFinishAny += On_FinishAny;
            _hooks.OnFinishHundo += On_FinishHundo;

            _settings = new Settings();

            _timer = new Timer { Interval = 15, Enabled = true };
            _timer.Tick += UpdateHook;

            _timermodel = new TimerModel {CurrentState = state};
            _timermodel.CurrentState.OnStart += On_Start;
            _timermodel.CurrentState.OnReset += On_Reset;


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
            _hooks.Update(_settings);
            _timer.Enabled = true;
        }

        private void On_Start(object sender, EventArgs e)
        {
            _timermodel.InitializeGameTime();
        }

        private void On_Reset(object sender, TimerPhase t)
        {
            ResetAutoSplit();  
        } 

        private void On_LoadStartAfterFrontend(object sender, EventArgs e)
        {
            if (_settings.Start) _timermodel.Start();
        }

        private void On_RaceStart(object sender, EventArgs e)
        {
            if (_settings.Split && _settings.SplitRace) 
                _timermodel.Split();
        }

        private void On_HookmanLastCutscene(object sender, EventArgs e)
        {
            if (_settings.Split && _settings.SplitHookman)
                _timermodel.Split();
        }

        private void On_FinishAny(object sender, EventArgs e)
        {
            if (_settings.Split && _settings.FinishAny) _timermodel.Split();
        }

        private void On_FinishHundo(object sender, EventArgs e)
        {
            if (_settings.Split && _settings.FinishHundo) _timermodel.Split();
        }

        public void On_Loading(bool loading) => _state.IsGameTimePaused = loading;

        public override void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode) { }

        private void ResetAutoSplit()
        {
            _hooks.OnLoadStartAfterFrontend -= On_LoadStartAfterFrontend;
            _hooks.OnRaceStart -= On_RaceStart;
            _hooks.OnHookmanLastCutscene -= On_HookmanLastCutscene;
            _hooks.OnFinishAny -= On_FinishAny;
            _hooks?.Dispose();
            _hooks = new Hooks(this);
            _hooks.OnLoadStartAfterFrontend += On_LoadStartAfterFrontend;
            _hooks.OnRaceStart += On_RaceStart;
            _hooks.OnHookmanLastCutscene += On_HookmanLastCutscene;
            _hooks.OnFinishAny += On_FinishAny;
        }

        public override XmlNode GetSettings(XmlDocument document) => _settings.GetSettings(document);

        public override Control GetSettingsControl(LayoutMode mode) => _settings;

        public override void SetSettings(XmlNode settings) => _settings.SetSettings(settings);
    }
}
