using GanbariGate.Models;

namespace GanbariGate.ViewModels
{
    public class DeckDetailViewModel : BaseViewModel
    {
        public Deck Deck { get; set; }
        public DeckDetailViewModel(Deck deck = null)
        {
            Title = deck?.Name;
            Deck = deck;
        }
    }
}