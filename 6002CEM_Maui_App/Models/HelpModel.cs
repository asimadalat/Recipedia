using SQLite;

namespace _6002CEM_Maui_App.Models
{
    [Table("help")]
    public class HelpModel
    {
        // Define recipe parameters
        [PrimaryKey]
        [AutoIncrement]
        [Column("id")]
        public int Id { get; set; }

        [Column("question")]
        public string Question { get; set; }

        [Column("answer")]
        public string Answer { get; set; }

        public HelpModel()
        {

        }
    }
}