using System;
using System.Collections.Generic;
using System.Diagnostics;
using LiveSplit.ComponentUtil;

namespace LiveSplit.MC2
{
    internal struct SplitPair
    {
        public string SplitName;
        public bool SplitFlag;
    }
    
    class Hooks : IDisposable
    {
        private readonly Dictionary<string, SplitPair> _RaceName = new Dictionary<string, SplitPair>
        {
            {"lamauro_Moses_Checkpoint_One",               new SplitPair {SplitName = "Moses 1",            SplitFlag = false}},
            {"lamauro_Moses_Checkpoint_Two",               new SplitPair {SplitName = "Moses 2",            SplitFlag = false}},
            {"lamauro_Steven_Checkpoint_One",              new SplitPair {SplitName = "Steven 1",           SplitFlag = false}},
            {"lachrisbeta_Steven_Checkpoint_Two",          new SplitPair {SplitName = "Steven 2",           SplitFlag = false}},
            {"lamauro_Maria_Checkpoint_One",               new SplitPair {SplitName = "Maria 1",            SplitFlag = false}},
            {"lamauro_Maria_Checkpoint_Two",               new SplitPair {SplitName = "Maria 2",            SplitFlag = false}},
            {"lamauro_Angel_Checkpoint_One",               new SplitPair {SplitName = "Angel 1",            SplitFlag = false}},
            {"lamauro_Angel_SideRace",                     new SplitPair {SplitName = "Angel Siderace",     SplitFlag = false}},
            {"lamauro_Angel_Checkpoint_Two",               new SplitPair {SplitName = "Angel 2",            SplitFlag = false}},
            {"laChris_Gina_Checkpoint_One",                new SplitPair {SplitName = "Gina 1",             SplitFlag = false}},
            {"laChris_Gina_SideRace",                      new SplitPair {SplitName = "Gina Siderace",      SplitFlag = false}},
            {"laChris_Gina_Bike_Tutorial",                 new SplitPair {SplitName = "Gina Bike Tutorial", SplitFlag = false}},
            {"laChris_Gina_Checkpoint_Two",                new SplitPair {SplitName = "Gina 2",             SplitFlag = false}},
            {"lawing_Hector_LoseTheCops",                  new SplitPair {SplitName = "Hector Lose Cops",   SplitFlag = false}},
            {"lachrisbeta_Hector_Checkpoint_Two",          new SplitPair {SplitName = "Hector 2",           SplitFlag = false}},
            {"lachrisbeta_Hector_Checkpoint_Three",        new SplitPair {SplitName = "Hector 3",           SplitFlag = false}},
            {"lamaurobeta_Dice_Checkpoint_One",            new SplitPair {SplitName = "Dice 1",             SplitFlag = false}},
            {"lamaurobeta_Dice_Checkpoint_Two",            new SplitPair {SplitName = "Dice 2",             SplitFlag = false}},
            {"parischris_Blog_Checkpoint_One",             new SplitPair {SplitName = "Blog 1",             SplitFlag = false}},
            {"parischris_Blog_Checkpoint_Two",             new SplitPair {SplitName = "Blog 2",             SplitFlag = false}},
            {"pariswing_Julie_Checkpoint_One",             new SplitPair {SplitName = "Julie 1",            SplitFlag = false}},
            {"pariswing_Julie_Checkpoint_Two",             new SplitPair {SplitName = "Julie 2",            SplitFlag = false}},
            {"parischris_Primo_Checkpoint_One",            new SplitPair {SplitName = "Primo 1",            SplitFlag = false}},
            {"paris_Primo_Checkpoint_Two",                 new SplitPair {SplitName = "Primo 2",            SplitFlag = false}},
            {"parischris_Stephane_Checkpoint_One",         new SplitPair {SplitName = "Stephane 1",         SplitFlag = false}},
            {"parischris_Stephane_Checkpoint_Two",         new SplitPair {SplitName = "Stephane 2",         SplitFlag = false}},
            {"paris_Ian_Checkpoint_One",                   new SplitPair {SplitName = "Ian 1",              SplitFlag = false}},
            {"paris_Ian_Checkpoint_Two",                   new SplitPair {SplitName = "Ian 2",              SplitFlag = false}},
            {"paris_Ian_SideRace",                         new SplitPair {SplitName = "Ian Siderace",       SplitFlag = false}},
            {"pariswing_Farid_Checkpoint_One",             new SplitPair {SplitName = "Farid 1",            SplitFlag = false}},
            {"pariswing_Farid_LoseTheCops",                new SplitPair {SplitName = "Farid Lose Cops",    SplitFlag = false}},
            {"pariswing_Farid_SideRace",                   new SplitPair {SplitName = "Farid Siderace",     SplitFlag = false}},
            {"paris_Parfait_Checkpoint_One",               new SplitPair {SplitName = "Parfait 1",          SplitFlag = false}},
            {"paris_Parfait_Checkpoint_Two",               new SplitPair {SplitName = "Parfait 2",          SplitFlag = false}},
            {"tokyochris_Shing_Checkpoint_One",            new SplitPair {SplitName = "Shing 1",            SplitFlag = false}},
            {"tokyochris_Shing_SideRace",                  new SplitPair {SplitName = "Shing Siderace",     SplitFlag = false}},
            {"tokyochris_Shing_Checkpoint_Two",            new SplitPair {SplitName = "Shing 2",            SplitFlag = false}},
            {"tokyomauro_Ricky_Checkpoint_One",            new SplitPair {SplitName = "Ricky 1",            SplitFlag = false}},
            {"tokyomauro_Ricky_Checkpoint_Two",            new SplitPair {SplitName = "Ricky 2",            SplitFlag = false}},
            {"tokyo_Haley_Checkpoint_One",                 new SplitPair {SplitName = "Haley 1",            SplitFlag = false}},
            {"tokyo_Haley_Checkpoint_Two",                 new SplitPair {SplitName = "Haley 2",            SplitFlag = false}},
            {"tokyomarc_Nikko_Checkpoint_One",             new SplitPair {SplitName = "Nikko 1",            SplitFlag = false}},
            {"tokyomarc_Nikko_Checkpoint_Two",             new SplitPair {SplitName = "Nikko 2",            SplitFlag = false}},
            {"tokyowing_Zen_checkpoint_one",               new SplitPair {SplitName = "Zen 1",              SplitFlag = false}},
            {"tokyowing_Zen_checkpoint_two",               new SplitPair {SplitName = "Zen 2",              SplitFlag = false}},
            {"tokyo_Kenichi_Checkpoint_One",               new SplitPair {SplitName = "Kenichi 1",          SplitFlag = false}},
            {"tokyo_Kenichi_Checkpoint_Two",               new SplitPair {SplitName = "Kenichi 2",          SplitFlag = false}},
            {"tokyo_Kenichi_Checkpoint_Three",             new SplitPair {SplitName = "Kenichi 3",          SplitFlag = false}},
            {"tokyochris_Makoto_Checkpoint_One",           new SplitPair {SplitName = "Makoto 1",           SplitFlag = false}},
            {"tokyochris_Makoto_Checkpoint_Two",           new SplitPair {SplitName = "Makoto 2",           SplitFlag = false}},
            {"tokyomarc_WorldChampTokyo_Checkpoint_One",   new SplitPair {SplitName = "Savo Tokyo 1",       SplitFlag = false}},
            {"tokyomarc_WorldChampTokyo_Checkpoint_Two",   new SplitPair {SplitName = "Savo Tokyo 2",       SplitFlag = false}},
            {"paris_WorldChampParis_Checkpoint_One",       new SplitPair {SplitName = "Savo Paris 1",       SplitFlag = false}},
            {"paris_WorldChampParis_Checkpoint_Two",       new SplitPair {SplitName = "Savo Paris 2",       SplitFlag = false}},
            {"lachrisbeta_WorldChampLA_Checkpoint_One",    new SplitPair {SplitName = "Savo LA 1",          SplitFlag = false}},
            {"laWC_WorldChampLA_Checkpoint_Two",           new SplitPair {SplitName = "Savo LA 2",          SplitFlag = false}},
            {"lamauro_Arcade_Circuit_One",                 new SplitPair {SplitName = "LA Arcade 1",        SplitFlag = false}},
            {"lachris_Arcade_Circuit_Two",                 new SplitPair {SplitName = "LA Arcade 2",        SplitFlag = false}},
            {"lachris_Arcade_Circuit_Three",               new SplitPair {SplitName = "LA Arcade 3",        SplitFlag = false}},
            {"lachris_Arcade_Circuit_Four",                new SplitPair {SplitName = "LA Arcade 4",        SplitFlag = false}},
            {"lachris_Arcade_Circuit_Five",                new SplitPair {SplitName = "LA Arcade 5",        SplitFlag = false}},
            {"paris_Arcade_Circuit_One",                   new SplitPair {SplitName = "Paris Arcade 1",     SplitFlag = false}},
            {"paris_Arcade_Circuit_Two",                   new SplitPair {SplitName = "Paris Arcade 2",     SplitFlag = false}},
            {"paris_Arcade_Circuit_Three",                 new SplitPair {SplitName = "Paris Arcade 3",     SplitFlag = false}},
            {"paris_Arcade_Circuit_Four",                  new SplitPair {SplitName = "Paris Arcade 4",     SplitFlag = false}},
            {"paris_Arcade_Circuit_Five",                  new SplitPair {SplitName = "Paris Arcade 5",     SplitFlag = false}},
            {"paris_Arcade_Circuit_Six",                   new SplitPair {SplitName = "Paris Arcade 6",     SplitFlag = false}},
            {"tokyoarcade_Arcade_Circuit_One",             new SplitPair {SplitName = "Tokyo Arcade 1",     SplitFlag = false}},
            {"tokyoarcade_Arcade_Circuit_Two",             new SplitPair {SplitName = "Tokyo Arcade 2",     SplitFlag = false}},
            {"tokyowing_Arcade_Circuit_Three",             new SplitPair {SplitName = "Tokyo Arcade 3",     SplitFlag = false}},
            {"tokyoarcade_Arcade_Circuit_Four",            new SplitPair {SplitName = "Tokyo Arcade 4",     SplitFlag = false}},
            {"tokyoarcade_Arcade_Circuit_Five",            new SplitPair {SplitName = "Tokyo Arcade 5",     SplitFlag = false}},
            {"tokyotroy_Arcade_Circuit_Six",               new SplitPair {SplitName = "Tokyo Arcade 6",     SplitFlag = false}},
            {"tokyotroy_Arcade_Circuit_Seven",             new SplitPair {SplitName = "Tokyo Arcade 7",     SplitFlag = false}}
        };
        
