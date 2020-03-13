using SQLite;

namespace GanbariGate.Models
{
    public abstract class BaseEntity
    {
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }
    }
}