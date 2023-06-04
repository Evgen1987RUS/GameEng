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
        private int _value = -1;
        private int _valueNumber = -1;

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
            get { return _valueNumber; }
            set { _valueNumber = value; }
        }

        public Identifier() { Generate(); }

        public dynamic GetValue() { return Value; }

        public void Generate() // TODO : переделать без рандома на инкремент
        {
            string charsForGenerate = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            Random randomNumber = new();
            char[] chars = new char[16];

            for (int i = 0; i < 16; i++)
            {
                chars[i] = charsForGenerate[randomNumber.Next(59)];
            }

            _value++;
            _valueNumber++;
            Identifiers.Add(new string(chars));
        }
    }
}
