using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ShopManagement.Application.Contracts.Product
{
    public class CreateProduct
    {
        [Required(ErrorMessage = Messages.IsRequired)]
        public string Name { get;  set; }
        [Required(ErrorMessage = Messages.IsRequired)]
        public string Code { get;  set; }
        [Range(1, Int64.MaxValue, ErrorMessage = Messages.IsRequired)]
        public double UnitPrice { get;  set; }
        [Required(ErrorMessage = Messages.IsRequired)]
        public string ShortDescription { get;  set; }
        public string Description { get;  set; }
        public string Picture { get;  set; }
        public string PictureAlt { get;  set; }
        public string PicutreTitle { get;  set; }
        [Required(ErrorMessage = Messages.IsRequired)]
        public string Slug { get;  set; }
        [Required(ErrorMessage = Messages.IsRequired)]
        public string Keywords { get;  set; }
        [Required(ErrorMessage = Messages.IsRequired)]
        public string MetaDescription { get;  set; }
        
        [Range(1,100000,ErrorMessage = Messages.IsRequired)]
        public long CaegoryId { get;  set; }



        public List<ProductCategoryViewModel> Categories { get; set; }
    }
}
