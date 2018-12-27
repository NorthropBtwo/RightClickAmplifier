using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RightClickAmplifier
{

    [Serializable]
    public class conFuncCopyAsPath : ContextFunction
    {

        public conFuncCopyAsPath(string name) : base(name)
        {

        }

        public conFuncCopyAsPath() : base()
        {

        }


        public override void PerformAction(ContextMakro currentMakro, string[] parameters)
        {
            Clipboard.SetText(parameters[2]);
        }

        public override string ToString()
        {
            return base.ToString() + " :" + "Copy As Path";
        }

    }
}
