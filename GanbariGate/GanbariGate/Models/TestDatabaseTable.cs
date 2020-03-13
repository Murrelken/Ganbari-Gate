using SQLite;

namespace GanbariGate.Models
{
    public class TestDatabaseTable : BaseEntity
    {
        public TestDatabaseTable()
        {
        }

        public TestDatabaseTable(string data)
        {
            Data = data;
        }

        public string Data { get; set; }
    }
}