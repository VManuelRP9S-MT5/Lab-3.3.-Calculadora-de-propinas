using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Threading.Tasks;


namespace MauiApp9.ViewModels
{
    public partial class AboutViewModel : ObservableObject
    {
        private string _apiVersion;

        public string ApiVersion
        {
            get => _apiVersion;
            set => SetProperty(ref _apiVersion, value);
        }

        public AboutViewModel()
        {
            ApiVersion = "Version 0.1";
        }

        private IAsyncRelayCommand _openPreferencesCommand;
        public IAsyncRelayCommand OpenPreferencesCommand =>
            _openPreferencesCommand ??= new AsyncRelayCommand(OpenPreferences);

        private async Task OpenPreferences()
        {
            await Shell.Current.GoToAsync("UserPreferences"); // Asegúrate de proporcionar la página a la que quieres navegar
        }
    }
}
