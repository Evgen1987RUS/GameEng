using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEng.lib.Engine.BasicClasses
{
    public class Identifier
    {
        private List<string> _identifiers = new();
        private int _value = -1;

        public List<string> Identifiers
        {
            get { return _identifiers; }
            set { _identifiers = value; }
        }

        public dynamic Value
        {
            get { return Identifiers[_value]; }
            set { _value = value; }
        }

        public int ValueNumber
        {
            get { return _value; }
            set { _value = value; }
        }

        public Identifier() { Generate(); }

        public dynamic GetValue() { return Value; }

        public void Generate()
        {
            if (ValueNumber == -1) { Identifiers.Add("1000000000000000"); _value++; return; }

            long buff = long.Parse(GetValue()) + 1;
            Identifiers.Add(buff.ToString());
            _value++;
        }
    }
}
