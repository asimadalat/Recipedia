using _6002CEM_Maui_App.Interfaces;
using _6002CEM_Maui_App.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6002CEM_Maui_App.Services
{
    public class CategoryService : ICategoryService
    {
        public List<CategoryModel> CategoryList;

        public CategoryService()
        {
            CategoryList = new List<CategoryModel>()
            {
                Initialize(0, "thaicurrypreview.jpg", "Vegan", 3),
                Initialize(2, "chococakepreview.jpg", "Dessert", 14),
                Initialize(3, "sweetpotatosouppreview.jpg", "Quick Easy Meals", 8),
                Initialize(6, "fluffypancakespreview.jpg", "Breakfast", 12),
                Initialize(7, "saagaloopreview.jpg", "International Cuisine", 17),
                Initialize(9, "meatballtaginepreview.jpg", "High Protein", 4),
                Initialize(10, "fruitkebabspreview.jpg", "Healthy Snacks", 10)
            /*Add categories to load in db here as above
                This file can take place of db but state wont save*/
            };
            InitializeDb();
        }

        public async Task InitializeDb()
        {
            LocalDatabaseService _localDatabaseService = new LocalDatabaseService();
            await _localDatabaseService.BulkCreateCategories(CategoryList);
        }



        public CategoryModel Initialize(int id, string image, string title, int recipeCount)
        {
            CategoryModel category = new CategoryModel();
            category.Id = id;
            category.Image = image;
            category.Title = title;
            category.RecipeCount = recipeCount;
            return category;
        }
    }
}
