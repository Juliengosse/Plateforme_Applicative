using Application_desktop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Net.Http.Json;

namespace Application_desktop
{
    public partial class AddGroupForm : Form
    {
        private readonly HttpClient _httpClient;

        public AddGroupForm()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
        }

        // Fonction pour valider l'ajout d'un groupe
        private async void butValidate_Click(object sender, EventArgs e)
        {
            try
            {
                // Récupère les informations depuis les champs de texte
                string cycle = textBoxCycle.Text;
                string section = textBoxSection.Text;
                string subSection = textBoxSubSection.Text;

                // Crée un objet Group avec les informations récupérées
                Group group = new Group(cycle, section, subSection);

                // Appelle la méthode addGroup avec l'objet Group en paramètre
                await addGroup(group);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite lors de la validation de l'ajout du groupe : " + ex.Message);
            }
        }

        // Méthode pour ajouter un groupe en faisant une requête POST à l'API
        private async Task addGroup(Group group)
        {
            // Utilisation d'un client HTTP pour effectuer des requêtes
            using (HttpClient client = new HttpClient())
            {
                // Spécification de l'URL de l'API
                string token = await GetTokenAsync();
                SetAuthorizationHeader(token);
                string apiUrl = "http://localhost:5148/AddGroup";

                // Sérialisation de l'objet Group en JSON
                string json = JsonConvert.SerializeObject(group);

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
                        MessageBox.Show("Groupe ajouté avec succès !");
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
                    MessageBox.Show("Une erreur s'est produite lors de l'ajout du groupe : " + ex.Message);
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