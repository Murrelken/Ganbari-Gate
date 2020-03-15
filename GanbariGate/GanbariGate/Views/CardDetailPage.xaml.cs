using GanbariGate.Models;
using GanbariGate.ViewModels;
using Xamarin.Forms.Xaml;

namespace GanbariGate.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CardDetailPage
    {
        CardDetailViewModel viewModel;

        public CardDetailPage(CardDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public CardDetailPage()
        {
            InitializeComponent();

            var fakeCard = new Card();

            viewModel = new CardDetailViewModel(fakeCard);
            BindingContext = viewModel;
        }
    }
}