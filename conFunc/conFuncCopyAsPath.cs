using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RightClickAmplifier
{

    [Serializable]
    public class ConFuncCopyAsPath : ContextFunction
    {

        public ConFuncCopyAsPath(string name) : base(name)
        {

        }

        public ConFuncCopyAsPath() : base()
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

        //--Presets------------------------------------------------------------------------------------------------------------

        public override List<ContextMakro> GetPresets()
        {
            ContextMakro makro = new ContextMakro("CopyAsPath");
            makro.FileExtensions.Add(new CString("*"));
            makro.Functions.Add(new ConFuncCopyAsPath("CopyPath"));
            return new List<ContextMakro>() { makro };
        }

        //--------------------------------------------------------------------------------------------------------------

    }
}
