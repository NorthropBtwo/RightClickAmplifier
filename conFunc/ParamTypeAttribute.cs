using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace RightClickAmplifier
{
    public class ParamTypeAttribute : DescriptionAttribute
    {
        public enum EnumParamType
        {
            tString,
        }

        public EnumParamType ParamType = EnumParamType.tString;

    }
}
