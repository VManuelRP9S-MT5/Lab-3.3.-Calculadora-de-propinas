using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace MauiApp9.ViewModels
{
    public partial class UserPreferencesViewModel : ObservableObject
    {
        private string _displayName;

        public string DisplayName
        {
            get => _displayName;
            set => SetProperty(ref _displayName, value);
        }

        private string _themeSelection;

        public string ThemeSelection
        {
            get => _themeSelection;
            set => SetProperty(ref _themeSelection, value);
        }

        private bool _wifiOnly;

        public bool WifiOnly
        {
            get => _wifiOnly;
            set => SetProperty(ref _wifiOnly, value);
        }

        public string ThemeGroupName => "Theme";

        private IRelayCommand _savePreferencesCommand;
        public IRelayCommand SavePreferencesCommand =>
            _savePreferencesCommand ??= new RelayCommand(SavePreferences);

        public UserPreferencesViewModel()
        {
            DisplayName =Preferences.Default.Get(nameof(DisplayName), string.Empty);
            ThemeSelection = Preferences.Default.Get(nameof(ThemeSelection), "light");
            WifiOnly = Preferences.Default.Get(nameof(WifiOnly), false);
        }

        private void SavePreferences()
        {
            Preferences.Default.Set("DisplayName", DisplayName);
            Preferences.Default.Set("Theme", ThemeSelection);
            Preferences.Default.Set("WifiOnly", WifiOnly);
        }
    }
}
