using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace RightClickAmplifier
{

    [DataContract]
    public class ContextMakro
    {

        [DataMember]
        public string Name;
        [DataMember]
        public List<ContextFunction> Functions;
        [DataMember]
        public List<CString> FileExtensions;


        public ContextMakro()
        {
            init("MakroText");
        }

        public ContextMakro(string name)
        {
            init(name);
        }

        public ContextMakro(string name, List<string> fileExrensions, List<ContextFunction> functions)
        {
            init(name, fileExrensions, functions);
        }

        private void init(string name)
        {
            init(name, new List<string>(), new List<ContextFunction>());
        }

        private void init(string name, List<string> fileExtensions, List<ContextFunction> functions)
        {
            this.Name = name;
            Functions = new List<ContextFunction>(functions);
            FileExtensions = new List<CString>();
            foreach(var extens in fileExtensions)
            {
                FileExtensions.Add(new CString(extens));
            }
        }

        public override string ToString()
        {
            return Name + "   (" + string.Join("  ", FileExtensions) + ")";
        }

        public ContextMakro Clone()
        {
            /*
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
                stream.Position = 0;
                return (ContextMakro)formatter.Deserialize(stream);
            }*/

            using (var stream = new MemoryStream())
            {
                var serializer = new DataContractSerializer(GetType(), PlugInSystem.GetAllTypes(typeof(ContextFunction)));
                serializer.WriteObject(stream, this);
                stream.Position = 0;
                return (ContextMakro)serializer.ReadObject(stream);
            }
        }

        public void PerformAction(string[] parameters)
        {
            foreach(var function in Functions)
            {
                function.PerformAction(this, parameters);
            }
        }
    }
}
