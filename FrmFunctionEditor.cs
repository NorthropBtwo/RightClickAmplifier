using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RightClickAmplifier
{
    public partial class FrmFunctionEditor : Form
    {

        ContextFunction confunc;
        ContextFunction newConfunc;


        List<Type> types = new List<Type>();

        public FrmFunctionEditor()
        {
            InitializeComponent();
        }

        private void FrmFunctionEditor_Load(object sender, EventArgs e)
        {
            TypeObject activeConfuncType = null;
            foreach (Type typ in PlugInSystem.GetAllMotherTypes(typeof(ContextFunction)))
            {
                TypeObject confuncType = new TypeObject(typ);
                cboxFunctionTypes.Items.Add(confuncType);
                if(confunc!= null && typ == confunc.GetType())
                {
                    activeConfuncType = confuncType;
                }
            }

            if(activeConfuncType!= null)
            {
                cboxFunctionTypes.SelectedItem = activeConfuncType;
            }
        }



        public ContextFunction ShowDialog(ContextFunction editFunc)
        {
            confunc = editFunc;
            base.ShowDialog();
            return confunc;
        }

        private void cboxFunctionTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selIdx = cboxFunctionTypes.SelectedIndex;
            if (selIdx >= 0)
            {
                Type typeToInstantiate = (cboxFunctionTypes.Items[selIdx] as TypeObject).Typ;
                newConfunc = Activator.CreateInstance(typeToInstantiate) as ContextFunction;
            }
           
        }




        public class TypeObject
        {
            public Type Typ;

            public TypeObject(Type typ)
            {
                this.Typ = typ;
            }

            public override string ToString()
            {
                return Typ.Name;
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            confunc = newConfunc;
            this.Close();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            confunc = null;
            this.Close();
        }
    }
}
