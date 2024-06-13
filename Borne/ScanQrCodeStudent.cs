using AForge.Video;
using AForge.Video.DirectShow;
using Application_desktop.Models;
using Newtonsoft.Json;
using System.Text;
using ZXing;
using ZXing.Windows.Compatibility;


namespace Borne
{
    public partial class ScanQrCodeStudent : Form
    {
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;

        public ScanQrCodeStudent()
        {
            InitializeComponent();
        }

        // Méthode appelée lors du chargement du formulaire
        private void ScanQrCodeStudent_load(object sender, EventArgs e)
        {
            // Initialise la collection de filtres pour les périphériques vidéo
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            // Parcourt la collection et ajoute les noms des périphériques à la liste déroulante
            foreach (FilterInfo filterInfo in filterInfoCollection)
            {
                cmbBox.Items.Add(filterInfo.Name);
            }

            // Sélectionne le premier périphérique par défaut
            cmbBox.SelectedIndex = 0;
        }

        // Événement déclenché lorsqu'un nouveau cadre est capturé par le périphérique vidéo
        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // Met à jour l'image affichée dans le PictureBox avec le nouveau cadre
            pictureBox.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        // Événement déclenché lorsqu'un bouton est cliqué pour démarrer la capture vidéo
        private void button_Click(object sender, EventArgs e)
        {
            // Crée un nouveau VideoCaptureDevice en utilisant le périphérique sélectionné
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cmbBox.SelectedIndex].MonikerString);

            // Ajoute un gestionnaire d'événement pour le nouveau cadre
            videoCaptureDevice.NewFrame += new NewFrameEventHandler(VideoCaptureDevice_NewFrame);

            // Démarre la capture vidéo
            videoCaptureDevice.Start();

            // Démarre le timer
            timer.Start();
        }

        // Événement déclenché lors de la fermeture du formulaire
        private void ScanQrCodeStudent_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // Arrête la capture vidéo si elle est en cours
                if (videoCaptureDevice != null && videoCaptureDevice.IsRunning)
                {
                    videoCaptureDevice.SignalToStop(); // Arrête la capture
                    videoCaptureDevice.WaitForStop(); // Attend que la capture s'arrête complètement
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite lors de l'arrêt de la capture : " + ex.Message);
            }
        }

        // Événement déclenché à intervalles réguliers par le Timer
        private async void timer_Tick(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                BarcodeReader barcodeReader = new BarcodeReader();
                Result result = barcodeReader.Decode((Bitmap)pictureBox.Image);

                if (result != null)
                {
                    // L'ID de l'élève est stocké dans 'result.Text'
                    string studentId = result.Text;

                    // Envoi de la requête pour ajouter l'élève
                    await AddPresence(studentId);

                    timer.Stop();
                }
            }
        }

        // Méthode pour ajouter la présence de l'étudiant
        private async Task AddPresence(string studentId)
        {
            // Utilisation de HttpClient pour envoyer la requête HTTP
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "https://localhost:7020/AddStudentPresence";

                // Créer un objet qui contient l'ID de l'élève et la date de présence
                string formattedDate = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                var data = new { StudentId = studentId, attendanceDate = formattedDate };

                // Convertit l'objet en JSON
                string json = JsonConvert.SerializeObject(data);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    // Envoie la requête POST
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Présence ajoutée avec succès !");
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de l'ajout de la présence : " + response.ReasonPhrase);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Une erreur s'est produite : " + ex.Message);
                }
            }
        }

    }
}