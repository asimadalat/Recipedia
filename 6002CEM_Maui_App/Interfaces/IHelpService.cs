using _6002CEM_Maui_App.Models;

namespace _6002CEM_Maui_App.Interfaces
{
    public interface IHelpService
    {
        // Insert categories into sqlite database on initial startup
        Task InitializeDb();
    }
}
