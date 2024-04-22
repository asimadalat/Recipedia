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

namespace _6002CEM_Maui_App.ViewModels
{
    public partial class CategoriesPageViewModel : PageViewModel
    {
        private readonly ICategoryService _categoryService;
        private readonly ILocalDatabaseService _localDatabaseService;

        private ObservableCollection<CategoryModel> _categories;
        public ObservableCollection<CategoryModel> Categories
        {
            get { return _categories; }
            set
            {
                if (_categories != value)
                {
                    _categories = value;
                    OnPropertyChanged(nameof(Categories));
                }
            }
        }

        public CategoriesPageViewModel(ILocalDatabaseService localDatabaseService)
        {
            _localDatabaseService = localDatabaseService;
            _categoryService = new CategoryService();
            updateCategories();
        }

        public async void updateCategories()
        {
            // Get all categories from local db, convert to observablecollection 
            Categories = new ObservableCollection<CategoryModel>(await _localDatabaseService.GetCategories());
        }

        // List page vm uses category param to display recipes in a category
        [RelayCommand]
        async Task Tap(string category)
        {
            await Shell.Current.GoToAsync($"{nameof(ListPage)}?category={category}");
        }
    }
}
