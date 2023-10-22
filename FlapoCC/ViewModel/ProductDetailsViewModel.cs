using FlapoCC.Core.Data.Model;
using FlapoCC.Resources.Localization;

namespace FlapoCC.ViewModels
{
    public class ProductDetailsViewModel : BaseViewModel
    {
        Article _article;
        public Article Article
        {
            get { return _article; }
            set
            {
                _article = value;
                OnPropertyChanged();
            }
        }

        public ProductDetailsViewModel()
        {
            Title = AppResources.TitleProductDetails;
        }
    }
}