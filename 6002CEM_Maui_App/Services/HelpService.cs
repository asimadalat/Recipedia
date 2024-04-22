using _6002CEM_Maui_App.Interfaces;
using _6002CEM_Maui_App.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6002CEM_Maui_App.Services
{
    public class HelpService : IHelpService
    {
        public List<HelpModel> HelpList;

        public HelpService()
        {
            HelpList = new List<HelpModel>()
            {
                Initialize(0, "How many recipes are there?", "There are currently over fifteen recipes and we add more with each update so you'll have plenty to choose from!"),
                Initialize(1, "Can I add my own recipes?", "Of course! Simply tap the three horizontal lines in the top-left corner, navigate to 'Custom Recipes' and tap the plus icon in the top-right corner. Some fields are optional when adding a custom recipe."),
                Initialize(2, "Can I change my recipe?", "Recipes may be edited at any time by swiping left on them while on the custom recipes page, then tapping the first icon."),
                Initialize(3, "Can I remove my recipe?", "Recipes may be removed at any time by swiping left on them while on the custom recipes page, then tapping the second icon."),
                Initialize(4, "I want a specific recipe!", "Specific recipes can be found using the search function on the home page."),
                Initialize(5, "How many categories are there?", "There are currently seven categories. More categories may be added in future updates."),
                Initialize(6, "Can I put my custom recipe in a category?", "Yes! Category can be selected when creating or editing a custom recipe. Note the category field isn't required."),
                Initialize(7, "How do I save a recipe for later?", "Recipes can be saved by visiting their page and tapping the favourites icon. They can also be unsaved in the same manner.")
            /*Add categories to load in db here as above
                This file can take place of db but state wont save*/
            };
            InitializeDb();
        }

        public async Task InitializeDb()
        {
            LocalDatabaseService _localDatabaseService = new LocalDatabaseService();
            await _localDatabaseService.BulkCreateHelp(HelpList);
        }



        public HelpModel Initialize(int id, string question, string answer)
        {
            HelpModel help = new HelpModel();
            help.Id = id;
            help.Question = question;
            help.Answer = answer;
            return help;
        }
    }
}
