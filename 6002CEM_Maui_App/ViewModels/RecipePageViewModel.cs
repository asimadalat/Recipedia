using _6002CEM_Maui_App.Interfaces;
using _6002CEM_Maui_App.Services;
using _6002CEM_Maui_App.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using System.ComponentModel;

namespace _6002CEM_Maui_App.ViewModels
{
    [QueryProperty(nameof(RecipeId), "id")]
    public partial class RecipePageViewModel : PageViewModel
    {

        //private readonly IRecipeService _recipeService;
        private readonly ILocalDatabaseService _localDatabaseService;
        private int _recipeId = -1; // Initial value not 0 or first recipe won't display
        public int RecipeId 
        {
            get { return _recipeId; } // When accessed, return _recipeId
            set
            {
                if (_recipeId != value) // If new value different
                {
                    _recipeId = value; // Update value
                    Initialize(); // Get attributes of new recipe id
                }
                
            }
        }

        // Define attributes to be retrieved
        public string Title { get; set; }
        public string Img {  get; set; }
        public TimeSpan PrepTime { get; set; }
        public TimeSpan CookTime { get; set; }
        public string Description { get; set; }
        public string Steps { get; set; }
        public string Ingredients { get; set; }
        public bool IsFave { get; set; }
        public string IsFaveImg
        {
            get
            {
                return IsFave ? "starfilledicon.svg" : "staroutlinedicon.svg";
            }
        }

        public RecipePageViewModel(ILocalDatabaseService localDatabaseService)
        {
            //_recipeService = recipeService;
            _localDatabaseService = localDatabaseService;
        }

        public async Task getRecipeData(int id)
        {
            // Get single recipe by matching id
            RecipeModel recipe = await _localDatabaseService.GetById(id);

            Title = recipe.Title; // Set corresponding properties
            OnPropertyChanged(nameof(Title)); // Use OnPropertyChanged for update to visual interface
            Img = recipe.Image; 
            OnPropertyChanged(nameof(Img));
            PrepTime = recipe.PreparationTime;
            OnPropertyChanged(nameof(PrepTime));
            CookTime = recipe.CookingTime;
            OnPropertyChanged(nameof(CookTime));
            Description = recipe.Description;
            OnPropertyChanged(nameof(Description));
            Steps = recipe.Steps;
            OnPropertyChanged(nameof(Steps));
            Ingredients = recipe.Ingredients;
            OnPropertyChanged(nameof(Ingredients));
            IsFave = recipe.IsFave;
            OnPropertyChanged(nameof(IsFave));
            OnPropertyChanged(nameof(IsFaveImg));
        }

        [RelayCommand]
        private void SetId()
        {
            ToggleIsFave(RecipeId);
        }

        public async Task ToggleIsFave(int id)
        {
            RecipeModel recipe = await _localDatabaseService.GetById(id);
            Debug.WriteLine($"ID Receieved: {id}");
            recipe.IsFave = !recipe.IsFave;
            await _localDatabaseService.SetFave(recipe);
            IsFave = recipe.IsFave;
            OnPropertyChanged(nameof(IsFaveImg));
        }

        public async Task Initialize()
        {
            await getRecipeData(RecipeId);
        }

        [RelayCommand]
        async Task NavigateBack()
        {
            await Shell.Current.GoToAsync(".."); // Navigate back to list/favourites page
        }
    }
}