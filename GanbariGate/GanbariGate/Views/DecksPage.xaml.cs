using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GanbariGate.Models;
using GanbariGate.Services;
using GanbariGate.ViewModels;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GanbariGate.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DecksPage
    {
        DecksViewModel viewModel;

        public DecksPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new DecksViewModel();
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewDeckPage()));
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
    }
}