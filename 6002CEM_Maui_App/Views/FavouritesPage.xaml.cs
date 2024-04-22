using _6002CEM_Maui_App.Models;
using _6002CEM_Maui_App.ViewModels;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Controls.PlatformConfiguration;
using System.Collections.ObjectModel;

namespace _6002CEM_Maui_App.Views
{
    public partial class FavouritesPage : ContentPage
    {
        private FavouritesPageViewModel _viewModel;
        public FavouritesPage(FavouritesPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            _viewModel = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Update recipes on each page load
            _viewModel.updateRecipes();
        }
    }
}