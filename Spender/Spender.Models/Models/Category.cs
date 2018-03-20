using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace Spender.Models
{
    [Table("Category")]
    public class Category : IntIdent
    {
        public string Title { get; set; }

        [OneToMany]
        public ICollection<Job> Jobs { get; set; }
    }
}