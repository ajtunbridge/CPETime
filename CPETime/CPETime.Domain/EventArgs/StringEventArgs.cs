using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPETime.Domain
{
    public class StringEventArgs : EventArgs
    {
        private readonly string _value;

        public string Value
        {
            get { return _value; }
        }

        public StringEventArgs(string value)
        {
            _value = value;
        }
    }
}
