using Microsoft.Maui.Controls;
using MauiApp9.ViewModels;

namespace MauiApp9.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }
}
