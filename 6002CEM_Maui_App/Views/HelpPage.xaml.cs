using _6002CEM_Maui_App.ViewModels;

namespace _6002CEM_Maui_App.Views;

public partial class HelpPage : ContentPage
{
	public HelpPage(HelpPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}