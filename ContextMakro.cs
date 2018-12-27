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

    [Serializable]
    public class ContextMakro : IXmlSerializable
    {

        
        public string Name { get; set; }
        public List<ContextFunction> Functions { get; set; }
        public List<string> FileExtensions { set; get; }


        public ContextMakro()
        {
            init("unknown Function");
        }

        public ContextMakro(string name)
        {
            init(name);
        }

        private void init(string name)
        {
            this.Name = name;
            Functions = new List<ContextFunction>();
            FileExtensions = new List<string>();
        }

        public override string ToString()
        {
            return Name;
        }




        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();
            Name = reader.GetAttribute("Name");
            Boolean isEmptyElement = reader.IsEmptyElement;
            reader.ReadStartElement();
            if (!isEmptyElement)
            {
                var deserializer = new DataContractSerializer(Functions.GetType(), PlugInSystem.GetAllTypes(typeof(ContextFunction)));
                Functions = (List<ContextFunction>)deserializer.ReadObject(reader);
                if (reader.IsStartElement())
                {
                    var deserializer2 = new DataContractSerializer(FileExtensions.GetType());
                    FileExtensions = (List<string>)deserializer2.ReadObject(reader);
                }
                reader.ReadEndElement();
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Name", Name);
            var serializer = new DataContractSerializer(Functions.GetType(), PlugInSystem.GetAllTypes(typeof(ContextFunction)) );
            serializer.WriteObject(writer, Functions);
            var serializerStringArray = new DataContractSerializer(FileExtensions.GetType());
            serializerStringArray.WriteObject(writer, FileExtensions);
        }

        public ContextMakro Clone()
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
                stream.Position = 0;
                return (ContextMakro)formatter.Deserialize(stream);
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
