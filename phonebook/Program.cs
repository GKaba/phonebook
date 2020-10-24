using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace phonebook
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //creer list contact
            List<Contact> LstPerson = new List<Contact>();
            //creer registre
            RegistreContact listo = new RegistreContact(LstPerson);
            //lire le fichier xml 
            Manipulation.Readfile(listo);
            
            Application.Run(new Form1(listo));
        }
    }
}
