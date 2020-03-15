using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GanbariGate.Models;
using GanbariGate.Services;
using GanbariGate.Views;
using Xamarin.Forms;

namespace GanbariGate.ViewModels
{
    public class CardsViewModel : BaseViewModel
    {
        public IDataStore<Card> DataStore => DependencyService.Get<IDataStore<Card>>();
        public ObservableCollection<Card> Cards { get; set; }
        public Command LoadCardsCommand { get; set; }
        public Deck Deck;

        public CardsViewModel(Deck deck)
        {
            Deck = deck;
            Title = $"Cards of {deck.Name}";
            Cards = new ObservableCollection<Card>();
            LoadCardsCommand = new Command(async () => await ExecuteLoadItemsCommand(deck.Id));

            MessagingCenter.Subscribe<NewCardPage, Card>(this, "AddCard", async (obj, newCard) =>
            {
                Cards.Add(newCard);
                await DataStore.AddItemAsync(newCard);
            });
        }

        async Task ExecuteLoadItemsCommand(long deckId)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Cards.Clear();
                var items = await DataStore.GetItemsByConditionAsync(x => x.DeckId == deckId);
                foreach (var item in items)
                {
                    Cards.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}