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
    public partial class DeckDetailPage : ContentPage
    {
        DeckDetailViewModel viewModel;

        public DeckDetailPage(DeckDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public DeckDetailPage()
        {
            InitializeComponent();

            var item = new Deck("This is a fake element");

            viewModel = new DeckDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}