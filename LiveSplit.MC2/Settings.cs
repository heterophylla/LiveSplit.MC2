using System;
using System.Windows.Forms;
using System.Xml;

namespace LiveSplit.MC2
{
    public partial class Settings : UserControl
    {   
        private TreeNode nodeRaces;
        private TreeNode nodeHookman;
        private TreeNode nodeFinishAny;
        private TreeNode nodeFinishHundo;

        public Settings()
        {
            InitializeComponent();
            InitializeTreeView();
        }

        public XmlNode GetSettings(XmlDocument document)
        {
            XmlElement settingsNode = document.CreateElement("Settings");

            // Save Basic Checkboxes
            settingsNode.AppendChild(ToElement(document, "Start", checkBoxStart.Checked));
            settingsNode.AppendChild(ToElement(document, "Split", checkBoxSplit.Checked));
            settingsNode.AppendChild(ToElement(document, "Reset", checkBoxReset.Checked));

            // Save TreeView (Splits) Custom Settings
            XmlElement customSettingsNode = document.CreateElement("CustomSettings");
            SaveTreeNodes(document, customSettingsNode, treeViewSplits.Nodes);
            settingsNode.AppendChild(customSettingsNode);

            return settingsNode;
        }

        public void SetSettings(XmlNode settings)
        {
            XmlElement element = (XmlElement) settings;
            if (element == null) return;

            // Load Basic Checkboxes
            checkBoxStart.Checked = ParseBool(settings, "Start", true);
            checkBoxSplit.Checked = ParseBool(settings, "Split", true);
            checkBoxReset.Checked = ParseBool(settings, "Reset", true);

            // Load TreeView Custom Settings
            XmlNode customSettingsNode = settings["CustomSettings"];
            if (customSettingsNode != null)
            {
                LoadTreeNodes(customSettingsNode, treeViewSplits.Nodes);
            }
        }

        private void InitializeTreeView()
        {
            nodeRaces = new TreeNode("Race (Start)");
            nodeRaces.Checked = true;
            nodeRaces.Tag = false;
            nodeRaces.Nodes.Add(new TreeNode("Race 1"));
            nodeRaces.Nodes.Add(new TreeNode("Race 2"));
            nodeRaces.Nodes.Add(new TreeNode("Race 3"));
            nodeRaces.Collapse();

            nodeHookman = new TreeNode("Hookman (Complete)");
            nodeHookman.Checked = true;
            nodeHookman.Tag = false;
            nodeHookman.Nodes.Add(new TreeNode("Hookman 1"));
            nodeHookman.Nodes.Add(new TreeNode("Hookman 2"));
            nodeHookman.Nodes.Add(new TreeNode("Hookman 3"));
            nodeHookman.Collapse();

            nodeFinishAny = new TreeNode("Any% final Split");
            nodeFinishAny.Checked = true;
            nodeFinishAny.Tag = false;

            nodeFinishHundo = new TreeNode("Hundo% final Split");
            nodeFinishHundo.Checked = false;
            nodeFinishHundo.Tag = false;

            treeViewSplits.Nodes.Add(nodeRaces);
            treeViewSplits.Nodes.Add(nodeHookman);
            treeViewSplits.Nodes.Add(nodeFinishAny);
            treeViewSplits.Nodes.Add(nodeFinishHundo);
            treeViewSplits.CheckBoxes = true;
            treeViewSplits.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewSplits_AfterCheck);
        }

        private void treeViewSplits_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Nodes.Count > 0)
                {
                    foreach (TreeNode node in e.Node.Nodes)
                    {
                        node.Checked = e.Node.Checked;
                    }
                }
                else
                {
                    TreeNode parentNode = e.Node.Parent;
                    if (parentNode != null)
                    {
                        bool allChecked = true;
                        bool allUnchecked = true;
                        foreach (TreeNode node in parentNode.Nodes)
                        {
                            if (!node.Checked)
                            {
                                allChecked = false;
                            }
                            if (node.Checked)
                            {
                                allUnchecked = false;
                            }
                        }
                        if (allChecked)
                        {
                            parentNode.Checked = true;
                        }
                        else if (allUnchecked)
                        {
                            parentNode.Checked = false;
                        }
                        else
                        {
                            parentNode.Checked = false;
                        }
                    }
                }
            }
        }

        private void buttonUncheckAll_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in treeViewSplits.Nodes)
            {
                UncheckAllNodes(node);
            }
        }

        private void UncheckAllNodes(TreeNode node)
        {
            node.Checked = false;
            foreach (TreeNode childNode in node.Nodes)
            {
                UncheckAllNodes(childNode);
            }
        }

        private void buttonCheckAll_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in treeViewSplits.Nodes)
            {
                CheckAllNodes(node);
            }
        }

        private void CheckAllNodes(TreeNode node)
        {
            node.Checked = true;
            foreach (TreeNode childNode in node.Nodes)
            {
                CheckAllNodes(childNode);
            }
        }

        private void buttonDefault_Click(object sender, EventArgs e)
        {
            // Implement default behavior as needed
        }

        private void SaveTreeNodes(XmlDocument document, XmlElement parentElement, TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                // Use the node's text as a safe XML tag name (strip out invalid chars if necessary)
                string safeName = node.Text.Replace(" ", "").Replace("(", "").Replace(")", "").Replace("%", "");
                parentElement.AppendChild(ToElement(document, safeName, node.Checked));

                if (node.Nodes.Count > 0)
                {
                    SaveTreeNodes(document, parentElement, node.Nodes);
                }
            }
        }

        private void LoadTreeNodes(XmlNode parentNode, TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                string safeName = node.Text.Replace(" ", "").Replace("(", "").Replace(")", "").Replace("%", "");
                node.Checked = ParseBool(parentNode, safeName, node.Checked); // Default to whatever it initialized to

                if (node.Nodes.Count > 0)
                {
                    LoadTreeNodes(parentNode, node.Nodes);
                }
            }
        }

        static bool ParseBool(XmlNode settings, string setting, bool default_ = false)
        {
            bool b;
            return settings[setting] != null ? (bool.TryParse(settings[setting].InnerText, out b) ? b : default_) : default_;
        }

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
