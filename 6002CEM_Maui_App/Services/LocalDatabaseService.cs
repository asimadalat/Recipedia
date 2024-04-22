using SQLite;
using _6002CEM_Maui_App.Models;
using _6002CEM_Maui_App.Interfaces;
using System.Diagnostics;

namespace _6002CEM_Maui_App.Services
{
    public class LocalDatabaseService : ILocalDatabaseService
    {
        private const string databaseName = "recipedia.db";
        private readonly SQLiteAsyncConnection _connection;

        public LocalDatabaseService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, databaseName));
            _connection.CreateTableAsync<RecipeModel>();
            _connection.CreateTableAsync<CategoryModel>();
        }

        public async Task<List<RecipeModel>> GetRecipes()
        {
            return await _connection.Table<RecipeModel>().ToListAsync();
        }

        public async Task<List<CategoryModel>> GetCategories()
        {
            return await _connection.Table<CategoryModel>().ToListAsync();
        }

        public async Task<List<HelpModel>> GetHelpQuestions()
        {
            return await _connection.Table<HelpModel>().ToListAsync();
        }


        public async Task<RecipeModel> GetById(int id)
        {
            return await _connection.Table<RecipeModel>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<RecipeModel>> GetByCategory(string category)
        {
            return await _connection.Table<RecipeModel>().Where(x => x.Category == category).ToListAsync();
        }

        public async Task<List<RecipeModel>> GetSearchRecipes(string squery)
        {
            return await _connection.Table<RecipeModel>().Where(x => x.Title.ToUpper().Contains(squery.ToUpper())).ToListAsync();
        }


        public async Task<List<RecipeModel>> GetAllFave()
        {
            return await _connection.Table<RecipeModel>().Where(x => x.IsFave == true).ToListAsync();
        }
        public async Task SetFave(RecipeModel recipe)
        {
            await _connection.UpdateAsync(recipe);
        }

        public async Task<List<RecipeModel>> GetAllCustom(bool custom)
        {
            return await _connection.Table<RecipeModel>().Where(x => x.IsCustom == custom).ToListAsync();
        }

        public async Task InsertRecipe(RecipeModel model)
        {
            await _connection.InsertAsync(model);
        }

        public async Task UpdateRecipe(RecipeModel recipe)
        {
            await _connection.UpdateAsync(recipe);
            Debug.WriteLine("RECIPE UPDATED!!!!!!!!!!");
        }

        public async Task DeleteRecipe(int id)
        {
            await _connection.DeleteAsync<RecipeModel>(id);
        }

        public async Task BulkCreateRecipes(List<RecipeModel> models)
        {
            await _connection.CreateTableAsync<RecipeModel>();
            var count = await _connection.Table<RecipeModel>().CountAsync();
            if (count == 0)
            {
                await _connection.InsertAllAsync(models);
            }
        }

        public async Task BulkCreateCategories(List<CategoryModel> models)
        {
            await _connection.CreateTableAsync<CategoryModel>();
            var count = await _connection.Table<CategoryModel>().CountAsync();
            if (count == 0)
            {
                await _connection.InsertAllAsync(models);
            }
        }

        public async Task BulkCreateHelp(List<HelpModel> models)
        {
            await _connection.CreateTableAsync<HelpModel>();
            var count = await _connection.Table<HelpModel>().CountAsync();
            if (count == 0)
            {
                await _connection.InsertAllAsync(models);
            }
        }

    }
}
