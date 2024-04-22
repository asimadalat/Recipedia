using System.Runtime.CompilerServices;
using _6002CEM_Maui_App.ViewModels;

namespace _6002CEM_Maui_App.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsPageViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
	}
}