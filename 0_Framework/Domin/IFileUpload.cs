using Microsoft.AspNetCore.Http;

namespace _0_Framework.Domin
{
    public interface IFileUploads
    {
        string Upload(IFormFile file,string FilePath);

    }
}
