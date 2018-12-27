using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RightClickAmplifier
{

    [Serializable]
    public class conFuncMessageBox : ContextFunction
    {

        public conFuncMessageBox(string name) : base(name)
        {

        }

        public conFuncMessageBox() : base()
        {

        }


        public override void PerformAction(ContextMakro currentMakro, string[] parameters)
        {
            MessageBox.Show("conFuncMessageBox");
        }

        public override string ToString()
        {
            return base.ToString() + " :" + "conFuncMessageBox";
        }
    }
}
