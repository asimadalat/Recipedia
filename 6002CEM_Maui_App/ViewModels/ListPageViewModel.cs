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
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace _6002CEM_Maui_App.ViewModels
{
    [QueryProperty(nameof(CategoryTitle), "category")]
    [QueryProperty(nameof(SearchQuery), "query")]
    public partial class ListPageViewModel : PageViewModel
    {
        // private readonly IRecipeService _recipeService;
        private readonly ILocalDatabaseService _localDatabaseService;

        private string _categoryTitle;
        public string CategoryTitle
        {
            get { return _categoryTitle; } // When accessed, return _categoryTitle
            set
            {
                if (_categoryTitle != value) // If new value different
                {
                    _categoryTitle = value; // Update value
                    UpdateCategoryRecipes(_categoryTitle); // Get recipes by category
                }

            }
        }

        private string _searchQuery;
        public string SearchQuery
        {
            get { return _searchQuery; } // When accessed, return _searchQuery
            set
            {
                if (_searchQuery != value) // If new value different
                {
                    _searchQuery = value; // Update value
                    SearchRecipes(_searchQuery); // Get recipes by search
                }

            }
        }


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

        public ListPageViewModel(ILocalDatabaseService localDatabaseService)
        {
            //_recipeService = recipeService;
            _localDatabaseService = localDatabaseService;

        }


        public async void UpdateCategoryRecipes(string category)
        {
            // Get recipes by category from local db, convert to observablecollection 
            Recipes = new ObservableCollection<RecipeModel>(await _localDatabaseService.GetByCategory(category));
        }

        public async void SearchRecipes(string squery)
        {
            Debug.WriteLine(squery);
            // Search recipes by name from local db, convert to observablecollection 
            Recipes = new ObservableCollection<RecipeModel>(await _localDatabaseService.GetSearchRecipes(squery));
        }

        [RelayCommand]
        async Task Tap(int id)
        {
            await Shell.Current.GoToAsync($"{nameof(RecipePage)}?id={id}"); // Navigate to recipe detail page with id param
        }

        [RelayCommand]
        async Task Back()
        {
            await Shell.Current.GoToAsync(".."); // Navigate back to categories page
        }
    }
}
