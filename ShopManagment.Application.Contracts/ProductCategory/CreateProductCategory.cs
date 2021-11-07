using System;
using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;
using Microsoft.AspNetCore.Http;

namespace ShopManagement.Application.Contracts.ProductCategory
{
    public class CreateProductCategory
    {
        [Required(ErrorMessage = Messages.IsRequired)]
        public string Name { get; set; }
        [Required(ErrorMessage = Messages.IsRequired)]
        public string Description { get; set; }
        [MaxFileSize(3 * 1024 * 1024, ErrorMessage = Messages.FailedOpration_MaxFileSize_3MB)]
        [FileExtentionLimitaion(new string[] { ".jpg", ".jpeg", ".png" },ErrorMessage =Messages.FailedOpration_FileExtention_Images)]
        public IFormFile Picture { get; set; }
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
