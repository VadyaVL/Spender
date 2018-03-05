using SQLite;

namespace Spender.Models
{
    [Table("Category")]
    public class Category
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string Title { get; set; }
    }
}