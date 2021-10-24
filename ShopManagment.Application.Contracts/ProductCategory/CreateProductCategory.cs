using System;
using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;

namespace ShopManagement.Application.Contracts.ProductCategory
{
    public class CreateProductCategory
    {
        [Required(ErrorMessage = Messages.IsRequired)]
        public string Name { get; set; }
        [Required(ErrorMessage = Messages.IsRequired)]
        public string Description { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        [Required(ErrorMessage = Messages.IsRequired)]
        public string KeyWords { get; set; }
        [Required(ErrorMessage = Messages.IsRequired)]
        public string MetaDescription { get; set; }
        [Required(ErrorMessage = Messages.IsRequired)]
        public string Slug { get; set; }

    }
}
