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
    public partial class DecksPage
    {
        public DecksPage()
        {
            InitializeComponent();
        }

        private void AddItem_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}