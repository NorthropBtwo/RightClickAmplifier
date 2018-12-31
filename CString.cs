using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace RightClickAmplifier
{
    [DataContract]
    public class CString
    {
        [DataMember]
        string s = "";

        public CString()
        {
            s = "";
        }

        public CString(string s)
        {
            this.s = s;
        }

        public override string ToString()
        {
            return s;
        }

        public override bool Equals(object obj)
        {
            return s.Equals(obj);
        }

        public override int GetHashCode()
        {
            return s.GetHashCode();
        }

        [OnDeserializing]
        private void OnDeserializing(StreamingContext context)
        {
            s = "";
        }
    }
}
