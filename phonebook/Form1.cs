using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace phonebook
{
    public partial class Form1 : Form
    {
        //proprité
        public static RegistreContact Lste { get; set; }

        public Form1(RegistreContact lscontact)
        {
            InitializeComponent();
            Lste=lscontact;
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ajouter les contacts a la listBox
            AfficherlistBox();
            StatuButton(false);
            ReadOnly(true);
        }

        //method pour Ajouter les contacts a la ListBox
        private void AfficherlistBox()
        {
            foreach (Contact c in Lste.LstPerson)
            {
                listBox.Items.Add(c.ToString());

            }

        }

        //method pour vider les textBoxs
        private void Clean()
        {
            txtAddress1.Clear();
            txtCity.Clear();
            txtCountry.Clear();
            txtEmail.Clear();
            txtFnam.Clear();
            txtLnam.Clear();
            txtPhone.Clear();
            txtzip.Clear();
        }

        //methode pour changer l'etat de button (enable/disable)
        private void StatuButton(bool bl)
        {
            if (bl == true)
            {
                btnDel.Enabled = false;
                btnSave.Enabled = true;
            }
            else
                btnSave.Enabled = false;
            btnEdit.Enabled = false;
            btnDel.Enabled = false;
        }

        // Method pour mettre les textBoxes au readOnly et changer leur color
        private void ReadOnly(bool ro)
        {
            if (ro)
            {
                txtAddress1.ReadOnly = true;
                txtAddress1.BackColor = Color.LightGray;
                txtCity.ReadOnly = true;
                txtCity.BackColor = Color.LightGray;
                txtCountry.ReadOnly = true;
                txtCountry.BackColor = Color.LightGray;
                txtEmail.ReadOnly = true;
                txtEmail.BackColor = Color.LightGray;
                txtFnam.ReadOnly = true;
                txtFnam.BackColor = Color.LightGray;
                txtLnam.ReadOnly = true;
                txtLnam.BackColor = Color.LightGray;
                txtPhone.ReadOnly = true;
                txtPhone.BackColor = Color.LightGray;
                txtzip.ReadOnly = true;
                txtzip.BackColor = Color.LightGray;
            }
            else
            {
                txtAddress1.ReadOnly = false;
                txtAddress1.BackColor = Color.White;
                txtCity.ReadOnly = false;
                txtCity.BackColor = Color.White;
                txtCountry.ReadOnly = false;
                txtCountry.BackColor = Color.White;
                txtEmail.ReadOnly = false;
                txtEmail.BackColor = Color.White;
                txtFnam.ReadOnly = false;
                txtFnam.BackColor = Color.White;
                txtLnam.ReadOnly = false;
                txtLnam.BackColor = Color.White;
                txtPhone.ReadOnly = false;
                txtPhone.BackColor = Color.White;
                txtzip.ReadOnly = false;
                txtzip.BackColor = Color.White;
            }
        }

        //method pour afficher les informations de contact sélectionné dans les textBoxes
        private void RemplirChmp(Contact c)
        {
            txtAddress1.Text = c.FirstAdd;
            txtCity.Text = c.City;
            txtCountry.Text = c.Country;
            txtEmail.Text = c.Email;
            txtFnam.Text = c.Fname;
            txtLnam.Text = c.Lname;
            txtPhone.Text = c.Phone;
            txtzip.Text = c.Zip;

        }

        //methode pour verifier les informations avant les sauvgarder
        private bool SauvgarderContact(Contact obj)
        {


            try
            {


                if (Utilitaire.VerefierChampe(txtFnam))
                {
                    obj.Fname = txtFnam.Text;
                }
                if (Utilitaire.VerefierChampe(txtLnam))
                {
                    obj.Lname = txtLnam.Text;
                }

                obj.FirstAdd = txtAddress1.Text;
                obj.City = txtCity.Text;
                obj.Country = txtCountry.Text;


                if (Utilitaire.IsValidTel(txtPhone.Text))
                {
                    obj.Phone = txtPhone.Text;
                }
                if (Utilitaire.IsValidEmail(txtEmail.Text))
                {
                    obj.Email = txtEmail.Text;
                }
                if (Utilitaire.IsValidCodePostal(txtzip.Text))
                {
                    obj.Zip = txtzip.Text;

                }
                return true;
            }

            catch (TxtVideException)
            {
                return false;
            }
            catch (InvalidTelException)
            {
                return false;

            }
            catch (InvalidEmailException)
            {
                return false;
            }
            catch (InvalidCpException)
            {
                return false;
            }

        }

        //pour interdit les characters dans phone textbox
        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (Char.IsLetter(ch) && ch != 8 && ch != 46 && ch
                != 32)
            {
                e.Handled = true;

            }
        }

        //changer le coleur de textBox quand il saisir ,car son coleur  est rouge si il est vide
        private void txtFnam_TextChanged(object sender, EventArgs e)
        {
            txtFnam.BackColor = Color.White;
        }

        //changer le coleur de textBox quand il saisir ,car son coleur  est rouge si il est vide
        private void txtLnam_TextChanged(object sender, EventArgs e)
        {
            txtLnam.BackColor = Color.White;
        }

        // activer le form pour ajouter nouveau contact 
        private void BtnNew_Click(object sender, EventArgs e)
        {
            Clean();
            listBox.ClearSelected();
            ReadOnly(false);
            btnEdit.Enabled = false;
            StatuButton(true);

        }

        //suprimmer le contact sélectionné de RegistreContact et de la ListBox
        private void BtnDel_Click(object sender, EventArgs e)
        {
         //verifier si il y un contact selectionné  
                if (listBox.SelectedItems.Count != 0)
                {
                    while (listBox.SelectedIndex != -1)
                    {
                        Lste.SupprimerContact(Lste.LstPerson[listBox.SelectedIndex]);
                        listBox.Items.RemoveAt(listBox.SelectedIndex);
                    }
                }

            Clean();
            listBox.ClearSelected();
            StatuButton(false);
        }

        //activer lo form pour modifier le contact sélectionné
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            ReadOnly(false);
            StatuButton(true);
        }

        // sauvgarder Le changement si il y en a ou ajouter nouveu contact a la listBox et a la RegistreContact 
        private void BtnSave_Click(object sender, EventArgs e)
        {
            //cree nouveu contact 
            Contact ncontact = new Contact();
            //verifier si les information bien saisi
            if (SauvgarderContact(ncontact))
            {
                try
                {
                    //verifier si le nouveu contact existe deja
                    if (Utilitaire.VerefierDoublan(ncontact, Lste.LstPerson))
                    {
                        //verifier si pas de contact selectioné on l'ajoute
                        if (listBox.SelectedIndex <= -1)
                        {
                            Lste.AjouterContact(ncontact);
                            listBox.Items.Add(ncontact.ToString());
                            Clean();
                            StatuButton(false);
                            ReadOnly(true);
                            MessageBox.Show(" the Contact has been Added");
                        }
                        else
                        {
                            //si il y a contact selectionné on le modifie
                            Lste.LstPerson[listBox.SelectedIndex] = ncontact;
                            listBox.Items[listBox.SelectedIndex] = Lste.LstPerson[listBox.SelectedIndex].ToString();
                            Clean();
                            btnDel.Enabled = false;
                            btnEdit.Enabled = false;
                            ReadOnly(true);
                            MessageBox.Show("Le contact a été Modifié !");
                            listBox.ClearSelected();

                        }
                    }
                }
                catch (ContatExisteException) { }
            }
        }
      
        //pour annuler l'operation
        private void BtnCncl_Click(object sender, EventArgs e)
        {
            Clean();
            listBox.ClearSelected();
            ReadOnly(true);
            StatuButton(false);

        }

        //remplir les textBoxes Selon le contact sélectionné dans la listeBox 
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex != -1)
            {
                btnEdit.Enabled = true;
                btnSave.Enabled = false;
                btnDel.Enabled = true;

                RemplirChmp(Lste.LstPerson[listBox.SelectedIndex]);
            }
            
            else if (listBox.SelectedIndex == -1)
            {

                listBox.ClearSelected();
               
            }
            ReadOnly(true);
        }
        
        //sauvgarder le registreContact dans le ficher text en fermant l'application
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Manipulation.WriteFile(Lste);
        }

    }
}
