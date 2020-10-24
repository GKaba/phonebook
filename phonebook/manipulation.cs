using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using System.Linq.Expressions;

namespace phonebook
{
    class Manipulation
    {

        // method pour lire le fichier avec parametre de type RegistreContact
        public static void Readfile(RegistreContact listo)
        {

            try { 
                //creation de repertoir s'il n'existe pas 

            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (!Directory.Exists(path + "\\Address Book"))
                Directory.CreateDirectory(path + "\\Address Book");

            //creation de fichier s'il n'existe pas

            if (!File.Exists(path + "\\Address Book\\settings.xml"))
            {
                XmlTextWriter xW = new XmlTextWriter(path + "\\Address Book\\settings.xml", Encoding.UTF8);
                xW.WriteStartElement("person");
                xW.WriteEndElement();
                xW.Close();

            }
                //lire le fichier  avec l'identification du nœud parent
                XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path + "\\Address Book\\settings.xml");

            foreach (XmlNode xNode in xDoc.SelectNodes("person/contact"))
            {

             //  creer un objet contact 

                    Contact person = new Contact();
            //assosier les nodes enfant aux propriétés de contact 

                person.Fname = xNode.SelectSingleNode("fname").InnerText;
                person.Lname = xNode.SelectSingleNode("lname").InnerText;
                person.Email = xNode.SelectSingleNode("email").InnerText;
                person.Phone = xNode.SelectSingleNode("phone").InnerText;
                person.FirstAdd = xNode.SelectSingleNode("firstAdd").InnerText;
                person.City = xNode.SelectSingleNode("city").InnerText;
                person.Country = xNode.SelectSingleNode("country").InnerText;
                person.Zip = xNode.SelectSingleNode("zip").InnerText;

                    //ajouter le contact a la liste contact dans le RegistreContact
                listo.AjouterContact(person);
            }
            }
                    
            catch (System.Xml.XmlException e)
            {
                MessageBox.Show(e.Message + "Redemarer le Programe..");
            }
            catch (FileNotFoundException )
            {
                MessageBox.Show("S.V.P Redemarer le Programe.. Ou Appele la company Pour résoudre le Problem..");
            }

        }

        public static void  WriteFile(RegistreContact listo)
        {
            try
            {
                //trouver le fichier et le vider
                XmlDocument xDoc = new XmlDocument();
                string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                xDoc.Load(path + "\\Address Book\\settings.xml");
                XmlNode xNode = xDoc.SelectSingleNode("person");
                xNode.RemoveAll();
            //// remplir le ficher xml en identefiant les node parent et les anfant 
                foreach (Contact p in listo.LstPerson)
                {

                    XmlNode xTop = xDoc.CreateElement("contact");
                    XmlNode xFName = xDoc.CreateElement("fname");
                    XmlNode xLName = xDoc.CreateElement("lname");
                    XmlNode xEmail = xDoc.CreateElement("email");
                    XmlNode xPhone = xDoc.CreateElement("phone");
                    XmlNode xFirstAdd = xDoc.CreateElement("firstAdd");
                    XmlNode xCity = xDoc.CreateElement("city");
                    XmlNode xCountry = xDoc.CreateElement("country");
                    XmlNode xZip = xDoc.CreateElement("zip");

                    //assosier chaque propriété de contact au noede 
                    xFName.InnerText = p.Fname;
                    xLName.InnerText = p.Lname;
                    xEmail.InnerText = p.Email;
                    xPhone.InnerText = p.Phone;

                    xFirstAdd.InnerText = p.FirstAdd;
                    xCity.InnerText = p.City;
                    xCountry.InnerText = p.Country;
                    xZip.InnerText = p.Zip;
                    xTop.AppendChild(xFName);
                    xTop.AppendChild(xLName);
                    xTop.AppendChild(xEmail);
                    xTop.AppendChild(xPhone);
                    xTop.AppendChild(xFirstAdd);
                    xTop.AppendChild(xCity);
                    xTop.AppendChild(xCountry);
                    xTop.AppendChild(xZip);

                    xDoc.DocumentElement.AppendChild(xTop);
                }
                //sauvgarder le fichier
                xDoc.Save(path + "\\Address Book\\settings.xml");
            }
            catch (System.Xml.XmlException e)
            {
                MessageBox.Show(e.Message + "Redemarer le Programe..");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("S.V.P Redemarer le Programe.. Ou Appele la company Pour résoudre le Problem..");
            }

        }
    }
} 


  