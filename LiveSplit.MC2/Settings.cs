using System;
using System.Windows.Forms;
using System.Xml;

namespace LiveSplit.MC2
{
    public partial class Settings : UserControl
    {   
        public bool Start { get; set; }
        public bool Split { get; set; }
        public bool Reset { get; set; }
        public bool SplitHookman { get; set; }
        public bool SplitRace { get; set; }
        public bool FinishAny { get; set; }
        public bool FinishHundo { get; set; }

        public Settings()
        {
            InitializeComponent();

            checkBoxStart.DataBindings.Add("Checked", this, "Start", false, DataSourceUpdateMode.OnPropertyChanged);
            checkBoxSplit.DataBindings.Add("Checked", this, "Split", false, DataSourceUpdateMode.OnPropertyChanged);
            checkBoxReset.DataBindings.Add("Checked", this, "Reset", false, DataSourceUpdateMode.OnPropertyChanged);
            checkBoxHookman.DataBindings.Add("Checked", this, "SplitHookman", false, DataSourceUpdateMode.OnPropertyChanged);
            checkBoxRace.DataBindings.Add("Checked", this, "SplitRace", false, DataSourceUpdateMode.OnPropertyChanged);
            checkBoxAnyFinish.DataBindings.Add("Checked", this, "FinishAny", false, DataSourceUpdateMode.OnPropertyChanged);
            checkBoxHundoFinish.DataBindings.Add("Checked", this, "FinishHundo", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public XmlNode GetSettings(XmlDocument document)
        {
            XmlElement settingsNode = document.CreateElement("Settings");

            settingsNode.AppendChild(ToElement(document, "Start", Start));
            settingsNode.AppendChild(ToElement(document, "Split", Split));
            settingsNode.AppendChild(ToElement(document, "Reset", Reset));
            settingsNode.AppendChild(ToElement(document, "SplitHookman", SplitHookman));
            settingsNode.AppendChild(ToElement(document, "SplitRace", SplitRace));
            settingsNode.AppendChild(ToElement(document, "FinishAny", FinishAny));
            settingsNode.AppendChild(ToElement(document, "FinishHundo", FinishHundo));

            return settingsNode;
        }

        public void SetSettings(XmlNode settings)
        {
            Start = ParseBool(settings, "Start");
            Split = ParseBool(settings, "Split");
            Reset = ParseBool(settings, "Reset");
            SplitHookman = ParseBool(settings, "SplitHookman");
            SplitRace = ParseBool(settings, "SplitRace");
            FinishAny = ParseBool(settings, "FinishAny");
            FinishHundo = ParseBool(settings, "FinishHundo");

        }

        private void checkBoxHookman_CheckStateChanged(object sender, EventArgs e)
        {
            checkBoxRace.Enabled = checkBoxHookman.Checked;

            if (!checkBoxHookman.Checked)
            {
                checkBoxRace.Checked = false;
            }
        }

        /// <summary>
        /// Parses the boolean values based on the serialized version of the settings.
        /// </summary>
        private static bool ParseBool(XmlNode settings, string setting, bool default_ = false)
            => settings[setting] != null ? (Boolean.TryParse(settings[setting].InnerText, out bool val) ? val : default_) : default_;
        /// <summary>
        /// Returns a serialized version of a setting based on its identifier.
        /// </summary>
        private static XmlElement ToElement<T>(XmlDocument document, string name, T value)
        {
            XmlElement str = document.CreateElement(name);
            str.InnerText = value.ToString();
            return str;
        }
    }
}
