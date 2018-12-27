namespace RightClickAmplifier
{
    partial class CustomListBox
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
            this.grpBox = new System.Windows.Forms.GroupBox();
            this.panItems = new System.Windows.Forms.Panel();
            this.grpBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBox
            // 
            this.grpBox.Controls.Add(this.panItems);
            this.grpBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBox.Location = new System.Drawing.Point(0, 0);
            this.grpBox.Name = "grpBox";
            this.grpBox.Size = new System.Drawing.Size(431, 423);
            this.grpBox.TabIndex = 0;
            this.grpBox.TabStop = false;
            this.grpBox.Text = "groupBox1";
            this.grpBox.Enter += new System.EventHandler(this.grpBox_Enter);
            // 
            // panItems
            // 
            this.panItems.AutoScroll = true;
            this.panItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panItems.Location = new System.Drawing.Point(3, 18);
            this.panItems.Name = "panItems";
            this.panItems.Size = new System.Drawing.Size(425, 402);
            this.panItems.TabIndex = 0;
            // 
            // CustomListBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpBox);
            this.Name = "CustomListBox";
            this.Size = new System.Drawing.Size(431, 423);
            this.grpBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBox;
        private System.Windows.Forms.Panel panItems;
    }
}
