namespace LiveSplit.MC2
{
    partial class Settings
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelOptions = new System.Windows.Forms.Panel();
            this.labelOptions = new System.Windows.Forms.Label();
            this.checkBoxStart = new System.Windows.Forms.CheckBox();
            this.checkBoxSplit = new System.Windows.Forms.CheckBox();
            this.checkBoxReset = new System.Windows.Forms.CheckBox();
            this.panelSplits = new System.Windows.Forms.Panel();
            this.labelSplits = new System.Windows.Forms.Label();
            this.treeViewSplits = new System.Windows.Forms.TreeView();
            this.buttonUncheckAll = new System.Windows.Forms.Button();
            this.buttonCheckAll = new System.Windows.Forms.Button();
            this.buttonDefault = new System.Windows.Forms.Button();
            this.panelOptions.SuspendLayout();
            this.panelSplits.SuspendLayout();
            this.SuspendLayout();
            //
            // panelOptions
            //
            this.panelOptions.Controls.Add(this.checkBoxReset);
            this.panelOptions.Controls.Add(this.checkBoxSplit);
            this.panelOptions.Controls.Add(this.checkBoxStart);
            this.panelOptions.Controls.Add(this.labelOptions);
            this.panelOptions.Location = new System.Drawing.Point(3, 3);
            this.panelOptions.Name = "panelOptions";
            this.panelOptions.Size = new System.Drawing.Size(465, 23);
            this.panelOptions.TabIndex = 0;
            //
            // labelOptions
            //
            this.labelOptions.AutoSize = true;
            this.labelOptions.Location = new System.Drawing.Point(3, 5);
            this.labelOptions.Name = "labelOptions";
            this.labelOptions.Size = new System.Drawing.Size(46, 13);
            this.labelOptions.TabIndex = 0;
            this.labelOptions.Text = "Options:";
            //
            // checkBoxStart
            //
            this.checkBoxStart.Checked = true;
            this.checkBoxStart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxStart.AutoSize = true;
            this.checkBoxStart.Location = new System.Drawing.Point(55, 3);
            this.checkBoxStart.Name = "checkBoxStart";
            this.checkBoxStart.Size = new System.Drawing.Size(48, 17);
            this.checkBoxStart.TabIndex = 1;
            this.checkBoxStart.Text = "Start";
            this.checkBoxStart.UseVisualStyleBackColor = true;
            //
            // checkBoxSplit
            //
            this.checkBoxSplit.Checked = true;
            this.checkBoxSplit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSplit.AutoSize = true;
            this.checkBoxSplit.Location = new System.Drawing.Point(109, 3);
            this.checkBoxSplit.Name = "checkBoxSplit";
            this.checkBoxSplit.Size = new System.Drawing.Size(46, 17);
            this.checkBoxSplit.TabIndex = 2;
            this.checkBoxSplit.Text = "Split";
            this.checkBoxSplit.UseVisualStyleBackColor = true;
            //
            // checkBoxReset
            //
            this.checkBoxReset.Checked = false;
            this.checkBoxReset.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.checkBoxReset.AutoSize = true;
            this.checkBoxReset.Location = new System.Drawing.Point(161, 3);
            this.checkBoxReset.Name = "checkBoxReset";
            this.checkBoxReset.Size = new System.Drawing.Size(98, 17);
            this.checkBoxReset.TabIndex = 3;
            this.checkBoxReset.Text = "Reset";
            this.checkBoxReset.UseVisualStyleBackColor = true;
            //
            // panelSplits
            //
            this.panelSplits.Controls.Add(this.buttonDefault);
            this.panelSplits.Controls.Add(this.buttonCheckAll);
            this.panelSplits.Controls.Add(this.buttonUncheckAll);
            this.panelSplits.Controls.Add(this.treeViewSplits);
            this.panelSplits.Controls.Add(this.labelSplits);
            this.panelSplits.Location = new System.Drawing.Point(3, 29);
            this.panelSplits.Name = "panelSplits";
            this.panelSplits.Size = new System.Drawing.Size(468, 463);
            this.panelSplits.TabIndex = 1;
            //
            // labelSplits
            //
            this.labelSplits.AutoSize = true;
            this.labelSplits.Location = new System.Drawing.Point(3, 5);
            this.labelSplits.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.labelSplits.Name = "labelSplits";
            this.labelSplits.Size = new System.Drawing.Size(35, 13);
            this.labelSplits.TabIndex = 0;
            this.labelSplits.Text = "Splits:";
            //
            // treeViewSplits
            //
            this.treeViewSplits.Location = new System.Drawing.Point(38, 1);
            this.treeViewSplits.Name = "treeViewSplits";
            this.treeViewSplits.Size = new System.Drawing.Size(427, 429);
            this.treeViewSplits.TabIndex = 1;
            this.treeViewSplits.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewSplits_AfterCheck);
            //
            // buttonUncheckAll
            //
            this.buttonUncheckAll.Location = new System.Drawing.Point(230, 434);
            this.buttonUncheckAll.Name = "buttonUncheckAll";
            this.buttonUncheckAll.Size = new System.Drawing.Size(75, 23);
            this.buttonUncheckAll.TabIndex = 7;
            this.buttonUncheckAll.Text = "Uncheck all";
            this.buttonUncheckAll.UseVisualStyleBackColor = true;
            this.buttonUncheckAll.Click += new System.EventHandler(this.buttonUncheckAll_Click);
            //
            // buttonCheckAll
            //
            this.buttonCheckAll.Location = new System.Drawing.Point(310, 434);
            this.buttonCheckAll.Name = "buttonCheckAll";
            this.buttonCheckAll.Size = new System.Drawing.Size(75, 23);
            this.buttonCheckAll.TabIndex = 8;
            this.buttonCheckAll.Text = "Check all";
            this.buttonCheckAll.UseVisualStyleBackColor = true;
            this.buttonCheckAll.Click += new System.EventHandler(this.buttonCheckAll_Click);
            //
            // buttonDefault
            //
            this.buttonDefault.Location = new System.Drawing.Point(390, 434);
            this.buttonDefault.Name = "buttonDefault";
            this.buttonDefault.Size = new System.Drawing.Size(75, 23);
            this.buttonDefault.TabIndex = 9;
            this.buttonDefault.Text = "Default";
            this.buttonDefault.UseVisualStyleBackColor = true;
            this.buttonDefault.Click += new System.EventHandler(this.buttonDefault_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelSplits);
            this.Controls.Add(this.panelOptions);
            this.Name = "Settings";
            this.Text = "Settings";
            this.Size = new System.Drawing.Size(476, 504);
            this.panelOptions.ResumeLayout(false);
            this.panelOptions.PerformLayout();
            this.panelSplits.ResumeLayout(false);
            this.panelSplits.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        
        private System.Windows.Forms.Panel panelOptions;
        private System.Windows.Forms.Label labelOptions;
        private System.Windows.Forms.CheckBox checkBoxStart;
        private System.Windows.Forms.CheckBox checkBoxSplit;
        private System.Windows.Forms.CheckBox checkBoxReset;
        private System.Windows.Forms.Panel panelSplits;
        private System.Windows.Forms.Label labelSplits;
        private System.Windows.Forms.TreeView treeViewSplits;
        private System.Windows.Forms.Button buttonUncheckAll;
        private System.Windows.Forms.Button buttonCheckAll;
        private System.Windows.Forms.Button buttonDefault;
    }
}
