using _6002CEM_Maui_App.Interfaces;
using _6002CEM_Maui_App.Services;
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
    public partial class MainPageViewModel : PageViewModel
    {
        //
        private readonly IRecipeService _recipeService;
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

        public MainPageViewModel(ILocalDatabaseService localDatabaseService)
        {
            // _recipeService = recipeService;
            _localDatabaseService = localDatabaseService;
            _recipeService = new RecipeService();
            updateRecipes();
        }

        public async void updateRecipes()
        {
            // Get all recipes from local db, convert to observablecollection 
            Recipes = new ObservableCollection<RecipeModel>(await _localDatabaseService.GetRecipes());
        }

        [RelayCommand]
        async Task Add()
        {
            await Shell.Current.GoToAsync(nameof(RecipeCreatePage)); // Navigate to create recipe page
        }

        [RelayCommand]
        async Task Search(string squery)
        {
            await Shell.Current.GoToAsync($"{nameof(ListPage)}?query={squery}"); // Navigate to recipe list page
        }

        [RelayCommand]
        async Task Tap(int id)
        {
            await Shell.Current.GoToAsync($"{nameof(RecipePage)}?id={id}"); // Navigate to recipe detail page with id param
        }
    }
}