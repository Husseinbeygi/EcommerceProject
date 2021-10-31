using System.Collections.Generic;
using _0_Framework.Domin;
using ShopManagement.Domain.ProductPicureAggregation;

namespace ShopManagement.Domain.ProductAggregation
{
    public class Product : EntityBase
    {


        public void Edit(string name, string code, 
                string shortDescription, string description, string picture, string pictureAlt,
                string picutreTitle, string slug, string keywords, string metaDescription, long categoryId)
        {
            Name = name;
            Code = code;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PicutreTitle = picutreTitle;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CategoryId = categoryId;
        }

        public Product(string name, string code,
            string shortDescription, string description, string picture, string pictureAlt,
            string picutreTitle, string slug, string keywords, string metaDescription, long categoryId)
        {
            Name = name;
            Code = code;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PicutreTitle = picutreTitle;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CategoryId = categoryId;
        }

        public string Name { get; private set; }
        public string Code { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PicutreTitle { get; private set; }
        public string Slug { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public long CategoryId { get; private set; }
        public ProductCategory Category { get; private set; }

        public List<ProductPicture> ProductPictures { get; private set; }
    }
}
