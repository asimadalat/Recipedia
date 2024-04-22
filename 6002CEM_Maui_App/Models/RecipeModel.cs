using SQLite;

namespace _6002CEM_Maui_App.Models
{
    [Table("recipe")]
    public class RecipeModel
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

        [Column("preparation_time")]
        public TimeSpan PreparationTime { get; set; }

        [Column("cooking_time")]
        public TimeSpan CookingTime { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("ingredients")]
        public string Ingredients { get; set; }

        [Column("number_of_ingredients")]
        public string NumberOfIngredients { get; set; }

        [Column("steps")]
        public string Steps { get; set; }

        [Column("is_favourite")]
        public bool IsFave { get; set; }

        [Column("is_custom")]
        public bool IsCustom { get; set; }

        [Column("category")]
        public string Category { get; set; }

        public RecipeModel()
        {
        }
    }
}
