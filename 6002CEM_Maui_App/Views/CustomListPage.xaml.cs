using _6002CEM_Maui_App.ViewModels;

namespace _6002CEM_Maui_App.Views;

public partial class CustomListPage : ContentPage
{
    private CustomListPageViewModel _viewModel;
    public CustomListPage(CustomListPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        _viewModel = viewModel;
    }

    // Update recipes on each page load
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.UpdateCustomRecipes(true);
    }
}