using CalculateurAge.Views;

namespace CalculateurAge
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
        }

        //Gestionnaire appeler au clic du bouton Calculer
        //sender = le controle clique ; e =donnees de l'evenement.
        private async void OnCalculerClicked(object sender, EventArgs e)
        {
            //validation : on refuse un nom vide.
            if (string.IsNullOrWhiteSpace(entryNom.Text))
            {
                await DisplayAlertAsync("Erreur", "Entrez un nom", "OK");
                return; //on sort sans rien calculer
            }

            DateTime d = pickerDate.Date.GetValueOrDefault();
            int age = DateTime.Today.Year - d.Year;
            //Si l'anniversaire n'est pas encore passe cette annee,
            //on retire une annee.
            if (d.Date > DateTime.Today.AddYears(-age)) age--;

            //on ecrit DIRECTEMENT dans les controles : c'est
            //precisement ce que le MWWM va supprimer.
            await Shell.Current.GoToAsync(
            $"{nameof(ResultatPage)}?nom={entryNom.Text}&age={age}");

        }

    }
}
