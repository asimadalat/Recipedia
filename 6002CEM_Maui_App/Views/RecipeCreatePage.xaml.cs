using _6002CEM_Maui_App.ViewModels;
using System.Diagnostics;

namespace _6002CEM_Maui_App.Views;

public partial class RecipeCreatePage : ContentPage
{
    public RecipeCreatePage(RecipeCreatePageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;

        for (int i = 1; i < 61; i++)
        {
            prepMinutePicker.Items.Add(i.ToString());
            cookMinutePicker.Items.Add(i.ToString());
        }
    }
}

