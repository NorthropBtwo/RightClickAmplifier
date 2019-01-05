namespace RightClickAmplifier
{
    partial class FrmFunctionEditor
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
            this.cboxFunctionTypes = new System.Windows.Forms.ComboBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.paramAttributeEditor = new RightClickAmplifier.ParamAttributeEditor();
            this.SuspendLayout();
            // 
            // cboxFunctionTypes
            // 
            this.cboxFunctionTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxFunctionTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxFunctionTypes.FormattingEnabled = true;
            this.cboxFunctionTypes.Location = new System.Drawing.Point(12, 26);
            this.cboxFunctionTypes.Name = "cboxFunctionTypes";
            this.cboxFunctionTypes.Size = new System.Drawing.Size(368, 24);
            this.cboxFunctionTypes.TabIndex = 1;
            this.cboxFunctionTypes.SelectedIndexChanged += new System.EventHandler(this.cboxFunctionTypes_SelectedIndexChanged);
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.Location = new System.Drawing.Point(403, 27);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 2;
            this.cmdSave.Text = "save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // paramAttributeEditor
            // 
            this.paramAttributeEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paramAttributeEditor.GroupText = "Function Settings";
            this.paramAttributeEditor.Item = null;
            this.paramAttributeEditor.Location = new System.Drawing.Point(12, 56);
            this.paramAttributeEditor.Name = "paramAttributeEditor";
            this.paramAttributeEditor.Size = new System.Drawing.Size(466, 296);
            this.paramAttributeEditor.TabIndex = 6;
            // 
            // FrmFunctionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 364);
            this.Controls.Add(this.paramAttributeEditor);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cboxFunctionTypes);
            this.Name = "FrmFunctionEditor";
            this.Text = "FrmFunctionEditor";
            this.Load += new System.EventHandler(this.FrmFunctionEditor_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cboxFunctionTypes;
        private System.Windows.Forms.Button cmdSave;
        private ParamAttributeEditor paramAttributeEditor;
    }
}