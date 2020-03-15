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
    public partial class CardsPage : ContentPage
    {
        CardsViewModel viewModel;

        public CardsPage(Deck deck)
        {
            BindingContext = viewModel = new CardsViewModel(deck);

            InitializeComponent();
        }

        private async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewCardPage(viewModel.Deck)));
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Card;
            if (item == null)
                return;

            await Navigation.PushAsync(new CardDetailPage(new CardDetailViewModel(item)));

            // Manually deselect item.
            CardsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Cards.Count == 0)
                viewModel.LoadCardsCommand.Execute(null);
        }
    }
}