using System;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace phonebook
{
    [Serializable]
    internal class InvalidTelException : Exception
    {
        private string v;
       

     

        public InvalidTelException(string message) : base(message)
        {
            this.v = message;
            MessageBox.Show(v);
        }

      

        


    }
}