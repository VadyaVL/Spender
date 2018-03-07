using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace Spender.Models
{
    [Table("Category")]
    public class Category
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string Title { get; set; }

        [OneToMany]
        public ICollection<Job> Jobs { get; set; }
    }
}