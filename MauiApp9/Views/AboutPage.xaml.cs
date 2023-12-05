using MauiApp9.ViewModels;

namespace MauiApp9.Views;

public partial class AboutPage : ContentPage
{
	public AboutPage()
	{
		InitializeComponent();
		BindingContext= new AboutViewModel();
	}
}