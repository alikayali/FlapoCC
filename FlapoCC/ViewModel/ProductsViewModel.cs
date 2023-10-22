using FlapoCC.Core.Constants;
using FlapoCC.Core.Data.Model;
using FlapoCC.Core.Extensions;
using FlapoCC.Core.Services;
using FlapoCC.Flows;
using FlapoCC.Resources.Localization;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace FlapoCC.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        private ProductService _productService;
        #region Commands
        public ICommand SortByPriceCommand => new Command(SortByPriceAsync);
        public ICommand SortByPricePerBottleCommand => new Command(SortByPricePerBottleAsync);
        public ICommand SortByPricePerLiterCommand => new Command(SortByPricePerLiterAsync);
        public ICommand SortByNumberOfBottlesCommand => new Command(SortByNumberOfBottlesAsync);
        public IAsyncCommand<Article> SelectProductCommand => new AsyncCommand<Article>(SelectProductAsync);
        #endregion
        
        ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }

        ObservableCollection<Article> _articles;
        public ObservableCollection<Article> Articles
        {
            get { return _articles; }
            set
            {
                _articles = value;
                OnPropertyChanged();
            }
        }

        public ProductsViewModel()
        {
            Title = AppResources.TitleProducts;
            _productService = new ProductService();
            
        }

        public override async Task InitializeAsync()
        {
            if (IsBusy)
            {
                return;
            }

            await IsBusyFor(
                async () =>
                {
                    // Get orders
                    await LoadProductsAsync();
                });
        }
        #region Private Methods
        private void SortByPriceAsync()
        {
            Articles = Articles.OrderBy(article => article.Price).ToObservableCollection();
        }
        private void SortByPricePerBottleAsync()
        {
            Articles = Articles.OrderBy(article =>
            {
                string shortDescription = article.ShortDescription;
                int indexOfX = shortDescription.IndexOf("x");
                if (indexOfX >= 0)
                {
                    string numberOfBottlesStr = shortDescription.Substring(0, indexOfX).Trim();
                    if (int.TryParse(numberOfBottlesStr, out int numberOfBottles))
                    {
                        if (numberOfBottles > 0)
                        {
                            
                            return article.Price / numberOfBottles;
                        }
                    }
                }
                return 0.0; // Standardwert, falls keine Anzahl gefunden wird
            }).ToObservableCollection();
        }
        private void SortByPricePerLiterAsync()
        {
            Articles = Articles.OrderBy(article =>
            {
                // Analysieren der "shortDescription" Zeichenfolge, um das Volumen in Litern zu extrahieren
                string shortDescription = article.ShortDescription;
                int indexOfLiter = shortDescription.IndexOf("Liter");
                if (indexOfLiter >= 0)
                {
                    string volumeInLitersStr = shortDescription.Substring(0, indexOfLiter).Trim();
                    if (double.TryParse(volumeInLitersStr, out double volumeInLiters))
                    {
                        // Jetzt haben Sie das Volumen in Litern (volumeInLiters)
                        if (volumeInLiters > 0)
                        {
                            // Verwenden Sie dies, um den Preis pro Liter zu berechnen
                            return article.Price / volumeInLiters;
                        }
                    }
                }
                return 0.0; // Standardwert, falls keine Literangabe gefunden wird
            }).ToObservableCollection();
        }
        private void SortByNumberOfBottlesAsync()
        {
            Articles = Articles.OrderBy(article =>
            {
                string shortDescription = article.ShortDescription;
                int indexOfX = shortDescription.IndexOf("x");
                if (indexOfX >= 0)
                {
                    string numberOfBottlesStr = shortDescription.Substring(0, indexOfX).Trim();
                    if (int.TryParse(numberOfBottlesStr, out int numberOfBottles))
                    {
                        if (numberOfBottles > 0)
                        {

                            return numberOfBottles;
                        }
                    }
                }
                return 0.0; // Standardwert, falls keine Anzahl gefunden wird
            }).ToObservableCollection();
        }
        private async Task SelectProductAsync(Article article)
        {
            if (article != null)
            {
                var viewModel = new ProductDetailsViewModel() { Article = article };
                var detailsPage = new ProductDetailsPage { BindingContext = viewModel };

                var navigation = Application.Current.MainPage as NavigationPage;
                await navigation.PushAsync(detailsPage, true);
            }
        }

        private async Task LoadProductsAsync()
        {
            
            List<Product> products = await _productService.GetProductsAsync(APIConstants.GetBeerData);

            if (products != null)
            {
                // die geladenen Produkte in deinem ViewModel verarbeiten
                Products = products.ToObservableCollection();
                Articles = Products.SelectMany(product => product.Articles, (product, article) =>
                {
                    article.Name = product.Name;
                    article.BrandName = product.BrandName;
                    article.DescriptionText = product.DescriptionText;
                    return article;
                }).ToList().ToObservableCollection();
              
            }
            else
            {
                // Handle den Fall, in dem das Laden der Produkte fehlgeschlagen ist
            }
        }
        #endregion
    }
}