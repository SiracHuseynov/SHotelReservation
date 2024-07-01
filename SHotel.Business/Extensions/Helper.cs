using Microsoft.AspNetCore.Http;
using SHotel.Business.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.Extensions
{
    public static class Helper
    {
        public static string SaveFile(string rootPath, string folder, IFormFile file)
        {
            if (file.ContentType != "image/png") 
                throw new FileContentTypeException("File formati png olmalidir!");

            if (file.Length > 10485760)
                throw new FileImageSizeException("File 10 mb ola biler!");

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            string path = rootPath + $@"\{folder}\" + fileName;

            using (FileStream fileStrean = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStrean);
            }

            return fileName;
        }

        public static void DeleteFile(string rootPath, string folder, string file)
        {
            string path = rootPath + $@"\{folder}\" + file;

            if (!File.Exists(path))
                throw new ImageFileNotFoundException("Image tapilmadi");

            File.Delete(path);
        }

    }
}
