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
     
        public Card(string frontSide, string hiddenSide, long deckId)
        {
            FrontSide = frontSide;
            HiddenSide = hiddenSide;
            DeckId = deckId;
        }

        public string FrontSide { get; set; }
        
        public string HiddenSide { get; set; }
        
        [ForeignKey(typeof(Deck))]
        public long DeckId { get; set; }
    }
}