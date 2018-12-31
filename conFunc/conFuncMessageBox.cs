using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RightClickAmplifier
{

    [Serializable]
    public class ConFuncMessageBox : ContextFunction
    {

        public ConFuncMessageBox(string name) : base(name)
        {

        }

        public ConFuncMessageBox() : base()
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


        //--Presets------------------------------------------------------------------------------------------------------------

        public override List<ContextMakro> GetPresets()
        {
            ContextMakro makro = new ContextMakro("Test");
            makro.FileExtensions.Add(new CString("*"));
            makro.Functions.Add(new ConFuncMessageBox("HaliHalo"));
            return new List<ContextMakro>() { makro };
        }

        //--------------------------------------------------------------------------------------------------------------
    }
}
