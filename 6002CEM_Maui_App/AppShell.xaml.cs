using _6002CEM_Maui_App.Views;

namespace _6002CEM_Maui_App
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(RecipePage), typeof(RecipePage));
            Routing.RegisterRoute(nameof(ListPage), typeof(ListPage));
            Routing.RegisterRoute(nameof(RecipeCreatePage), typeof(RecipeCreatePage));
        }
    }
}
