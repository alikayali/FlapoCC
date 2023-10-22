namespace FlapoCC.Core.Data.Model
{
    public class Article
    {
        public int Id { get; set; }
        public string ShortDescription { get; set; }
        public double Price { get; set; }
        public string Unit { get; set; }
        public string PricePerUnitText { get; set; }
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the Name associated with the article.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the brand name associated with the article.
        /// </summary>
        public string BrandName { get; set; }
        /// <summary>
        /// Gets or sets the description text associated with the article.
        /// </summary>
        public string DescriptionText { get; set; }
        
    }
}
