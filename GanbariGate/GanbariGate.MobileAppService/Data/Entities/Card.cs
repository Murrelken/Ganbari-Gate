namespace GanbariGate.MobileAppService.Data.Entities
{
    public class Card : BaseEntity
    {
        // For EF Core
        protected Card()
        {
        }

        public Card(string visibleSide, string hiddenSide, Deck deck)
        {
            VisibleSide = visibleSide;
            HiddenSide = hiddenSide;
            Deck = deck;
        }

        public string VisibleSide { get; set; }
        
        public string HiddenSide { get; set; }
        
        public long DeckId { get; set; }
        
        public virtual Deck Deck { get; set; }
    }
}