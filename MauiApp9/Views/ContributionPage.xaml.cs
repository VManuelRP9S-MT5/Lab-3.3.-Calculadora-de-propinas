using Microsoft.Maui.Controls;
using MauiApp9.ViewModels;

namespace MauiApp9.Views
{
    public partial class ContributionPage : ContentPage
    {
        public ContributionPage()
        {
            InitializeComponent();

            // Obtener la instancia existente de MainViewModel y vincular el Label al n�mero de personas
            var mainViewModel = new MainViewModel();

            // Asignar el contexto de datos al BindingContext de la p�gina
            BindingContext = mainViewModel;

            // Vincular el Label al n�mero de personas en el MainViewModel
            NumberOfDinersLabel.SetBinding(Label.TextProperty, nameof(mainViewModel.NumeroPersonas), stringFormat: "El n�mero de comensales es: {0}");
        }
    }
}
