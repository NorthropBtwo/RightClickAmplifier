using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RightClickAmplifier.conFunc
{
    [Serializable]
    public class ConFuncShowParameterList : ContextFunction
    {
        public ConFuncShowParameterList() : base()
        {

        }

        public ConFuncShowParameterList(string name) : base(name)
        {

        }

        public override string ToString()
        {
            return "ShowParameterList: " + base.ToString();
        }

        public override void PerformAction(ContextMakro currentMakro, string[] parameters)
        {
            MessageBox.Show(string.Join(Environment.NewLine,parameters));
        }

    }
}
