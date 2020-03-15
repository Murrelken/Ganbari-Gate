using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GanbariGate.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GanbariGate.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewCardPage
    {
        public Card Card { get; set; }
        
        public NewCardPage(Deck deck)
        {
            InitializeComponent();

            Card = new Card("Visible", "Hidden", deck.Id);

            BindingContext = this;
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddCard", Card);
            await Navigation.PopModalAsync();
        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}