#region Using directives

using System;

#endregion

namespace CPETime.Domain
{
    public class StringEventArgs : EventArgs
    {
        private readonly string _value;

        public StringEventArgs(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }
    }
}