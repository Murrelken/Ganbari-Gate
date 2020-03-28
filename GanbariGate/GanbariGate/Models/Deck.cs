using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace GanbariGate.Models
{
    [Table(nameof(Deck))]
    public class Deck : BaseEntity
    {
        //For SQLite
        public Deck()
        {
        }

        public Deck(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        
        public virtual IEnumerable<Card> Cards { get; set; }
    }
}