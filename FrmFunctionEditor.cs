using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace RightClickAmplifier
{
    public partial class FrmFunctionEditor : Form
    {

        ContextFunction oldConfunc;
        ContextFunction newConfunc;

        List<Type> types = new List<Type>();

        public FrmFunctionEditor()
        {
            InitializeComponent();
        }

        private void FrmFunctionEditor_Load(object sender, EventArgs e)
        {
            TypeObject activeConfuncType = null;
            if (oldConfunc == null)
            {
                cboxFunctionTypes.Items.Add("select function");
                cboxFunctionTypes.SelectedIndex = 0;
            }
            foreach (Type typ in PlugInSystem.GetAllMotherTypes(typeof(ContextFunction)))
            {
                TypeObject confuncType = new TypeObject(typ);
                cboxFunctionTypes.Items.Add(confuncType);
                if(oldConfunc!= null && typ == oldConfunc.GetType())
                {
                    activeConfuncType = confuncType;
                }
            }

            if(activeConfuncType!= null)
            {
                cboxFunctionTypes.SelectedIndex = cboxFunctionTypes.Items.IndexOf(activeConfuncType);
            }
        }



        public ContextFunction ShowDialog(ContextFunction editFunc)
        {
            oldConfunc = editFunc;
            if (oldConfunc == null)
            {
                newConfunc = null;
            }
            else
            {
                newConfunc = oldConfunc;
            }

            base.ShowDialog();
            return oldConfunc;
        }

        private void cboxFunctionTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            paramAttributeEditor.Item = null;
            int selIdx = cboxFunctionTypes.SelectedIndex;
            if (selIdx >= 0)
            {
                TypeObject typeObjectToInstantiate = (cboxFunctionTypes.Items[selIdx] as TypeObject);
                if (typeObjectToInstantiate != null)
                {
                    Type typeToInstantiate = typeObjectToInstantiate.Typ;
                    if (oldConfunc != null && oldConfunc.GetType() == typeToInstantiate)
                    {
                        newConfunc = oldConfunc;
                    }
                    else
                    {
                        newConfunc = Activator.CreateInstance(typeToInstantiate) as ContextFunction;
                    }

                    paramAttributeEditor.Item = newConfunc;         
                }
                else
                {
                    newConfunc = null;
                }
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
            oldConfunc = newConfunc;
            this.Close();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            oldConfunc = null;
            this.Close();
        }
    }
}
