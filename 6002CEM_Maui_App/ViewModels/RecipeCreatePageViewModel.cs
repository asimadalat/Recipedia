using _6002CEM_Maui_App.Interfaces;
using _6002CEM_Maui_App.Services;
using _6002CEM_Maui_App.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using System.Collections;
using System.Net;
using System.Collections.ObjectModel;

namespace _6002CEM_Maui_App.ViewModels
{
    [QueryProperty(nameof(RecipeId), "id")]
    public partial class RecipeCreatePageViewModel : PageViewModel
    {
        private readonly ILocalDatabaseService _localDatabaseService;
        private int _recipeId = -1; 
        public int RecipeId
        {
            get { return _recipeId; } // When accessed, return _recipeId
            set
            {
                if (_recipeId != value) // If new value different
                {
                    _recipeId = value; // Update value
                    getRecipeData(RecipeId); // Get attributes of new recipe id
                }

            }
        }

        // Define attributes to be retrieved
        public string Title { get; set; }
        public string Img { get; set; }
        public string PrepTime { get; set; }
        public string CookTime { get; set; }
        public string Description { get; set; }
        public string Steps { get; set; }
        public string NumberIngredients { get; set; }
        public string Ingredients { get; set; }
        public string Category { get; set; }
        public List<string> PrepMinutePick { get; set; }
        public List<string> CookMinutePick { get; set; }

        public RecipeCreatePageViewModel(ILocalDatabaseService localDatabaseService)
        {
            _localDatabaseService = localDatabaseService;
        }

        [RelayCommand]
        public async Task getRecipeData(int id)
        {
            // Get single recipe by matching id
            RecipeModel recipe = await _localDatabaseService.GetById(id);

            Title = recipe.Title; // Set corresponding properties
            Img = recipe.Image;
            Description = recipe.Description;
            Steps = recipe.Steps;
            NumberIngredients = recipe.NumberOfIngredients;
            Ingredients = recipe.Ingredients;
            Category = recipe.Category;

            string PrepTimeTs = recipe.PreparationTime.ToString(); // Convert prep/cook time to str, extract minutes
            string CookTimeTs = recipe.CookingTime.ToString();
            string[] prepTimes = PrepTimeTs.Split(':');
            string[] cookTimes = CookTimeTs.Split(':');
            PrepTime = int.Parse(prepTimes[1]).ToString();
            CookTime = int.Parse(cookTimes[1]).ToString();

            OnPropertyChanged(nameof(Title)); //Update all properties in ui
            OnPropertyChanged(nameof(Img));
            OnPropertyChanged(nameof(PrepTime));
            OnPropertyChanged(nameof(CookTime));
            OnPropertyChanged(nameof(Description));
            OnPropertyChanged(nameof(Steps));
            OnPropertyChanged(nameof(NumberIngredients));
            OnPropertyChanged(nameof(Ingredients));
            OnPropertyChanged(nameof(Category));

        }

        [RelayCommand]
        public async Task ValidateData()
        {
            Dictionary<string, string?> fullEntryList = new Dictionary<string, string?>// Pass entry values in dict form
            {
                { "Title", Title },
                { "ImageURL", Img },
                { "NumberOfIngredients", NumberIngredients },
                { "Ingredients", Ingredients },
                { "Steps", Steps },
                { "PrepTime", PrepTime },
                { "CookTime", CookTime },
                { "Description", Description },
                { "Category", Category }
            };

            if (String.IsNullOrWhiteSpace(fullEntryList["Title"]) || String.IsNullOrWhiteSpace(fullEntryList["Ingredients"]) ||
                String.IsNullOrWhiteSpace(fullEntryList["NumberOfIngredients"]) || String.IsNullOrWhiteSpace(fullEntryList["Steps"])) // If they are null or empty space
            {
                await Shell.Current.DisplayAlert("Action Failed", "All required fields must have a value. Number of ingredients field must be a number.", "OK");
            } else
            {
                foreach (char digit in fullEntryList["NumberOfIngredients"] ?? "") // And if number of ingredients has letters
                {
                    if (!char.IsDigit(digit))
                    {
                        await Shell.Current.DisplayAlert("Action Failed", "All required fields must have a value. Number of ingredients field must be a number.", "OK");
                    } else
                    {
                        InsertNewRecipe(fullEntryList);
                        await Shell.Current.DisplayAlert("Success", "Recipe has been successfully saved", "OK");
                    }
                }
            }
       
        }

        // Initialise new recipemodel, set input values to it, insert into db
        public async Task InsertNewRecipe(Dictionary<string, string?> fullEntryList)
        {
            RecipeModel recipe;
            if (_recipeId == -1)
            {
                recipe = new RecipeModel();
            }
            else
            {
                recipe = await _localDatabaseService.GetById(_recipeId);
            }

            recipe.Title = fullEntryList["Title"] ?? "";
            recipe.Image = fullEntryList["ImageURL"] ?? "defaultrecipebanner.jpg";

            // Convert str dictionary value to timespan value accepted by model
            int.TryParse(fullEntryList["PrepTime"], out int prepTimeInt);
            int.TryParse(fullEntryList["CookTime"], out int cookTimeInt);
            TimeSpan prepTimeTs = TimeSpan.FromMinutes(prepTimeInt);
            TimeSpan cookTimeTs = TimeSpan.FromMinutes(cookTimeInt);
            recipe.PreparationTime = prepTimeTs;
            recipe.CookingTime = cookTimeTs;

            recipe.Description = fullEntryList["Description"] ?? "";
            recipe.Category = fullEntryList["Category"] ?? "";
            recipe.Ingredients = fullEntryList["Ingredients"] ?? "";
            recipe.NumberOfIngredients = fullEntryList["NumberOfIngredients"] ?? "";
            recipe.Steps = fullEntryList["Steps"] ?? "";
            recipe.IsFave = false;
            recipe.IsCustom = true;

            if (_recipeId == -1) // If recipe id still initial value, therefore no id passed
            {
                await _localDatabaseService.InsertRecipe(recipe);
            } else
            {
                await _localDatabaseService.UpdateRecipe(recipe); // Else id was passed, update recipe at id
            }
                
        }
    }


}
