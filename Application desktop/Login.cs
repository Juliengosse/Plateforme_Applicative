using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application_desktop
{
    public partial class Login : Form
    {
        SqlCommand cmd;
        SqlConnection cn;
        SqlDataReader dr;

        public Login()
        {
            InitializeComponent();
        }

        // Méthode appelée lors du chargement du formulaire "Login"
        private void Login_Load(object sender, EventArgs e)
        {
            // Connexion à la base de données
            cn = new SqlConnection(@"Data Source=JULIEN\PR3_PLATAPPLI;Initial Catalog=""PR3 - Plateforme Applicative"";Integrated Security=True");
            cn.Open();
        }

        // Méthode appelée lorsqu'on clique sur le bouton de connexion "butConnection"
        private void butConnection_Click(object sender, EventArgs e)
        {
            // Vérifie si les champs txtPassword et txtUsername ne sont pas vides
            if (txtPassword.Text != string.Empty || txtUsername.Text != string.Empty)
            {
                // Commande SQL qui récupère le nom et le mot de passe de l'utilisateur
                cmd = new SqlCommand("select * from Users where username='" + txtUsername.Text + "' and password='" + txtPassword.Text + "'", cn);
                dr = cmd.ExecuteReader();

                // Vérifie si le nom et le mot de passe sont valides
                if (dr.Read())
                {
                    dr.Close();
                    this.Hide();
                    Home home = new Home();
                    home.ShowDialog(); // Affiche le formulaire "Home"
                }
                else
                {
                    dr.Close();
                    MessageBox.Show("No Account available with this username and password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Affiche un message d'erreur si aucun compte correspondant n'a été trouvé
                }

            }
            else
            {
                MessageBox.Show("Please enter value in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Affiche un message d'erreur si tous les champs ne sont pas remplis
            }
        }

        // Méthode appelée lorsqu'on clique sur le bouton de suppression "butDelete"
        private void butDelete_Click(object sender, EventArgs e)
        {
            // Remet les champs txtUsername et txtPassword vides
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }

    }
}
