using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RightClickAmplifier
{
    class PlugInSystem
    {

        public static List<Type> GetAllMotherTypes(Type chiltype)
        {
            List<Type> types = new List<Type>();

            foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (Type t in a.GetTypes())
                {
                    Type baseType = t.BaseType;
                    if (baseType != null && baseType == chiltype)
                    {
                        types.Add(t);
                    }
                }
            }
            return types;
        }


        public static List<Type> GetAllTypes(Type chiltype)
        {
            List<Type> types = GetAllMotherTypes(chiltype);
            types.Add(chiltype);
            return types;
        }
    }
}
