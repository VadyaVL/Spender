using SQLite;

namespace Spender.Models
{
    public abstract class IntIdent
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
    }
}