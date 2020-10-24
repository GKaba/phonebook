using System;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace phonebook
{
    [Serializable]
    internal class TxtVideException : Exception
    {
        private string v;

        public TxtVideException()
        {
        }
        public TxtVideException(string message) : base(message)
        {
            this.v = message;
            MessageBox.Show(message);
        }

     
    }
}