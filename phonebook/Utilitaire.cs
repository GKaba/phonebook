using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace phonebook
{
     
      class Utilitaire
    {
        //method pour verifier si l'email est valide 
        public static bool IsValidEmail(string email)
        {
            string pattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            //accept la valeur null
            if (string.IsNullOrWhiteSpace(email))
                return true;
            //levé une exception si l'email incorrecte
            else if (!Regex.IsMatch(email, pattern))
            {
                throw new InvalidEmailException("Email non valide : " +email);
            }
            else
                return true;
        }
        //method pour verifier si le Code Postal est valide 
        public static bool IsValidCodePostal(string po)
        {
            string pattern = @"[A-Z][0-9][A-Z][0-9][A-Z][0-9]";
            //accept la valeur null
            if (string.IsNullOrWhiteSpace(po))
                return true;
            //levé une exception si le Code Postal incorrecte
            else if (po.Trim().Length >6)
            {
                throw new InvalidCpException("Code Postal tres long : "+po);
            }
            else if (po.Trim().Length > 0 && po.Trim().Length<6)
            {
                throw new InvalidCpException("Code Postal tres court : " + po);
            }
            else if (!Regex.IsMatch(po.ToUpper().Trim(), pattern))
            {
                throw new InvalidCpException("Code Postal non valide : " + po);
            }
            else
                return true;

        }
        //method pour verifier si le num de telephone est valide 
        public static bool IsValidTel(string tel)
        {

            string pattern = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";

            //accept la valeur null
            if (string.IsNullOrWhiteSpace(tel))
                return true;
            //levé une exception si le num de telephone incorrecte ou not equal a 10
            else if (tel.Length != 10)
            {
                throw new InvalidTelException("Numero de telephone non correct : "+ tel);
            }
            
            else if (!Regex.IsMatch(tel,pattern))
            {
                throw new InvalidTelException("Format de Numero de telephone non correct : "+ tel);
            }
        
            else 
                return true;

        }
        //method pour verifier si le champe est vide
        public static bool VerefierChampe(TextBox txt)
        {
            if (string.IsNullOrEmpty(txt.Text))
            {
                txt.Focus();
                txt.BackColor = Color.LightPink;
                throw new TxtVideException("champe Obligatoire : ");
            }
            else
                return true;

        }
        //method pour verifier si le contact existe deja
        public static bool VerefierDoublan(Contact c,List<Contact> ls)
        {
         foreach(Contact temp in ls)
            {
                if(c.Equals(temp))
                {
                    throw new ContatExisteException("Contact Existe Deja...");
                }

            }
            return true;
        }


    }
}
