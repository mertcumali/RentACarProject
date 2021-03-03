using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile image)
        {
            string directory = Environment.CurrentDirectory + @"\wwwroot\";
            string fileName = CreateNewFileName(image.FileName);

            string path = Path.Combine(directory, "Images");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                image.CopyTo(stream);
            }

            string filePath = Path.Combine(path, fileName);
            return filePath;
        }

        public static string CreateNewFileName(string fileName)
        {
            string[] file = fileName.Split('.');
            string extension = file[1];
            string newFileName = string.Format(@"{0}." + extension, Guid.NewGuid());
            return newFileName;
        }

        public static void Delete(string path)
        {
            File.Delete(path);
        }
    }
}
