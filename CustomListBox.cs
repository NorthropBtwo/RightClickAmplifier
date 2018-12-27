using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Drawing.Design;

namespace RightClickAmplifier
{
    public partial class CustomListBox : UserControl
    {

        // ListBox

        
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [Localizable(true)]
        [MergableProperty(false)]
        public ObservableCollection<object> Items { get; }

        public String GroupText { get { return grpBox.Text; } set { grpBox.Text = value; } }

        public event EventHandler ButtonEditClick;
        public event EventHandler ButtonDeleteClick;

        public CustomListBox()
        {
            if (Items == null)
            {
                Items = new ObservableCollection<object>();
            }

            InitializeComponent();

            Items.CollectionChanged += List_CollectionChanged;
            List_CollectionChanged(this, null);
        }

        private void List_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            const int MakroPanHeight = 25;
            const int MakroPanWidth = 300;

            panItems.Controls.Clear();

            for (int i = Items.Count-1; i >= 0; i--)
            {
                Panel makroPanel = new Panel { AutoSize = true, BackColor = Color.LightBlue, Size = new Size(MakroPanWidth, MakroPanHeight) };
                makroPanel.Location = new Point(10, panItems.Controls.Count * MakroPanHeight);
                makroPanel.Dock = DockStyle.Top;

                Label chb = new Label { Text = Items[i].ToString() };
                chb.Location = new Point(0, 0);
                chb.AutoSize = true;

                Button cmd = new Button { Text = "Edit", Location = new Point(panItems.Width - 100, 0), BackColor = BackColor, Tag = Items[i].ToString() };
                cmd.Size = new Size(100, cmd.Size.Height);
                cmd.Click += OnButtonEditClick;
                cmd.Tag = Items[i];

                Button cmd2 = new Button { Text = "X", Location = new Point(panItems.Width - 100 - 20, 0), BackColor = BackColor, Tag = Items[i].ToString() };
                cmd2.Size = new Size(20, cmd.Size.Height);
                cmd2.Click += OnButtonDeleteClick;
                cmd2.Tag = Items[i];

                makroPanel.Controls.Add(cmd2);
                makroPanel.Controls.Add(cmd);
                makroPanel.Controls.Add(chb);

               
                panItems.Controls.Add(makroPanel);

                cmd.Anchor = AnchorStyles.Right;
                cmd2.Anchor = AnchorStyles.Right;

            }
        }

        private void OnButtonEditClick(object sender, EventArgs e)
        {
            EventHandler eh = ButtonEditClick;
            if (eh != null)
            {
                eh(sender, e);
            }
        }

        private void OnButtonDeleteClick(object sender, EventArgs e)
        {
            EventHandler eh = ButtonDeleteClick;
            if (eh != null)
            {
                eh(sender, e);
            }
        }

        private void grpBox_Enter(object sender, EventArgs e)
        {
           
        }
    }
}
