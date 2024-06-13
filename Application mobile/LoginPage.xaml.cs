namespace Application_mobile
{
    public partial class LoginPage : ContentPage
    {
        int count = 0;

        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnConnexionClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(entryNomUtilisateur.Text) && !string.IsNullOrWhiteSpace(entryMotDePasse.Text))
            {
                await DisplayAlert("Connexion réussie", "Bienvenue, " + entryNomUtilisateur.Text, "OK");
            }
            else
            {
                await DisplayAlert("Erreur", "Veuillez entrer votre nom d'utilisateur et votre mot de passe", "OK");
            }
        }
    }
}