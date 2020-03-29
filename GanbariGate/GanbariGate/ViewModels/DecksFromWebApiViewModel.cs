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
    public class DecksFromWebApiViewModel : BaseViewModel
    {
        public DecksWebApiDataStore DataStore => DependencyService.Get<DecksWebApiDataStore>();
        public IDataStore<Deck> LocalDecksDataStore => DependencyService.Get<IDataStore<Deck>>();
        public ObservableCollection<Deck> Decks { get; set; }
        public Command LoadDecksCommand { get; set; }

        public DecksFromWebApiViewModel()
        {
            Title = "Decks from server";
            Decks = new ObservableCollection<Deck>();
            LoadDecksCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<DecksFromWebApiPage, Deck>(this, "DownloadDeck", async (obj, newDeck) =>
            {
                var deckToAdd = new Deck(newDeck.Name);
                await LocalDecksDataStore.AddItemAsync(deckToAdd);
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