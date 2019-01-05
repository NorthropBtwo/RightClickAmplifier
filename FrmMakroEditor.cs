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

            ShowMakro(newMakro);

            //presets
            cboxPresets.Items.Clear();
            cboxPresets.Items.Add("Custom");
            cboxPresets.SelectedIndex = 0;
            foreach ( var preset in ContextFunction.GetAllPresets())
            {
                cboxPresets.Items.Add(preset);
            }
        }

        private void ShowMakro(ContextMakro makro)
        {
            txtMakroName.Text = makro.Name;
            customListBox1.Items.Clear();

            foreach (var function in makro.Functions)
            {
                customListBox1.Items.Add(function);
            }

            txtExtensions.Text = string.Join(" ", makro.FileExtensions);
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

            oldMakro.FileExtensions = new List<CString>();
            foreach(string extens in txtExtensions.Text.Trim(' ').Split(' '))
            {
                oldMakro.FileExtensions.Add(new CString(extens));
            }

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
            ContextFunction newConFunc = (new FrmFunctionEditor()).ShowDialog(null);
            if (newConFunc != null)
            {
                customListBox1.Items.Add(newConFunc);
            }
        }

        private void customListBox1_ButtonDeleteClick(object sender, EventArgs e)
        {
            var function = ((Control)sender).Tag as ContextFunction;
            if (function != null)
            {
                customListBox1.Items.Remove(function);
            }
        }

        private void cboxPresets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboxPresets.SelectedIndex >= 0)
            {
                ContextMakro selMakro = cboxPresets.SelectedItem as ContextMakro;
                if(selMakro != null)
                {
                    newMakro = selMakro;
                    ShowMakro(newMakro);
                }
            }
        }
    }
}
