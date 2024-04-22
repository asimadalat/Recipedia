using Microsoft.Extensions.Logging;
using _6002CEM_Maui_App.Views;
using _6002CEM_Maui_App.Services;
using _6002CEM_Maui_App.Interfaces;
using _6002CEM_Maui_App.ViewModels;

namespace _6002CEM_Maui_App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    // Add fonts
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Cocogoose Pro SemiLight Trial.ttf", "CocogooseProSemiLight");
                    fonts.AddFont("SweetSensationsPersonalUse-lRgq.ttf", "SweetSensations");
                });


#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<PageViewModel>(); // Parent and main vm/pages defined globally
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddSingleton<CategoriesPage>();
            builder.Services.AddSingleton<CategoriesPageViewModel>();
            builder.Services.AddSingleton<ListPageViewModel>();
            builder.Services.AddSingleton<FavouritesPage>();
            builder.Services.AddSingleton<FavouritesPageViewModel>();
            builder.Services.AddSingleton<LocalDatabaseService>();

            builder.Services.AddTransient<RecipePage>(); // Pages that require navigation defined dynamically
            builder.Services.AddTransient<RecipePageViewModel>();
            builder.Services.AddTransient<ListPage>();
            builder.Services.AddTransient<CustomListPage>();
            builder.Services.AddTransient<CustomListPageViewModel>();
            builder.Services.AddTransient<HelpPage>();
            builder.Services.AddTransient<HelpPageViewModel>();
            builder.Services.AddTransient<SettingsPage>();
            builder.Services.AddTransient<SettingsPageViewModel>();
            builder.Services.AddTransient<RecipeCreatePage>();
            builder.Services.AddTransient<RecipeCreatePageViewModel>();

            //builder.Services.AddScoped<IRecipeService, RecipeService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ILocalDatabaseService, LocalDatabaseService>();
            return builder.Build();
        }
    }
}
