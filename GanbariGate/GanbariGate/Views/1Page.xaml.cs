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
    public partial class FPage : ContentPage
    {
        public FPage()
        {
            InitializeComponent();
        }

        private void AddData(object sender, EventArgs e)
        {
            var db = new SQLiteConnection("SQLite.sql");
            db.CreateTable<TestDatabaseTable>();
            
            var newData = new TestDatabaseTable("New data 1");
            db.Insert(newData);
        }
    }
}