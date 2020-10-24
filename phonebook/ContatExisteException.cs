using System;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace phonebook
{
    [Serializable]
    internal class ContatExisteException : Exception
    {
        private string v;
    
        public ContatExisteException(string message) : base(message)
        {
            this.v = message;
            MessageBox.Show(v);
        }

    
    }
}