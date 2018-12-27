using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RightClickAmplifier
{

    [Serializable]
    class conFuncWordtoPDF : ContextFunction
    {

        public conFuncWordtoPDF() : base()
        {

        }

        public conFuncWordtoPDF(string name) : base (name)
        {

        }

        public override void PerformAction(ContextMakro currentMakro, string[] parameters)
        {
            string sDocX = parameters[2];
            string sPDF = Path.ChangeExtension(sDocX,".pdf");
            Microsoft.Office.Interop.Word.Application appWord = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document wordDocument = appWord.Documents.Open(sDocX);
            wordDocument.ExportAsFixedFormat(sPDF, Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF);
            wordDocument.Close();
            appWord.Quit();
        }

        public override string ToString()
        {
            return base.ToString() + " :" + "WordtoPDF";
        }

    }



   
}
