using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using GanbariGate.Models;
using GanbariGate.Services;
using GanbariGate.Views;
using Xamarin.Forms;

namespace GanbariGate.ViewModels
{
    public class DecksViewModel : BaseViewModel
    {
        public IDataStore<Deck> DataStore => DependencyService.Get<IDataStore<Deck>>();
        public ObservableCollection<Deck> Decks { get; set; }
        public Command LoadDecksCommand { get; set; }

        public DecksViewModel()
        {
            Title = "Browse";
            Decks = new ObservableCollection<Deck>();
            LoadDecksCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewDeckPage, Deck>(this, "AddDeck", async (obj, deck) =>
            {
                var newDeck = deck;
                Decks.Add(newDeck);
                await DataStore.AddItemAsync(newDeck);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Decks.Clear();
                var items = await DataStore.GetItemsAsync();
                foreach (var item in items)
                {
                    Decks.Add(item);
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