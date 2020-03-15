using SQLite;
using SQLiteNetExtensions.Attributes;

namespace GanbariGate.Models
{
    [Table(nameof(Card))]
    public class Card : BaseEntity
    {
        public Card()
        {
        }
     
        public Card(string visibleSide, string hiddenSide, long deckId)
        {
            VisibleSide = visibleSide;
            HiddenSide = hiddenSide;
            DeckId = deckId;
        }

        public string VisibleSide { get; set; }
        
        public string HiddenSide { get; set; }
        
        [ForeignKey(typeof(Deck))]
        public long DeckId { get; set; }
    }
}