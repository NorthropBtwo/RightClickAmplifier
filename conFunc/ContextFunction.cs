using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using static RightClickAmplifier.FrmFunctionEditor;

namespace RightClickAmplifier
{

    [Serializable]
    public class ContextFunction
    {

        public virtual string Name { get; set; }

        public ContextFunction()
        {
            this.Name =  "ContextFunctionBaseClass";
        }

        public ContextFunction(string name)
        {
            this.Name = name;
        }

        public virtual List<Type> GetParameterList()
        {
            return new List<Type>();
        }

        public virtual void PerformAction(ContextMakro currentMakro, string[] parameters )
        {
            MessageBox.Show("PerformAction");
        }

        public override string ToString()
        {
            return Name;
        }

        //--Presets------------------------------------------------------------------------------------------------------------

        public virtual List<ContextMakro> GetPresets()
        {
            return new List<ContextMakro>(); 
        }

        public static List<ContextMakro> GetAllPresets()
        {
            List<ContextMakro> presets = new List<ContextMakro>();
            foreach (Type typ in PlugInSystem.GetAllMotherTypes(typeof(ContextFunction)))
            {
                ContextFunction func = Activator.CreateInstance(typ) as ContextFunction;
                if(func != null)
                {
                    presets.AddRange(func.GetPresets());
                }
           
            }

            return presets;
        }

       

        //--------------------------------------------------------------------------------------------------------------
    }
}
