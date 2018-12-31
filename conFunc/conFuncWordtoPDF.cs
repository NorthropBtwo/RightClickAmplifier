using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RightClickAmplifier
{

    [Serializable]
    class ConFuncWordtoPDF : ContextFunction
    {

        public ConFuncWordtoPDF() : base()
        {

        }

        public ConFuncWordtoPDF(string name) : base (name)
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

        //--Presets------------------------------------------------------------------------------------------------------------

        public override List<ContextMakro> GetPresets()
        {
            ContextMakro makro = new ContextMakro("Word2Pdf");
            makro.FileExtensions.Add(new CString(".docx"));
            makro.Functions.Add(new ConFuncWordtoPDF("2pdf"));
            return new List<ContextMakro>() { makro };
        }

        //--------------------------------------------------------------------------------------------------------------

    }




}
