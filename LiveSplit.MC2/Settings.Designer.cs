using System.Windows.Forms;

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
            this.checkBoxHookman = new System.Windows.Forms.CheckBox();
            this.checkBoxRace = new System.Windows.Forms.CheckBox();
            this.checkBoxAnyFinish = new System.Windows.Forms.CheckBox();
            this.checkBoxHundoFinish = new System.Windows.Forms.CheckBox();
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
            this.panelSplits.Controls.Add(this.checkBoxHookman);
            this.panelSplits.Controls.Add(this.checkBoxRace);
            this.panelSplits.Controls.Add(this.checkBoxAnyFinish);
            this.panelSplits.Controls.Add(this.checkBoxHundoFinish);
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
            // checkBoxSplitHookman
            //
            this.checkBoxHookman.Checked = true;
            this.checkBoxHookman.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHookman.AutoSize = true;
            this.checkBoxHookman.Location = new System.Drawing.Point(43, 1);
            this.checkBoxHookman.Name = "checkBoxSplitHookman";
            this.checkBoxHookman.Size = new System.Drawing.Size(48, 17);
            this.checkBoxHookman.TabIndex = 1;
            this.checkBoxHookman.Text = "Hookman (complete)";
            this.checkBoxHookman.UseVisualStyleBackColor = true;
            this.checkBoxHookman.CheckStateChanged += new System.EventHandler(this.checkBoxHookman_CheckStateChanged);
            //
            // checkBoxSplitRace
            //
            this.checkBoxRace.Checked = true;
            this.checkBoxRace.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRace.AutoSize = true;
            this.checkBoxRace.Location = new System.Drawing.Point(43, 18);
            this.checkBoxRace.Name = "checkBoxSplitRace";
            this.checkBoxRace.Size = new System.Drawing.Size(48, 17);
            this.checkBoxRace.TabIndex = 1;
            this.checkBoxRace.Text = "Race (start)";
            this.checkBoxRace.UseVisualStyleBackColor = true;
            //
            // checkBoxAnyFinish
            //
            this.checkBoxAnyFinish.Checked = true;
            this.checkBoxAnyFinish.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAnyFinish.AutoSize = true;
            this.checkBoxAnyFinish.Location = new System.Drawing.Point(43, 35);
            this.checkBoxAnyFinish.Name = "checkBoxSplitRace";
            this.checkBoxAnyFinish.Size = new System.Drawing.Size(48, 17);
            this.checkBoxAnyFinish.TabIndex = 1;
            this.checkBoxAnyFinish.Text = "Any% Final Split";
            this.checkBoxAnyFinish.UseVisualStyleBackColor = true;
            //
            // checkBoxHundoFinish
            //
            this.checkBoxHundoFinish.Enabled = false;
            this.checkBoxHundoFinish.Checked = false;
            this.checkBoxHundoFinish.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.checkBoxHundoFinish.AutoSize = true;
            this.checkBoxHundoFinish.Location = new System.Drawing.Point(43, 52);
            this.checkBoxHundoFinish.Name = "checkBoxSplitRace";
            this.checkBoxHundoFinish.Size = new System.Drawing.Size(48, 17);
            this.checkBoxHundoFinish.TabIndex = 1;
            this.checkBoxHundoFinish.Text = "100% Final Split";
            this.checkBoxHundoFinish.UseVisualStyleBackColor = true;
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
        private System.Windows.Forms.CheckBox checkBoxHookman;
        private System.Windows.Forms.CheckBox checkBoxRace;
        private System.Windows.Forms.CheckBox checkBoxAnyFinish;
        private System.Windows.Forms.CheckBox checkBoxHundoFinish;
    }
}
