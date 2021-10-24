using _0_Framework.Domin;

namespace ShopManagement.Domain.ProductAggregation
{
    public class Product : EntityBase
    {

        public void InStock()
        {
            IsInStock = true;
        }

        public void OutOfStock()
        {
            IsInStock = false;
        }

        public void Edit(string name, string code, double unitPrice,
                string shortDescription, string description, string picture, string pictureAlt,
                string picutreTitle, string slug, string keywords, string metaDescription, long caegoryId)
        {
            Name = name;
            Code = code;
            UnitPrice = unitPrice;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PicutreTitle = picutreTitle;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CaegoryId = caegoryId;
        }

        public Product(string name, string code, double unitPrice,
            string shortDescription, string description, string picture, string pictureAlt,
            string picutreTitle, string slug, string keywords, string metaDescription, long caegoryId)
        {
            Name = name;
            Code = code;
            UnitPrice = unitPrice;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PicutreTitle = picutreTitle;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CaegoryId = caegoryId;
        }

        public string Name { get; private set; }
        public string Code { get; private set; }
        public double UnitPrice { get; private set; }
        public bool IsInStock { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PicutreTitle { get; private set; }
        public string Slug { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public long CaegoryId { get; private set; }
        public ProductCategory Category { get; private set; }
    }
}
