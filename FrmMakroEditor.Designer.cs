namespace RightClickAmplifier
{
    partial class FrmMakroEditor
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtMakroName = new System.Windows.Forms.TextBox();
            this.cmdSaveMakro = new System.Windows.Forms.Button();
            this.customListBox1 = new RightClickAmplifier.CustomListBox();
            this.cmdAddFunction = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtExtensions = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "name:";
            // 
            // txtMakroName
            // 
            this.txtMakroName.Location = new System.Drawing.Point(116, 29);
            this.txtMakroName.Name = "txtMakroName";
            this.txtMakroName.Size = new System.Drawing.Size(209, 22);
            this.txtMakroName.TabIndex = 1;
            // 
            // cmdSaveMakro
            // 
            this.cmdSaveMakro.Location = new System.Drawing.Point(605, 371);
            this.cmdSaveMakro.Name = "cmdSaveMakro";
            this.cmdSaveMakro.Size = new System.Drawing.Size(75, 23);
            this.cmdSaveMakro.TabIndex = 2;
            this.cmdSaveMakro.Text = "save";
            this.cmdSaveMakro.UseVisualStyleBackColor = true;
            this.cmdSaveMakro.Click += new System.EventHandler(this.cmdSaveMakro_Click);
            // 
            // customListBox1
            // 
            this.customListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customListBox1.GroupText = "Functions";
            this.customListBox1.Items.Add("asd");
            this.customListBox1.Items.Add("wer");
            this.customListBox1.Location = new System.Drawing.Point(28, 153);
            this.customListBox1.Name = "customListBox1";
            this.customListBox1.Size = new System.Drawing.Size(410, 443);
            this.customListBox1.TabIndex = 3;
            this.customListBox1.ButtonEditClick += new System.EventHandler(this.customListBox1_ButtonEditClick);
            this.customListBox1.ButtonDeleteClick += new System.EventHandler(this.customListBox1_ButtonDeleteClick);
            // 
            // cmdAddFunction
            // 
            this.cmdAddFunction.Location = new System.Drawing.Point(493, 166);
            this.cmdAddFunction.Name = "cmdAddFunction";
            this.cmdAddFunction.Size = new System.Drawing.Size(75, 23);
            this.cmdAddFunction.TabIndex = 4;
            this.cmdAddFunction.Text = "add funtion";
            this.cmdAddFunction.UseVisualStyleBackColor = true;
            this.cmdAddFunction.Click += new System.EventHandler(this.cmdAddFunction_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "extensions:";
            // 
            // txtExtensions
            // 
            this.txtExtensions.Location = new System.Drawing.Point(116, 95);
            this.txtExtensions.Name = "txtExtensions";
            this.txtExtensions.Size = new System.Drawing.Size(209, 22);
            this.txtExtensions.TabIndex = 6;
            // 
            // FrmMakroEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 636);
            this.Controls.Add(this.txtExtensions);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdAddFunction);
            this.Controls.Add(this.customListBox1);
            this.Controls.Add(this.cmdSaveMakro);
            this.Controls.Add(this.txtMakroName);
            this.Controls.Add(this.label1);
            this.Name = "FrmMakroEditor";
            this.Text = "FrmMakroEditor";
            this.Load += new System.EventHandler(this.FrmMakroEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMakroName;
        private System.Windows.Forms.Button cmdSaveMakro;
        private CustomListBox customListBox1;
        private System.Windows.Forms.Button cmdAddFunction;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtExtensions;
    }
}