using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;

namespace RightClickAmplifier
{

    [DataContract]
    public class ConFuncMessageBox : ContextFunction
    {

        [DataMember]
        [ParamTypeAttribute]
        public string Message;

        [DataMember]
        [ParamTypeAttribute]
        public string Message2;


        //--Constructors------------------------------------------------------------------------------------------------------------

        public ConFuncMessageBox(string name) : base(name)
        {
            init();
        }

        public ConFuncMessageBox() : base()
        {
            init();
        }

        [OnDeserializing]
        private void OnDeserializing(StreamingContext context)
        {
            init();
        }

        private void init()
        {
            Message = "testMessage";
            Message2 = "testMessage";
        }

        //--Function------------------------------------------------------------------------------------------------------------

        public override void PerformAction(ContextMakro currentMakro, string[] parameters)
        {
            MessageBox.Show(Message);
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
