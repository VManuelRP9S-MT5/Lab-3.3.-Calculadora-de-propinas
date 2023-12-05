using MauiApp9.ViewModels;

namespace MauiApp9.Views;

public partial class UserPreferencesPage : ContentPage
{
    public UserPreferencesPage()
    {
        InitializeComponent();
        BindingContext = new UserPreferencesViewModel();
    }
}