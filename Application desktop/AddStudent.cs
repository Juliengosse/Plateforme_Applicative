using Application_desktop.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application_desktop
{
    public partial class AddStudent : Form
    {
        private readonly HttpClient _httpClient;

        public AddStudent()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
        }

        // Fonction pour valider l'ajout d'un élève
        private async void butvalidate_Click(object sender, EventArgs e)
        {
            try
            {
                // Récupère les informations depuis les champs de texte
                string name = textBoxName.Text;
                string firstname = textBoxFirstname.Text;
                int groupId = int.Parse(textBoxGroup.Text);

                // Crée un objet Student avec les informations récupérées
                Student student = new Student(name, firstname, groupId);

                // Appelle la méthode addStudent avec l'objet Student en paramètre
                await addStudent(student);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Erreur de format : Veuillez entrer un nombre valide pour l'identifiant du groupe.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite lors de la validation de l'ajout de l'élève : " + ex.Message);
            }
        }

        // Méthode pour ajouter un étudiant en faisant une requête POST à l'API
        private async Task addStudent(Student student)
        {
            // Utilisation d'un client HTTP pour effectuer des requêtes
            using (HttpClient client = new HttpClient())
            {
                // Spécification de l'URL de l'API
                string token = await GetTokenAsync();
                SetAuthorizationHeader(token);
                string apiUrl = "http://localhost:5148/AddStudent";

                // Sérialisation de l'objet Student en JSON
                string json = JsonConvert.SerializeObject(student);

                // Création du contenu de la requête avec le JSON, en spécifiant l'encodage et le type de contenu
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    // Envoi de la requête POST à l'API avec le contenu
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    // Vérification si la requête a réussi (statut 2xx)
                    if (response.IsSuccessStatusCode)
                    {
                        // Affichage d'un message de succès
                        MessageBox.Show("Élève ajouté avec succès !");
                    }
                    else
                    {
                        // Affichage d'un message d'erreur avec la raison de l'échec
                        MessageBox.Show("Erreur lors de l'ajout : " + response.ReasonPhrase);
                    }
                }
                catch (Exception ex)
                {
                    // En cas d'exception, affichage d'un message d'erreur
                    MessageBox.Show("Une erreur s'est produite lors de l'ajout de l'élève : " + ex.Message);
                }
            }
        }

        public async Task<string> GetTokenAsync()
        {
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5148/Token/Login", new { Username = "3il", Password = "gy;ljD|F1!0E\\S?\",9p+P$w2%=3wJNn)Bb66#.EP2-ySXr2WFG-=GUS&Uyjp-&>" });
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
            return result["token"];
        }

        public void SetAuthorizationHeader(string token)
        {
            if (_httpClient.DefaultRequestHeaders.Contains("Authorization"))
            {
                _httpClient.DefaultRequestHeaders.Remove("Authorization");
            }
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
        }
    }
}
