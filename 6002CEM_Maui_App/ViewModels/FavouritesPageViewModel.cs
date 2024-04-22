using _6002CEM_Maui_App.Interfaces;
using _6002CEM_Maui_App.Models;
using _6002CEM_Maui_App.Views;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;

namespace _6002CEM_Maui_App.ViewModels
{
    public partial class FavouritesPageViewModel : PageViewModel
    {
        private readonly ILocalDatabaseService _localDatabaseService;

        private ObservableCollection<RecipeModel> _recipes;
        public ObservableCollection<RecipeModel> Recipes
        {
            get { return _recipes; }
            set
            {
                if (_recipes != value)
                {
                    _recipes = value;
                    OnPropertyChanged(nameof(Recipes));
                }
            }
        }

        public FavouritesPageViewModel(ILocalDatabaseService localDatabaseService)
        {
            _localDatabaseService = localDatabaseService;
            updateRecipes();
        }

        public async void updateRecipes()
        {
            // Get all recipes from local db, convert to observablecollection 
            Recipes = new ObservableCollection<RecipeModel>(await _localDatabaseService.GetAllFave());
        }

        [RelayCommand]
        async Task Tap(int id)
        {
            await Shell.Current.GoToAsync($"{nameof(RecipePage)}?id={id}"); // Navigate to recipe detail page with id param
        }
    }
}
