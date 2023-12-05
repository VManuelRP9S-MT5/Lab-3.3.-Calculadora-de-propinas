using MauiApp9.Views;

namespace MauiApp9;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("UserPreferences", typeof(UserPreferencesPage));
	}
}
