using GanbariGate.Models;
using GanbariGate.ViewModels;
using Xamarin.Forms.Xaml;

namespace GanbariGate.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeckDetailPage
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

            var fakeDeck = new Deck("This is a fake element");

            viewModel = new DeckDetailViewModel(fakeDeck);
            BindingContext = viewModel;
        }
    }
}