using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GanbariGate.Models;
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
            var db = new SQLiteConnection("SQLite.sql");
            db.CreateTable<TestDatabaseTable>();

            var allData = db.Table<TestDatabaseTable>().ToList();

            var data = allData.LastOrDefault() ?? new TestDatabaseTable("Empty...");
            MainLabel.Text = data.Data;
        }
    }
}