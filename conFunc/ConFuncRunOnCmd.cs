using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization;

namespace RightClickAmplifier.conFunc
{

    [DataContract]
    class ConFuncRunOnCmd : ContextFunction
    {

        [DataMember]
        [ParamTypeAttribute]
        public string CmdCommand;

        public ConFuncRunOnCmd(string name) : base(name)
        {
            init();
        }

        public ConFuncRunOnCmd() : base()
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
            CmdCommand = "cd";
        }


        public override void PerformAction(ContextMakro currentMakro, string[] parameters)
        {
            CMD.Execute(CmdCommand);
        }

        public override string ToString()
        {
            return base.ToString() + " :" + "Run on CMD";
        }

        //--Presets------------------------------------------------------------------------------------------------------------

        public override List<ContextMakro> GetPresets()
        {
            ContextMakro makro = new ContextMakro("deleteThumbs");
            makro.FileExtensions.Add(new CString(".db"));
            makro.Functions.Add(new ConFuncRunOnCmd("del Thumbs.db /A:H"));
            return new List<ContextMakro>() { makro };
        }

        //--------------------------------------------------------------------------------------------------------------


    }
}
