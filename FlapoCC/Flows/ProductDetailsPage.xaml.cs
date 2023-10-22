using FlapoCC.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlapoCC.Flows
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailsPage : ContentPage
    {
        ProductDetailsViewModel viewModel;
        public ProductDetailsPage()
        {
            InitializeComponent();
            viewModel = new ProductDetailsViewModel();
            this.BindingContext = viewModel;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.InitializeAsync();
        }
    }
}