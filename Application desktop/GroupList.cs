using System.Data.SqlClient;
using System.Net.Http.Json;
using System.Text;
using Application_desktop.Models;
using Newtonsoft.Json;

namespace Application_desktop
{
    public partial class GroupList : Form
    {
        private readonly HttpClient _httpClient;

        public GroupList()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            this.Load += loadGroupList;

            MainMenuStrip menuStrip = new MainMenuStrip();

            //Ajout du menuStrip
            Controls.Add(menuStrip);
        }

        // Fonction lancée au chargement du formulaire
        public async void loadGroupList(object sender, EventArgs e)
        {
            try
            {
                await fillDataGridView(); // Appelle la méthode pour remplir le DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite lors du chargement des groupes : " + ex.Message);
            }
        }

        // Remplissage du tableau avec les données des groupes
        public async Task fillDataGridView()
        {
            try
            {
                string token = await GetTokenAsync();
                SetAuthorizationHeader(token);

                // Appel de l'API pour récupérer la liste des groupes
                string path = "http://localhost:5148/GetAllGroup";
                HttpResponseMessage request = await _httpClient.GetAsync(path);

                if (request.IsSuccessStatusCode)
                {
                    // Extraction du contenu de la réponse
                    var content = await request.Content.ReadAsStringAsync();
                    var groups = JsonConvert.DeserializeObject<List<Group>>(content);

                // Mise en place des données dans le DataGridView
                foreach (var group in groups)
                {
                    int rowIndex = dataGridView.Rows.Add();
                    dataGridView.Rows[rowIndex].Cells["dataGridViewTextBoxColumnId"].Value = group.Id;
                    dataGridView.Rows[rowIndex].Cells["dataGridViewTextBoxColumnCycle"].Value = group.Cycle;
                    dataGridView.Rows[rowIndex].Cells["dataGridViewTextBoxColumnSection"].Value = group.Section;
                    dataGridView.Rows[rowIndex].Cells["dataGridViewTextBoxColumnSubSection"].Value = group.SubSection;
                }
            }
                else
                {
                    MessageBox.Show("Erreur lors de la récupération des groupes : " + request.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite lors du remplissage du tableau : " + ex.Message);
            }
        }

        // Gestion d'un clic sur une cellule du DataGridView
        private async void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == butColumnEdit.Index && e.RowIndex >= 0)
                {
                    // Récupération des données du groupe à modifier
                    DataGridViewCell cycleCell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex - 3];
                    string cycle = cycleCell.Value.ToString();

                    DataGridViewCell sectionCell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex - 2];
                    string section = sectionCell.Value.ToString();

                    DataGridViewCell subSectionCell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex - 1];
                    string subSection = subSectionCell.Value.ToString();

                    DataGridViewCell groupIdCell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex - 4];
                    string groupId = groupIdCell.Value.ToString();

                    Group group = new Group(int.Parse(groupId), cycle, section, subSection);

                    UpdateGroup(int.Parse(groupId), group); // Appel de la méthode pour mettre à jour le groupe
                }

                if (e.ColumnIndex == butColumnDelete.Index && e.RowIndex >= 0)
                {
                    
                    // Récupération de l'ID du groupe à supprimer
                    DataGridViewCell groupIdCell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex - 5];
                    string groupId = groupIdCell.Value.ToString();

                    if (DoesGroupHaveStudents(int.Parse(groupId)) == false)
                    {
                        // Appel de l'API pour supprimer le groupe
                        string token = await GetTokenAsync();
                        SetAuthorizationHeader(token);
                        string path = "http://localhost:5148/DeleteGroup/" + groupId;
                        HttpResponseMessage request = await _httpClient.DeleteAsync(path);

                        if (request.IsSuccessStatusCode)
                        {
                        updateDataGridView(); // Rafraîchit le tableau après la suppression
                    }
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite lors de la gestion du clic : " + ex.Message);
            }
        }

        // Met à jour le tableau en le vidant et en le remplissant à nouveau
        public void updateDataGridView()
        {
            try
            {
                dataGridView.Rows.Clear(); // Efface toutes les lignes du tableau
                fillDataGridView(); // Appelle la méthode pour remplir à nouveau le tableau avec les données actuelles
            }
            catch (Exception ex)
            {
                // En cas d'erreur, affiche un message d'erreur avec le détail de l'exception
                MessageBox.Show("Une erreur s'est produite lors de la mise à jour du tableau : " + ex.Message);
            }
        }


        // Ouvre le formulaire pour ajouter un nouveau groupe
        private void butAdd_Click(object sender, EventArgs e)
        {
            try
            {
                AddGroupForm addClass = new AddGroupForm();
                addClass.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite lors de l'ajout d'un groupe : " + ex.Message);
            }
        }

        // Rafraîchit le tableau
        private void butRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                updateDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite lors du rafraîchissement du tableau : " + ex.Message);
            }
        }

        // Met à jour un groupe via une requête HTTP PUT
        private async Task UpdateGroup(int groupId, Group updatedGroup)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string token = await GetTokenAsync();
                    SetAuthorizationHeader(token);

                    string apiUrl = "http://localhost:5148/UpdateGroup/" + groupId; // URL de l'API pour mettre à jour un groupe

                    string json = JsonConvert.SerializeObject(updatedGroup); // Convertit l'objet Group en format JSON
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json"); // Crée un contenu HTTP avec le JSON

                    HttpResponseMessage response = await client.PutAsync(apiUrl, content); // Envoie la requête PUT à l'API

                    if (response.IsSuccessStatusCode)
                    {
                        updateDataGridView(); // Si la mise à jour réussit, met à jour l'affichage du tableau
                        MessageBox.Show("Mise à jour réussie !"); // Affiche un message de succès
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de la mise à jour : " + response.ReasonPhrase); // En cas d'erreur, affiche le message d'erreur de la réponse HTTP
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite lors de la mise à jour du groupe : " + ex.Message); // En cas d'exception, affiche un message d'erreur avec le détail de l'exception
            }
        }


        public bool DoesGroupHaveStudents(int groupId)
        {
            // Utilisation d'un bloc using pour s'assurer que la connexion est correctement gérée
            using (SqlConnection connection = new SqlConnection("Server=JULIEN\\PR3_PLATAPPLI;Database=PR3 - Plateforme Applicative;Integrated Security=True;TrustServerCertificate=True;"))
            {
                connection.Open(); // Ouvre la connexion à la base de données

                string query = "SELECT COUNT(*) FROM Students WHERE GroupId = @groupId"; // Requête SQL pour compter le nombre d'étudiants dans le groupe

                // Utilisation d'un bloc using pour garantir que la commande est correctement gérée
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@groupId", groupId); // Ajoute un paramètre à la commande pour filtrer par groupId

                    int count = (int)command.ExecuteScalar(); // Exécute la requête et récupère le nombre d'étudiants

                    return count > 0; // Renvoie vrai si le nombre d'étudiants est supérieur à zéro (ce qui signifie que le groupe a des étudiants)
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
