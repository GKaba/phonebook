using System;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace phonebook
{
    [Serializable]
    internal class InvalidEmailException : Exception
    {
        private string v;
        

        public InvalidEmailException(string message) : base(message)
        {
            this.v = message;
            MessageBox.Show(v);
        }

      

    
    }
}