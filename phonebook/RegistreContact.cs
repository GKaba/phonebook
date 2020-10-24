using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace phonebook
{
    // class RegistreContact avec propriété de type list<contact>
    public class RegistreContact
    {

        public List<Contact> LstPerson { get; set; }

        public  RegistreContact(List<Contact> lst)
        {
            this.LstPerson = lst;

        }
        //methode pour ajuter contact a la liste
        internal void AjouterContact(Contact x)
        {
            LstPerson.Add(x);

        }
        //methode pour suprimer contact de la liste
        internal void SupprimerContact(Contact x)
        {
            LstPerson.Remove(x);

        }

     
    }
}
