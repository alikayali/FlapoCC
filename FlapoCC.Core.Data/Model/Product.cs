using System.Collections.Generic;

namespace FlapoCC.Core.Data.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string Name { get; set; }
        public List<Article> Articles { get; set; }
        public string DescriptionText { get; set; }
    }
}
