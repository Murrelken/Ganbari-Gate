using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GanbariGate.Models;
using GanbariGate.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GanbariGate.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DecksFromWebApiPage : ContentPage
    {
        DecksFromWebApiViewModel viewModel;

        public DecksFromWebApiPage()
        {
            BindingContext = viewModel = new DecksFromWebApiViewModel();

            InitializeComponent();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Deck;
            if (item == null)
                return;

            await Navigation.PushAsync(new DeckDetailPage(new DeckDetailViewModel(item)));

            // Manually deselect item.
            DecksListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Decks.Count == 0)
                viewModel.LoadDecksCommand.Execute(null);
        }
        
        public async void Download (object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var deck = mi.BindingContext as Deck;
            if(deck == null)
                return;
            
            MessagingCenter.Send(this, "DownloadDeck", deck);
        }
    }
}