using SQLite;
using SQLiteNetExtensions.Attributes;
using System;

namespace Spender.Models
{
    [Table("Job")]
    public class Job : IntIdent
    {
        public DateTime Start { get; set; }

        public DateTime? End { get; set; }

        [ForeignKey(typeof(Category))]
        public int CategoryId { get; set; }

        [ManyToOne]
        public Category Category { get; set; }
    }
}