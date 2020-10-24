using System;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace phonebook
{
    [Serializable]
    internal class InvalidCpException : Exception
    {
        private string v;
        

    

        public InvalidCpException(string message) : base(message)
        {
            this.v = message;
            MessageBox.Show(v);
        }

       

      
       
    }
}