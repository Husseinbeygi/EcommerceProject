using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;
using ShopManagement.Application.Contracts.Product;

namespace ShopManagement.Application.Contracts.ProductPicture
{
    public class CreateProductPicture
    {
        [Range(1,int.MaxValue, ErrorMessage = Messages.IsRequired)]
        public long ProductId { get; set; }

        [Required(ErrorMessage = Messages.IsRequired)]
        public string Picture { get; set; }

        [Required(ErrorMessage = Messages.IsRequired)]
        public string PictureAlt { get; set; }

        [Required(ErrorMessage = Messages.IsRequired)]
        public string PictureTitle { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }

}
