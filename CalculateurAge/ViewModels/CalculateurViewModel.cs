namespace CalculateurAge.ViewModels;

// Contient l'ÉTAT de l'écran et les ACTIONS possibles.
public class CalculateurViewModel : BaseViewModel
{
    // Champs privés : la vraie donnée.
    private string _nom = "";
    private DateTime _dateNaissance =
        DateTime.Today.AddYears(-20);
    private string _resultat = "";
    private bool _resultatVisible;
    private string _message = "";
    private string _joursRestants = "";

    // Propriétés publiques : ce que le XAML voit.
    public string Nom
    {
        get => _nom;
        set
        {
            if (SetField(ref _nom, value))
                CalculerCommand.Rafraichir();
        }
    }

    public DateTime DateNaissance
    {
        get => _dateNaissance;
        set => SetField(ref _dateNaissance, value);
    }

    public string Resultat
    {
        get => _resultat;
        set => SetField(ref _resultat, value);
    }

    public bool ResultatVisible
    {
        get => _resultatVisible;
        set => SetField(ref _resultatVisible, value);
    }

    public string Message
    {
        get => _message;
        set => SetField(ref _message, value);
    }

    // Texte affiché pour les jours restants.
    public string JoursRestants
    {
        get => _joursRestants;
        set => SetField(ref _joursRestants, value);
    }

    // Lié à Button.Command dans le XAML.
    public RelayCommand CalculerCommand { get; }

    // la commande du bouton Effacer.
    public RelayCommand EffacerCommand { get; }

    public CalculateurViewModel()
    {
        CalculerCommand = new RelayCommand(
            Calculer,
            () => !string.IsNullOrWhiteSpace(Nom));

        // on relie la commande à la méthode Effacer.
        EffacerCommand = new RelayCommand(Effacer);
    }

    // La logique métier : aucun contrôle d'interface ici.
    private void Calculer()
    {
        int age = DateTime.Today.Year - DateNaissance.Year;
        if (DateNaissance.Date >
            DateTime.Today.AddYears(-age)) age--;

        Resultat = $"{Nom}, vous avez {age} ans";
        ResultatVisible = true;
        Message = age >= 18 ? "Majeur" : "Mineur";

        //prochain anniversaire (cette année ou la suivante).
        DateTime prochain = DateNaissance.Date.AddYears(age);
        if (prochain < DateTime.Today)
            prochain = DateNaissance.Date.AddYears(age + 1);
        int jours = (prochain - DateTime.Today).Days;
        JoursRestants = $"Prochain anniversaire dans {jours} jour(s)";
    }

    // remet tous les champs à zéro.
    private void Effacer()
    {
        Nom = "";
        DateNaissance = DateTime.Today.AddYears(-20);
        Resultat = "";
        Message = "";
        JoursRestants = ""; 
        ResultatVisible = false;
    }
}