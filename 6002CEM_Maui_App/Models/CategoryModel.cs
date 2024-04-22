using SQLite;

namespace _6002CEM_Maui_App.Models
{
    [Table("category")]
    public class CategoryModel
    {
        // Define recipe parameters
        [PrimaryKey]
        [AutoIncrement]
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("image")]
        public string Image { get; set; }

        [Column("recipe_count")]
        public int RecipeCount { get; set; }

        public CategoryModel()
        {

        }
    }
}