        Component _parent;
        Process _mc2;
        IntPtr _baseaddr;
        IntPtr _hook;
        Version _version;

        MemoryWatcher<byte> _loading, _disclaimer;
        MemoryWatcherList _memory = new MemoryWatcherList();
        MemoryWatcher<byte> IsRace;
        StringWatcher CurrentRace;

        X86Generator _maingen = new X86Generator();
        X86Generator _game = new X86Generator();
        X86Generator _movie = new X86Generator();
        X86Generator _frontend = new X86Generator();
        X86Generator _raceeditor = new X86Generator();
        X86Generator _carviewer = new X86Generator();
        X86Generator _jmp = new X86Generator();

        public event EventHandler OnLoadStartAfterFrontend;
        public event EventHandler OnRaceStart;

        public Hooks(Component parent)
        {
            _parent = parent;
        }

        private void AddHooks()
        {
            _maingen.Clear();
            int loading = _maingen.DataByte(0x00);

            int gamehead = WriteHead(_maingen, _game);
            int moviehead = WriteHead(_maingen, _movie);
            int frontendhead = WriteHead(_maingen, _frontend);
            int raceeditorhead = WriteHead(_maingen, _raceeditor);
            int carviewerhead = WriteHead(_maingen, _carviewer);

            int game = GenWrap(_maingen, loading, gamehead, off: 1);
            int movie = GenWrap(_maingen, loading, moviehead);
            int frontend = GenWrap(_maingen, loading, frontendhead, end: 0x02);
            int raceeditor = GenWrap(_maingen, loading, raceeditorhead);
            int carviewer = GenWrap(_maingen, loading, carviewerhead);

            _hook = _maingen.Install(_mc2);
            InstallJmp(_game, game);
            InstallJmp(_movie, movie);
            InstallJmp(_frontend, frontend);
            InstallJmp(_raceeditor, raceeditor);
            InstallJmp(_carviewer, carviewer);

            _loading = new MemoryWatcher<byte>(_hook);
            _loading.OnChanged += On_Loading;
            _memory.Add(_loading);

            _disclaimer = new MemoryWatcher<byte>(_baseaddr + 0x2622B0);
            _disclaimer.OnChanged += On_Disclaimer;
            _memory.Add(_disclaimer);

            IsRace = new MemoryWatcher<byte>(_baseaddr + 0x2C2EE0);
            _memory.Add(IsRace);
            CurrentRace = new StringWatcher(_baseaddr + 0x2C2EE0, 64);
            _memory.Add(CurrentRace);
            
        }

