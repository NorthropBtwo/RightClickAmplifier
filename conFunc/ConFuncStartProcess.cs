using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;

namespace RightClickAmplifier
{

    [DataContract]
    public class ConFuncStartProcess : ContextFunction
    {

        [DataMember]
        [ParamTypeAttribute]
        public string ProcessToStart;

        [DataMember]
        [ParamTypeAttribute]
        public string Parameter;

        public ConFuncStartProcess() :base()
        {
            init();
        }

        public ConFuncStartProcess(string name) : base(name)
        {
            init();
        }

        public override void PerformAction(ContextMakro currentMakro, string[] parameters)
        {
            if (File.Exists(ProcessToStart))
            {
                Process process = new Process();
                process.StartInfo.FileName = ProcessToStart;
                process.StartInfo.Arguments = Parameter;
                process.Start();
            }
            else
            {
                MessageBox.Show("File does not exist: " + ProcessToStart);
            }
        }

        public override string ToString()
        {
            return base.ToString() + " :" + "Start Process";
        }

        [OnDeserializing]
        private void OnDeserializing(StreamingContext context)
        {
            init();
        }

        private void init()
        {
            ProcessToStart = "";
            Parameter = "";
        }


        //--Presets------------------------------------------------------------------------------------------------------------

        public override List<ContextMakro> GetPresets()
        {
            ContextMakro makro = new ContextMakro("StartExplorer");
            makro.FileExtensions.Add(new CString("directory/Background"));
            ConFuncStartProcess func = new ConFuncStartProcess("StartExplorer");
            func.ProcessToStart = "C:\\Windows\\explorer.exe";
            makro.Functions.Add(func);
            return new List<ContextMakro>() { makro };
        }
    }
}
