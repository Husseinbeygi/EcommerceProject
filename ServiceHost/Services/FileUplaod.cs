using System.IO;
using _0_Framework.Domin;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ServiceHost.Services
{
    public class FileUplaod : IFileUploads
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileUplaod(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string Upload(IFormFile file, string FilePath)
        {
            string _filepath = CheckDirectoryExistence(FilePath);
            using var output = File.Create($"{_filepath}//{file.FileName}");
            file.CopyTo(output);
            return $"{FilePath}/{file.FileName}";
        }

        private string CheckDirectoryExistence(string Filepath)
        {
            string _rootPath = $"{_webHostEnvironment.WebRootPath}//UploadedFiles//";
            if (!IsExits(_rootPath))
                CreateDirectory(_rootPath);

            if (!IsExits(_rootPath + Filepath))
            {
                CreateDirectory(_rootPath + Filepath);
            }

            return _rootPath + Filepath;
        }

        private bool IsExits(string path)
        {
            return Directory.Exists(path);
        }

        private void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }
    }
}
