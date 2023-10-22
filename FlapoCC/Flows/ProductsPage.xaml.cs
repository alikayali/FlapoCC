using FlapoCC.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlapoCC.Flows
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsPage : ContentPage
    {
        ProductsViewModel viewModel;
        public ProductsPage()
        {
            InitializeComponent();
            viewModel = new ProductsViewModel();
            this.BindingContext = viewModel;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.InitializeAsync();
        }
    }
}