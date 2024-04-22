using _6002CEM_Maui_App.Models;

namespace _6002CEM_Maui_App.Interfaces
{
    public interface ILocalDatabaseService
    {
        // Get all recipes from db
        Task<List<RecipeModel>> GetRecipes();

        // Get all categories from db
        Task<List<CategoryModel>> GetCategories();

        // Get all help questions from db
        Task<List<HelpModel>> GetHelpQuestions();

        // Get single recipe by id from db
        Task<RecipeModel> GetById(int id);

        // Get recipes by category from db
        Task<List<RecipeModel>> GetByCategory(string cat);

        // Get recipes by name search from db
        Task<List<RecipeModel>> GetSearchRecipes(string squery);

        // Get all favourited recipes
        Task<List<RecipeModel>> GetAllFave();

        // Update favourite status of recipe
        Task SetFave(RecipeModel recipe);

        // Get all custom recipes
        Task<List<RecipeModel>> GetAllCustom(bool custom);

        // Insert one recipe, for custom recipes
        Task InsertRecipe(RecipeModel model);

        // Update a custom recipe
        Task UpdateRecipe(RecipeModel model);

        // Delete a custom recipe
        Task DeleteRecipe(int id);

        // Insert mutiple recipes on initial startup
        Task BulkCreateRecipes(List<RecipeModel> models);

        // Insert categories on initial startup
        Task BulkCreateCategories(List<CategoryModel> models);

        // Insert help questions on initial startup
        Task BulkCreateHelp(List<HelpModel> models);
    }
}
