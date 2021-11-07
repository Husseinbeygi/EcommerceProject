using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace _0_Framework.Application
{
    public class FileExtentionLimitaion : ValidationAttribute,IClientModelValidator
    {
        private string[] _fileExtention;

        public FileExtentionLimitaion(string[] fileExtention)
        {
            _fileExtention = fileExtention;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("FileExtentionLimitation", ErrorMessage);
        }

        public override bool IsValid(object? value) {
            var file = value as IFormFile;
            if (file == null) return false;
            return _fileExtention.Contains(Path.GetExtension(file.FileName));
        }
    }
}
