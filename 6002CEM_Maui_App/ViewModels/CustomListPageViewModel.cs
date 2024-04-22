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
    public partial class CustomListPageViewModel : PageViewModel
    {
        // private readonly IRecipeService _recipeService;
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

        public CustomListPageViewModel(ILocalDatabaseService localDatabaseService)
        {
            //_recipeService = recipeService;
            _localDatabaseService = localDatabaseService;
            UpdateCustomRecipes(true);
        }

        public async void UpdateCustomRecipes(bool custom)
        {
            // Get recipes by category from local db, convert to observablecollection 
            Recipes = new ObservableCollection<RecipeModel>(await _localDatabaseService.GetAllCustom(custom));
        }

        // Navigate to recipe detail page with id param
        [RelayCommand]
        async Task Tap(int id)
        {
            await Shell.Current.GoToAsync($"{nameof(RecipePage)}?id={id}"); 
        }

        // Navigate to create recipe page
        [RelayCommand]
        async Task Add()
        {
            await Shell.Current.GoToAsync(nameof(RecipeCreatePage));
        }

        // Pass id param so recipe create page can be used to edit existing recipe
        [RelayCommand]
        async Task Edit(int id)
        {
            await Shell.Current.GoToAsync($"{nameof(RecipeCreatePage)}?id={id}");
            UpdateCustomRecipes(true);
        }

        // Delete recipe by id after confirm, then refresh
        [RelayCommand]
        async Task Delete(int id)
        {
            bool confirm = await Shell.Current.DisplayAlert("Confirm Deletion", "Discarded recipes cannot be recovered. Do you wish to proceed?", "OK", "Cancel");
            if (confirm)
            {
                await _localDatabaseService.DeleteRecipe(id); 
                UpdateCustomRecipes(true);
            }
        }

        // Navigate back to categories page
        [RelayCommand]
        async Task Back()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}