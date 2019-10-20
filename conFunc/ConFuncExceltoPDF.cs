using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;

namespace RightClickAmplifier
{

    [DataContract]
    class ConFuncExceltoPDF : ContextFunction
    {

        [DataMember]
        [ParamTypeAttribute]
        public string From;

        [DataMember]
        [ParamTypeAttribute]
        public string To;


        public ConFuncExceltoPDF() : base()
        {
            init();
        }

        public ConFuncExceltoPDF(string name) : base(name)
        {
            init();
        }

        public override void PerformAction(ContextMakro currentMakro, string[] parameters)
        {
            int intFrom, intTo;
            object objFrom = null, objTo = null;
            if (int.TryParse(From, out intFrom))
            {
                objFrom = intFrom;
            }
            if (int.TryParse(To, out intTo))
            {
                objTo = intTo;
            }

            string sDocX = parameters[2];
            string sPDF = Path.ChangeExtension(sDocX, ".pdf");
            Microsoft.Office.Interop.Excel.Application appWord = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook excelDocument = appWord.Workbooks.Open(sDocX);

            intFrom = int.TryParse(From, out intFrom) ? intFrom : 1;
            intTo = int.TryParse(To, out intTo) ? intTo : 0;
            if (intTo == 0)
            {
                excelDocument.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, sPDF, From: intFrom);
            }
            else
            {
                excelDocument.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, sPDF, From: intFrom, To: intTo);
            }
            excelDocument.Close(0);
            appWord.Quit();
        }

        public override string ToString()
        {
            return base.ToString() + " :" + "ExceltoPDF";
        }

        [OnDeserializing]
        private void OnDeserializing(StreamingContext context)
        {
            init();
        }

        private void init()
        {
            From = "";
            To = "";
        }

        //--Presets------------------------------------------------------------------------------------------------------------

        public override List<ContextMakro> GetPresets()
        {
            ContextMakro makro = new ContextMakro("Excel2Pdf");
            makro.FileExtensions.Add(new CString(".xlsx"));
            makro.Functions.Add(new ConFuncExceltoPDF("2pdf"));
            return new List<ContextMakro>() { makro };
        }

        //--------------------------------------------------------------------------------------------------------------

    }




}
