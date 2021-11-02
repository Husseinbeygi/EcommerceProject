using System.Collections.Generic;

namespace _01_Queries.ProductCategories.Contract
{
    public class ProductCategoryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Slug { get; set; }
       public  List<ProductQueryModel> Products { get; set; }

    }
}
