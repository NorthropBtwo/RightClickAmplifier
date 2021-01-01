using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RightClickAmplifier.conFunc
{

    [Serializable]
    public class ConFuncCheckDayLightTime : ContextFunction
    {

        public ConFuncCheckDayLightTime(string name) : base(name)
        {

        }

        public ConFuncCheckDayLightTime() : base()
        {

        }


        public override void PerformAction(ContextMakro currentMakro, string[] parameters)
        {

            //Clipboard.SetText(parameters[2]);
            bool dstToday = IsDst(DateTime.Now);
            int daysToChange = -1;
            while(dstToday == IsDst(DateTime.Now.AddDays(daysToChange)))
            {
                daysToChange++;
                if(daysToChange > 20)
                {
                    break;
                }
            }
            if (daysToChange <= 10)
            {
                MessageBox.Show("Days until next Day Light Saving Time Change: " + daysToChange);
            }
        }

        //https://stackoverflow.com/questions/5590429/calculating-daylight-saving-time-from-only-date
        public static bool IsDst(DateTime dt)
        {
            return IsDst(dt.Day, dt.Month, (int)dt.DayOfWeek);
        }

        public static bool IsDst(int day, int month, int dow)
        {
            if (month < 3 || month > 10) return false;
            if (month > 3 && month < 10) return true;

            int previousSunday = day - dow;

            if (month == 3) return previousSunday >= 25;
            if (month == 10) return previousSunday < 25;

            return false; // this line never gonna happend
        }


        public override string ToString()
        {
            return base.ToString() + " :" + "CheckDayLightTime";
        }

        //--Presets------------------------------------------------------------------------------------------------------------

        public override List<ContextMakro> GetPresets()
        {
            ContextMakro makro = new ContextMakro("CheckDayLightTime");
            makro.FileExtensions.Add(new CString(""));
            makro.Functions.Add(new ConFuncCheckDayLightTime("ConFuncCheckDayLightTime"));
            return new List<ContextMakro>() { makro };
        }

        //--------------------------------------------------------------------------------------------------------------


    }
}
