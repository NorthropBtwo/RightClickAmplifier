namespace RightClickAmplifier
{
    partial class frmMain
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
            this.cmdAddMakro = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdSaveReg = new System.Windows.Forms.Button();
            this.cmdCleanReg = new System.Windows.Forms.Button();
            this.cmdFastClean = new System.Windows.Forms.Button();
            this.cmd2pdf = new System.Windows.Forms.Button();
            this.cndSave = new System.Windows.Forms.Button();
            this.cmdCreateSoftLink = new System.Windows.Forms.Button();
            this.grpMakros = new RightClickAmplifier.CustomListBox();
            this.SuspendLayout();
            // 
            // cmdAddMakro
            // 
            this.cmdAddMakro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAddMakro.Location = new System.Drawing.Point(681, 53);
            this.cmdAddMakro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdAddMakro.Name = "cmdAddMakro";
            this.cmdAddMakro.Size = new System.Drawing.Size(125, 25);
            this.cmdAddMakro.TabIndex = 1;
            this.cmdAddMakro.Text = "create Makro";
            this.cmdAddMakro.UseVisualStyleBackColor = true;
            this.cmdAddMakro.Click += new System.EventHandler(this.cmdAddMakro_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(690, 164);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 2;
            this.textBox1.Visible = false;
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Items.AddRange(new object[] {
            "asdasd",
            "asdasdsad",
            "asdasdsd",
            "asdsdsd"});
            this.listBox1.Location = new System.Drawing.Point(681, 242);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(125, 84);
            this.listBox1.TabIndex = 3;
            this.listBox1.Visible = false;
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.Location = new System.Drawing.Point(681, 393);
            this.cmdSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(125, 23);
            this.cmdSave.TabIndex = 4;
            this.cmdSave.Text = "save XML";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Visible = false;
            this.cmdSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdSaveReg
            // 
            this.cmdSaveReg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSaveReg.Location = new System.Drawing.Point(681, 366);
            this.cmdSaveReg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdSaveReg.Name = "cmdSaveReg";
            this.cmdSaveReg.Size = new System.Drawing.Size(125, 23);
            this.cmdSaveReg.TabIndex = 5;
            this.cmdSaveReg.Text = "save Reg";
            this.cmdSaveReg.UseVisualStyleBackColor = true;
            this.cmdSaveReg.Visible = false;
            this.cmdSaveReg.Click += new System.EventHandler(this.cmdSaveReg_Click);
            // 
            // cmdCleanReg
            // 
            this.cmdCleanReg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCleanReg.Location = new System.Drawing.Point(681, 109);
            this.cmdCleanReg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdCleanReg.Name = "cmdCleanReg";
            this.cmdCleanReg.Size = new System.Drawing.Size(125, 23);
            this.cmdCleanReg.TabIndex = 6;
            this.cmdCleanReg.Text = "clean up Reg";
            this.cmdCleanReg.UseVisualStyleBackColor = true;
            this.cmdCleanReg.Click += new System.EventHandler(this.cmdCleanReg_Click);
            // 
            // cmdFastClean
            // 
            this.cmdFastClean.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdFastClean.Location = new System.Drawing.Point(681, 339);
            this.cmdFastClean.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdFastClean.Name = "cmdFastClean";
            this.cmdFastClean.Size = new System.Drawing.Size(125, 23);
            this.cmdFastClean.TabIndex = 7;
            this.cmdFastClean.TabStop = false;
            this.cmdFastClean.Text = "fastCLean Reg";
            this.cmdFastClean.UseVisualStyleBackColor = true;
            this.cmdFastClean.Visible = false;
            this.cmdFastClean.Click += new System.EventHandler(this.cmdFastClean_Click);
            // 
            // cmd2pdf
            // 
            this.cmd2pdf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmd2pdf.Location = new System.Drawing.Point(681, 204);
            this.cmd2pdf.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmd2pdf.Name = "cmd2pdf";
            this.cmd2pdf.Size = new System.Drawing.Size(125, 23);
            this.cmd2pdf.TabIndex = 8;
            this.cmd2pdf.Text = "2pdf";
            this.cmd2pdf.UseVisualStyleBackColor = true;
            this.cmd2pdf.Visible = false;
            this.cmd2pdf.Click += new System.EventHandler(this.cmd2pdf_Click);
            // 
            // cndSave
            // 
            this.cndSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cndSave.Location = new System.Drawing.Point(681, 82);
            this.cndSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cndSave.Name = "cndSave";
            this.cndSave.Size = new System.Drawing.Size(125, 23);
            this.cndSave.TabIndex = 9;
            this.cndSave.TabStop = false;
            this.cndSave.Text = "Save";
            this.cndSave.UseVisualStyleBackColor = true;
            this.cndSave.Click += new System.EventHandler(this.cndSave_Click);
            // 
            // cmdCreateSoftLink
            // 
            this.cmdCreateSoftLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCreateSoftLink.Location = new System.Drawing.Point(681, 420);
            this.cmdCreateSoftLink.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdCreateSoftLink.Name = "cmdCreateSoftLink";
            this.cmdCreateSoftLink.Size = new System.Drawing.Size(125, 23);
            this.cmdCreateSoftLink.TabIndex = 11;
            this.cmdCreateSoftLink.Text = "create Soft Link";
            this.cmdCreateSoftLink.UseVisualStyleBackColor = true;
            this.cmdCreateSoftLink.Click += new System.EventHandler(this.cmdCreateSoftLink_Click);
            // 
            // grpMakros
            // 
            this.grpMakros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMakros.GroupText = "Makros";
            this.grpMakros.Location = new System.Drawing.Point(19, 44);
            this.grpMakros.Name = "grpMakros";
            this.grpMakros.Size = new System.Drawing.Size(631, 389);
            this.grpMakros.TabIndex = 10;
            this.grpMakros.ButtonEditClick += new System.EventHandler(this.grpMakros_ButtonEditClick);
            this.grpMakros.ButtonDeleteClick += new System.EventHandler(this.grpMakros_ButtonDeleteClick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 473);
            this.Controls.Add(this.cmdCreateSoftLink);
            this.Controls.Add(this.grpMakros);
            this.Controls.Add(this.cndSave);
            this.Controls.Add(this.cmd2pdf);
            this.Controls.Add(this.cmdFastClean);
            this.Controls.Add(this.cmdCleanReg);
            this.Controls.Add(this.cmdSaveReg);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cmdAddMakro);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cmdAddMakro;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdSaveReg;
        private System.Windows.Forms.Button cmdCleanReg;
        private System.Windows.Forms.Button cmdFastClean;
        private System.Windows.Forms.Button cmd2pdf;
        private System.Windows.Forms.Button cndSave;
        private CustomListBox grpMakros;
        private System.Windows.Forms.Button cmdCreateSoftLink;
    }
}

