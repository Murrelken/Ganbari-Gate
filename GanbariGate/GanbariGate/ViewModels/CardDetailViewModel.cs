using GanbariGate.Models;

namespace GanbariGate.ViewModels
{
    public class CardDetailViewModel : BaseViewModel
    {
        public Card Card { get; set; }
        public CardDetailViewModel(Card card = null)
        {
            Title = card?.VisibleSide;
            Card = card;
        }
    }
}