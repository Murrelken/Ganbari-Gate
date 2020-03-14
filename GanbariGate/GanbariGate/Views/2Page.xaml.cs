using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GanbariGate.Models;
using GanbariGate.Services;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GanbariGate.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SPage : ContentPage
    {
        public SPage()
        {
            InitializeComponent();
        }

        private void ReceiveData(object sender, EventArgs e)
        {
            var db = DbContext.CreateConnection();
            db.CreateTable<TestDatabaseTable>();

            var allData = db.Table<TestDatabaseTable>().ToList();

            var data = allData.LastOrDefault() ?? new TestDatabaseTable("Empty...");
            MainLabel.Text = data.Data;

            // db.CreateTable<Deck>();
            // db.CreateTable<Card>();
            // var allDecks = db.Table<Deck>().ToList();
            // var allCards = db.Table<Card>().ToList();
            //
            // if (allDecks.FirstOrDefault(x => x.Name == "Deck #2") == null)
            // {
            //     var newDeck = new Deck("Deck #2");
            //     db.Insert(newDeck);
            //
            //     allDecks = db.Table<Deck>().ToList();
            // }
            //
            // var firstDeckId = allDecks.FirstOrDefault(x => x.Name == "Deck #1")?.Id;
            //
            // if (firstDeckId.HasValue && allCards.Count == 0)
            // {
            //     var firstCard = new Card("kashikoi", "smart", firstDeckId.Value);
            //     var secondCard = new Card("chitekina", "intellectual", firstDeckId.Value);
            //
            //     db.Insert(firstCard);
            //     db.Insert(secondCard);
            // }
            //
            // var newDecks = db.Table<Deck>().ToList();
            // var newCards = db.Table<Card>().ToList();
            //
            // var p = "";
        }
    }
}