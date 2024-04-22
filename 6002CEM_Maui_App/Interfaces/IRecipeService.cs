using _6002CEM_Maui_App.Models;

namespace _6002CEM_Maui_App.Interfaces
{
    public interface IRecipeService
    {
        // Insert premade recipes into sqlite database on initial startup
        Task InitializeDb();
    }
}
