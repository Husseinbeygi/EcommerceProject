using _0_Framework.Domin;

namespace ShopManagement.Domain
{

    public class ProductCategory : EntityBase
    {
        public ProductCategory(string name, string description, string picture, string pictureAlt,
         string pictureTitle, string keyWords, string metaDiscription, string slug)
        {
            Name = name;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            KeyWords = keyWords;
            MetaDiscription = metaDiscription;
            Slug = slug;
        }

        public void Edit(string name, string description, string picture, string pictureAlt,
         string pictureTitle, string keyWords, string metaDiscription, string slug)
        {
            Name = name;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            KeyWords = keyWords;
            MetaDiscription = metaDiscription;
            Slug = slug;
        }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string KeyWords { get; private set; }
        public string MetaDiscription { get; private set; }
        public string Slug { get; private set; }


    }
}