        private bool TestProcess(Process process)
        {
            if (!process.ProcessName.Contains("mc2")) return false;
            if (process.HasExited) return false;
            if (process.Is64Bit()) return false;
            _baseaddr = process.MainModuleWow64Safe().BaseAddress;
            _version = Version.GetVersion(process, _baseaddr);
            if (_version == null) return false;

            // Steam's DRM encrypts the .text section, so verify the text is decrypted before hooking.
            GenSPM(_game, _baseaddr, _version.game);
            if (!_game.VerifyInstall(process)) return false;
            GenPPO(_movie, _baseaddr, _version.movie, _version.moviestr);
            if (!_movie.VerifyInstall(process)) return false;
            GenPPO(_frontend, _baseaddr, _version.frontend, _version.frontendstr);
            if (!_frontend.VerifyInstall(process)) return false;
            GenPPO(_raceeditor, _baseaddr, _version.raceeditor, _version.raceeditorstr);
            if (!_raceeditor.VerifyInstall(process)) return false;
            GenPPO(_carviewer, _baseaddr, _version.carviewer, _version.carviewerstr);
            if (!_carviewer.VerifyInstall(process)) return false;

            _mc2 = process;
            AddHooks();
            return true;
        }

        public void Update()
        {
            try
            {
                if (_mc2 != null && _mc2.HasExited)
                {
                    _memory.Clear();
                    _parent.On_Loading(false);
                    _mc2 = null;
                }

                if (_mc2 == null)
                    foreach (Process p in Process.GetProcesses())
                        if (TestProcess(p)) break;

                if (_mc2 != null)
                {
                    _memory.UpdateAll(_mc2);

                    if (_loading.Old == 2 && _loading.Current == 1)
                    {
                        this.OnLoadStartAfterFrontend?.Invoke(this, EventArgs.Empty);
                    }

                    if(IsRace.Old != IsRace.Current && IsRace.Current != 0
                       && CurrentRace.Current == "lamauro_Moses_Checkpoint_One")
                    {
                        this.OnRaceStart?.Invoke(this, EventArgs.Empty);
                    }
                } 
            }
            catch
            {
                // Sometimes reads or writes fail due to race conditions.
                // Treat these exceptions as an exit event.
                _memory.Clear();
                _parent.On_Loading(false);
                _mc2 = null;
            }
        }

