using Microsoft.Maui.Controls;
using MauiApp9.ViewModels;

namespace MauiApp9.Views
{
    public partial class ContributionPage : ContentPage
    {
        public ContributionPage()
        {
            InitializeComponent();

            // Obtener la instancia existente de MainViewModel y vincular el Label al número de personas
            var mainViewModel = new MainViewModel();

            // Asignar el contexto de datos al BindingContext de la página
            BindingContext = mainViewModel;

            // Vincular el Label al número de personas en el MainViewModel
            NumberOfDinersLabel.SetBinding(Label.TextProperty, nameof(mainViewModel.NumeroPersonas), stringFormat: "El número de comensales es: {0}");
        }
    }
}
