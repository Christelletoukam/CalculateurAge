using CalculateurAge.ViewModels;
using CalculateurAge.Views;

namespace CalculateurAge
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
            // Objet dans lequel tous les {Binding} de la page
            // vont chercher leurs valeurs.
            BindingContext = new CalculateurViewModel();
        }


    }
}
