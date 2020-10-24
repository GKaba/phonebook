using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace phonebook
{

    //creer class contact avec ses propriétés
    public class Contact
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }
        public string FirstAdd { get; set; }


        //constructeur contact
        public Contact(string fname,string lname,string phone,string email, string firstAdd, string city, string country, string zip)

            {
            this.Fname = fname;
            this.Lname = lname;
            this.Phone = phone;
            this.Email = email;
            this.FirstAdd = firstAdd;
            this.City = city;
            this.Country = country;
            this.Zip = zip;

        }
        //constructeur par defaut
        public Contact()
        {

        }
        //redéfinir le  methode ToString 
        public override string ToString()
        {
            string output = Lname + " " + Fname;
            return output;
        }

        //redéfinir le  methode Equals pour definir l'equalité entre deux contact
      public override bool Equals(object obj)
        {
            
            //verifier si c'est null
            if (obj == null)
                return false;
            //verifier si type Contact
            if (!(obj is Contact))
                return false;
            //cast vers Contact
            Contact c = (Contact)obj;

             //Verifier si les information sont egaux
             if (!this.Fname.Equals(c.Fname))
             {
                 return false;
             }

             if (!this.Lname.Equals(c.Lname))
             {
                 return false;
             }
            if (!this.Phone.Equals(c.Phone))
            {
                return false;
            }
            if (!this.Email.Equals(c.Email))
            {
                return false;
            }
            if (!this.FirstAdd.Equals(c.FirstAdd))
            {
                return false;
            }
            if (!this.City.Equals(c.City))
            {
                return false;
            }
            if (!this.Country.Equals(c.Country))
            {
                return false;
            }
            if (!this.Zip.Equals(c.Zip))
            {
                return false;
            }

            return true;
        }
        
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
