using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RightClickAmplifier
{
    public partial class FrmMakroEditor : Form
    {
        ContextMakro oldMakro;
        ContextMakro newMakro;

        public FrmMakroEditor()
        {
            InitializeComponent();
        }

        private void FrmMakroEditor_Load(object sender, EventArgs e)
        {
            txtMakroName.Text = newMakro.Name;
            customListBox1.Items.Clear();

            foreach(var function in  newMakro.Functions)
            {
                customListBox1.Items.Add(function);
            }

            txtExtensions.Text = string.Join(" ", newMakro.FileExtensions);
        }



        public ContextMakro ShowDialog(ContextMakro editMakro)
        {
            oldMakro = editMakro;
            if(oldMakro == null)
            {
                newMakro = new ContextMakro();
            }
            else
            {
                newMakro = oldMakro.Clone();
            }
            base.ShowDialog();
            return oldMakro;
        }

        private void cmdSaveMakro_Click(object sender, EventArgs e)
        {
            if (oldMakro == null)
                oldMakro = newMakro;

            oldMakro.Name = txtMakroName.Text;
            oldMakro.Functions = new List<ContextFunction>();

            foreach (var function in customListBox1.Items)
            {
                oldMakro.Functions.Add((ContextFunction)function);
            }

            oldMakro.FileExtensions = new List<string>(txtExtensions.Text.Trim(' ').Split(' '));

            this.Close();
        }

        private void customListBox1_ButtonEditClick(object sender, EventArgs e)
        {
            ContextFunction oldConFunc = ((Control)sender).Tag as ContextFunction;
            ContextFunction newConFunc = (new FrmFunctionEditor()).ShowDialog(oldConFunc);
            int idx = customListBox1.Items.IndexOf(((Control)sender).Tag);
            customListBox1.Items.RemoveAt(idx);
            if (newConFunc != null)
            {
                customListBox1.Items.Insert(idx, newConFunc);
            }
        }

        private void cmdAddFunction_Click(object sender, EventArgs e)
        {
            customListBox1.Items.Add(new ContextFunction());
        }

        private void customListBox1_ButtonDeleteClick(object sender, EventArgs e)
        {
            var function = ((Control)sender).Tag as ContextFunction;
            if (function != null)
            {
                customListBox1.Items.Remove(function);
            }
        }
    }
}
