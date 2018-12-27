using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace RightClickAmplifier
{

    [Serializable]
    public class ContextFunction : IXmlSerializable
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

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();
            Name = reader.GetAttribute("Name");
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Name", Name);
        }
    }
}
