using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application_desktop.Models;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Application_desktop
{
    public partial class StudentList : Form
    {
        private readonly HttpClient _httpClient;

        public StudentList()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            this.Load += loadStudentList;

            MainMenuStrip menuStrip = new MainMenuStrip();
            //Ajout du menuStrip
            Controls.Add(menuStrip);
        }

        // Fonction lancée au chargement du formulaire "Load"
        public async void loadStudentList(object sender, EventArgs e)
        {
            try
            {
                await fillDataGridView(); // Appelle la méthode pour remplir le DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite lors du chargement des élèves : " + ex.Message);
            }
        }

        // Remplissage du tableau avec les données des élèves
        public async Task fillDataGridView()
        {
            try
            {
                string token = await GetTokenAsync();
                SetAuthorizationHeader(token);

                // Appel de l'API pour récupérer la liste des élèves
                string path = "http://localhost:5148/GetAllStudent";
                HttpResponseMessage request = await _httpClient.GetAsync(path);

                if (request.IsSuccessStatusCode)
                {
                    // Extraction du contenu de la réponse
                    var content = await request.Content.ReadAsStringAsync();
                    var students = JsonConvert.DeserializeObject<List<Student>>(content);

                // Mise en place des données dans le DataGridView
                foreach (var student in students)
                {
                    int rowIndex = dataGridView.Rows.Add();
                    dataGridView.Rows[rowIndex].Cells["dataGridViewTextBoxColumnId"].Value = student.Id;
                    dataGridView.Rows[rowIndex].Cells["dataGridViewTextBoxColumnName"].Value = student.Name;
                    dataGridView.Rows[rowIndex].Cells["dataGridViewTextBoxColumnFirstname"].Value = student.Firstname;

                    // Récupération de l'intitulé du groupe
                        string groupPath = "http://localhost:5148/GetByIdGroup/" + student.GroupId;
                        HttpResponseMessage requestClass = await _httpClient.GetAsync(groupPath);

                        if (requestClass.IsSuccessStatusCode)
                        {
                            var groupContent = await requestClass.Content.ReadAsStringAsync();
                            var groupStudent = JsonConvert.DeserializeObject<Group>(groupContent);

                            if (groupStudent != null)
                                dataGridView.Rows[rowIndex].Cells["dataGridViewTextBoxColumnClass"].Value = groupStudent.Cycle + " " + groupStudent.Section + " " + groupStudent.SubSection;
                            else
                                dataGridView.Rows[rowIndex].Cells["dataGridViewTextBoxColumnClass"].Value = " ";
                        }
                 }
                }
                else
                {
                    MessageBox.Show("Erreur lors de la récupération des élèves : " + request.ReasonPhrase);
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
                    // Récupération des données de l'élève à modifier
                    DataGridViewCell studentIdCell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex - 4];
                    DataGridViewCell nameCell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex - 3];
                    DataGridViewCell firstnameCell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex - 2];
                    DataGridViewCell groupIdCell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex - 1];

                    if (nameCell.Value != null && firstnameCell.Value != null && groupIdCell.Value != null && studentIdCell.Value != null)
                    {
                        string name = nameCell.Value.ToString();
                        string firstname = firstnameCell.Value.ToString();
                        string group = groupIdCell.Value.ToString();
                        string studentId = studentIdCell.Value.ToString();

                        char delimiter = ' '; // Le délimiteur que vous souhaitez utiliser
                        string[] parts = group.Split(delimiter);

                        string cycle = parts[0];
                        string section = parts[1];
                        string subSection = parts[2];

                        string token = await GetTokenAsync();
                        SetAuthorizationHeader(token);

                        string path = $"http://localhost:5148/GetGroupId/{cycle}/{section}/{subSection}";
                        HttpResponseMessage request = await _httpClient.GetAsync(path);

                        if (request.IsSuccessStatusCode)
                        {

                            string content = await request.Content.ReadAsStringAsync();

                            // Convertir la chaîne JSON en un objet JObject
                            JObject jsonResult = JObject.Parse(content);

                            // Récupérer la valeur de la clé "result"
                            int resultValue = (int)jsonResult["result"];

                            //int groupId = int.Parse(content);

                            Student student = new Student(int.Parse(studentId), name, firstname, resultValue);

                            UpdateStudent(int.Parse(studentId), student); // Appel de la méthode pour mettre à jour l'élève
                        }
                    }
                }

                if (e.ColumnIndex == butColumnDelete.Index && e.RowIndex >= 0)
                {
                    // Récupération de l'ID de l'élève à supprimer
                    DataGridViewCell studentIdCell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex - 5];
                    string studentId = studentIdCell.Value.ToString();

                    // Appel de l'API pour supprimer l'élève
                    string token = await GetTokenAsync();
                    SetAuthorizationHeader(token);

                    string path = "http://localhost:5148/DeleteStudent/" + studentId;
                    HttpResponseMessage request = await _httpClient.DeleteAsync(path);

                    if (request.IsSuccessStatusCode)
                    {
                        updateDataGridView(); // Rafraîchit le tableau après la suppression
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
                dataGridView.Rows.Clear();
                fillDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite lors de la mise à jour du tableau : " + ex.Message);
            }
        }

        // Ouvre le formulaire pour ajouter un nouvel élève
        private void butadd_Click(object sender, EventArgs e)
        {
            try
            {
                AddStudent addStudent = new AddStudent();
                addStudent.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite lors de l'ajout d'un élève : " + ex.Message);
            }
        }

        // Rafraîchit le tableau
        private void refresh_Click(object sender, EventArgs e)
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

        // Met à jour un élève via une requête HTTP PUT
        private async void UpdateStudent(int studentId, Student updatedStudent)
        {
            try
            {
                // Utilisation d'un bloc 'using' pour garantir que la ressource HttpClient est correctement libérée
                using (HttpClient client = new HttpClient())
                {
                    string token = await GetTokenAsync();
                    SetAuthorizationHeader(token);

                    string apiUrl = "http://localhost:5148/UpdateStudent/" + studentId; // Définition de l'URL de l'API

                    string json = JsonConvert.SerializeObject(updatedStudent); // Convertit l'objet 'updatedStudent' en format JSON
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json"); // Crée un contenu HTTP avec le JSON

                    HttpResponseMessage response = await client.PutAsync(apiUrl, content); // Envoie une requête PUT à l'API

                    if (response.IsSuccessStatusCode) // Si la requête est réussie (code de statut 2xx)
                    {
                        updateDataGridView(); // Rafraîchit le tableau après la mise à jour
                        MessageBox.Show("Mise à jour réussie !"); // Affiche un message de succès
                    }
                    else // Si la requête a échoué
                    {
                        MessageBox.Show("Erreur lors de la mise à jour : " + response.ReasonPhrase); // Affiche un message d'erreur
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite lors de la mise à jour de l'élève : " + ex.Message); // Affiche un message d'erreur
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
