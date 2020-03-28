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

        // For EF Core
        public Card(string visibleSide, string hiddenSide, Deck deck)
        {
            VisibleSide = visibleSide;
            HiddenSide = hiddenSide;
            Deck = deck;
        }

        public string VisibleSide { get; set; }
        
        public string HiddenSide { get; set; }
        
        [ForeignKey(typeof(Deck))]
        public long DeckId { get; set; }
        
        public virtual Deck Deck { get; set; }
    }
}