        public void Dispose()
        {
            try
            {
                if (_mc2 != null && !_mc2.HasExited)
                {
                    _game.WriteInstall(_mc2);
                    _movie.WriteInstall(_mc2);
                    _frontend.WriteInstall(_mc2);
                    _raceeditor.WriteInstall(_mc2);
                    _carviewer.WriteInstall(_mc2);

                    _mc2.FreeMemory(_hook);
                }
            }
            finally
            {
                _mc2 = null;
            }
        }

        private void On_Loading(byte old, byte current) => _parent.On_Loading(current == 2 ? _disclaimer.Current != 0 : current != 0);

        private void On_Disclaimer(byte old, byte current) => _parent.On_Loading(_loading.Current == 2 ? current != 0 : _loading.Current != 0);

        private static int GenWrap(X86Generator generator, int loading, int dest, short off = 0, byte end = 0x00) {
            int res = generator.MovByteMIL(loading, 0x01);
            generator.CallStdL(dest, off);
            generator.MovByteMIL(loading, end);
            generator.Retn((short) (off * 4));
            return res;
        }

        private static void GenSPM(X86Generator gen, IntPtr baseaddr, int codeoff)
        {
            gen.Clear();
            gen.SetInstall(baseaddr + codeoff);
            gen.SubRI(X86Generator.Registers.ESP, 0x28);
            gen.PushReg(X86Generator.Registers.ESI);
            gen.MovRR(X86Generator.Registers.ESI, X86Generator.Registers.ECX);
        }

        private static void GenPPO(X86Generator gen, IntPtr baseaddr, int codeoff, int stroff)
        {
            gen.Clear();
            gen.SetInstall(baseaddr + codeoff);
            gen.PushReg(X86Generator.Registers.ESI);
            gen.PushR(baseaddr + stroff);
        }

        private static int WriteHead(X86Generator gen, X86Generator ingen)
        {
            int res = gen.WriteGen(ingen);
            gen.JumpR(ingen.GetInstall() + ingen.GetCount());
            return res;
        }

        private void InstallJmp(X86Generator ingen, int hookoff)
        {
            _jmp.Clear();
            _jmp.SetInstall(ingen.GetInstall());
            _jmp.JumpR(_hook + hookoff);
            _jmp.WriteInstall(_mc2);
        }
    }
}
