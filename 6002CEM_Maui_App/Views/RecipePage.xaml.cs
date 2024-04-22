using _6002CEM_Maui_App.ViewModels;

namespace _6002CEM_Maui_App.Views;

public partial class RecipePage : ContentPage
{ 
    public RecipePage(RecipePageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}