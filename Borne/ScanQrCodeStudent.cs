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

        // M�thode appel�e lors du chargement du formulaire
        private void ScanQrCodeStudent_load(object sender, EventArgs e)
        {
            // Initialise la collection de filtres pour les p�riph�riques vid�o
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            // Parcourt la collection et ajoute les noms des p�riph�riques � la liste d�roulante
            foreach (FilterInfo filterInfo in filterInfoCollection)
            {
                cmbBox.Items.Add(filterInfo.Name);
            }

            // S�lectionne le premier p�riph�rique par d�faut
            cmbBox.SelectedIndex = 0;
        }

        // �v�nement d�clench� lorsqu'un nouveau cadre est captur� par le p�riph�rique vid�o
        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // Met � jour l'image affich�e dans le PictureBox avec le nouveau cadre
            pictureBox.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        // �v�nement d�clench� lorsqu'un bouton est cliqu� pour d�marrer la capture vid�o
        private void button_Click(object sender, EventArgs e)
        {
            // Cr�e un nouveau VideoCaptureDevice en utilisant le p�riph�rique s�lectionn�
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cmbBox.SelectedIndex].MonikerString);

            // Ajoute un gestionnaire d'�v�nement pour le nouveau cadre
            videoCaptureDevice.NewFrame += new NewFrameEventHandler(VideoCaptureDevice_NewFrame);

            // D�marre la capture vid�o
            videoCaptureDevice.Start();

            // D�marre le timer
            timer.Start();
        }

        // �v�nement d�clench� lors de la fermeture du formulaire
        private void ScanQrCodeStudent_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // Arr�te la capture vid�o si elle est en cours
                if (videoCaptureDevice != null && videoCaptureDevice.IsRunning)
                {
                    videoCaptureDevice.SignalToStop(); // Arr�te la capture
                    videoCaptureDevice.WaitForStop(); // Attend que la capture s'arr�te compl�tement
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite lors de l'arr�t de la capture : " + ex.Message);
            }
        }

        // �v�nement d�clench� � intervalles r�guliers par le Timer
        private async void timer_Tick(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                BarcodeReader barcodeReader = new BarcodeReader();
                Result result = barcodeReader.Decode((Bitmap)pictureBox.Image);

                if (result != null)
                {
                    // L'ID de l'�l�ve est stock� dans 'result.Text'
                    string studentId = result.Text;

                    // Envoi de la requ�te pour ajouter l'�l�ve
                    await AddPresence(studentId);

                    timer.Stop();
                }
            }
        }

        // M�thode pour ajouter la pr�sence de l'�tudiant
        private async Task AddPresence(string studentId)
        {
            // Utilisation de HttpClient pour envoyer la requ�te HTTP
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "https://localhost:7020/AddStudentPresence";

                // Cr�er un objet qui contient l'ID de l'�l�ve et la date de pr�sence
                string formattedDate = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                var data = new { StudentId = studentId, attendanceDate = formattedDate };

                // Convertit l'objet en JSON
                string json = JsonConvert.SerializeObject(data);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    // Envoie la requ�te POST
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Pr�sence ajout�e avec succ�s !");
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de l'ajout de la pr�sence : " + response.ReasonPhrase);
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