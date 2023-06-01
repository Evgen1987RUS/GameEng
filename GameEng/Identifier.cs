using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Identifier
    {
        private List<string> _identifiers = new();
        private int _value = 0;
        private string _charsForGenerate = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";

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

        public string CharsForGenerate
        {
            get { return CharsForGenerate; }
            set { _charsForGenerate = value; }
        }

        public Identifier() { Identifier.Generate(); } //?????

        public dynamic GetValue() { return Value; }

        private static string Generate() 
        {
            Identifier identifier = new();
            Random randomNumber = new();
            char[] chars = new char[16];

            for (int i = 0; i < 16; i++)
            {
                chars[i] = identifier.CharsForGenerate[(int)(identifier.CharsForGenerate.Length) * randomNumber.Next()];
            }

            return new string(chars);
        }
    }
}
