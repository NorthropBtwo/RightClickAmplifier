using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace RightClickAmplifier
{
    public partial class ParamAttributeEditor : UserControl
    {

        public object Item {
            get { return item; }
            set { item = value; reloadView(); } }
        private object item;

        public String GroupText { get { return grpBox.Text; } set { grpBox.Text = value; } }


        List<TextBox> txtBoxes = new List<TextBox>();

        public ParamAttributeEditor()
        {
            InitializeComponent();
        }

        private void grpBox_Enter(object sender, EventArgs e)
        {

        }

        public void reloadView()
        {
            panItems.Controls.Clear();

            txtBoxes.Clear();

            FieldInfo[] fields = new FieldInfo[] { };
            if (item != null)
            {
                fields = item.GetType().GetFields();
            }

            int i = 0;
            TableLayoutPanel makroPanel = new TableLayoutPanel { Dock = DockStyle.Fill};// BackColor = Color.LightBlue, , CellBorderStyle = TableLayoutPanelCellBorderStyle.Single};
         //   makroPanel.MaximumSize = new Size(panItems.Width, panItems.Height);

            foreach (var field in fields)
            {
                ParamTypeAttribute[] attribute = field.GetCustomAttributes(typeof(ParamTypeAttribute), true) as ParamTypeAttribute[];
                if (attribute != null && attribute.Length > 0)
                {
                    Label chb = new Label { Text = field.Name + ": " };
                    chb.AutoSize = true;

                    TextBox txt = new TextBox{ Text = field.GetValue(item).ToString() };
                    txt.AutoSize = true;
                    txt.Tag = field;
                    txt.TextChanged += paramEditied;
                    txtBoxes.Add(txt);

                    makroPanel.Controls.Add(chb,1,i);
                    makroPanel.Controls.Add(txt, 2, i);


                    i++;
                }       
            }
            panItems.Controls.Add(makroPanel);

            foreach (var txt in txtBoxes)
            {
                txt.Width = makroPanel.Width - txt.Location.X - 5;
                txt.Anchor = AnchorStyles.Right | txt.Anchor;
            }


         //   makroPanel.MaximumSize = new Size(makroPanel.Width, makroPanel.Height);
        //    makroPanel.Size = new Size(makroPanel.Width/20, makroPanel.Height);
            makroPanel.AutoScroll = true;
         //   makroPanel.Anchor = makroPanel.Anchor | AnchorStyles.Bottom | AnchorStyles.Right;
        }

        private void paramEditied(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
           if (txt != null)
            {
                FieldInfo field = txt.Tag as FieldInfo;
                if(field != null)
                {
                    field.SetValue(item, txt.Text);
                }
            }
        }
    }
}
