using System;
using System.Text.RegularExpressions;
using ETicaretAPI.Application.Services;
using ETicaretAPI.Infrastructure.Operations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ETicaretAPI.Infrastructure.Services
{
    public class FileService : IFileServices
    {
        readonly IWebHostEnvironment _webHostEnvironment;
        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<bool> CopyFileAsync(string path, IFormFile file)
        {
            try
            {
               await using FileStream fileStream = new(path, FileMode.Create,
               FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);

                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<string> FileReNameAsync(string path,string fileName)
        {
            string lastFileName = await Task.Run<string>(async () =>
            {
                string tire = "-";
                string extension = Path.GetExtension(fileName);
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
                string firstFileName = NameOperation.CharacterRequlatory(fileNameWithoutExtension);

                // firstFineName elde edilirken tüm özel karakterler ve tüm boşluklar "-" 1 çizgi ile değiştirilir. 
                // Dosya adında birden fazla çizgi yan yana gelirse aşağıdaki döngü ile tek çizgiye dönüştürülürler.

                while (firstFileName.Contains("--"))
                {
                    firstFileName = firstFileName.Replace("--", tire);
                }

                // ismin sonunda 1 çizgi yoksa aşağıda ekleyelim. Arkasına unique olması için guid falan ekleyeceğiz.

                if (!firstFileName.EndsWith(tire))
                {
                    firstFileName = firstFileName + tire;
                }

                // aşağıda dosyamızın son adını oluşturacağız. dosya adının sonuna 1 çizgi ekledik.

                Guid guid = Guid.NewGuid();
                string lastFileName = $"{firstFileName}{DateTime.Now.Millisecond + tire}{guid}{extension}";

                // en son dosya adımızın ilk karakteri belki çizgi olabilir diye onu da kaldırmamız lazım. Aşağıda kaldırdık onu da.

                if (lastFileName.StartsWith(tire))
                {
                    lastFileName = lastFileName.Substring(1);
                }


                // dosyanın varlığını kontrol ettik. Bunu sırf metot await istediği için ekledim. Bu olmayınca hata veriyor. Burada çözüm bulamadım başka.

                if (File.Exists($"{path}\\{lastFileName}"))
                {
                    return await FileReNameAsync(path, lastFileName);
                }
                else
                {
                    return lastFileName;
                }
            });

            return lastFileName;
        }

        public async Task<List<(string fileName, string path)>> UploadAsync(string path, IFormFileCollection files)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            List<bool> results = new();
            List<(string fileName, string path)> datas = new();

            foreach (IFormFile file in files)
            {
                string fileNewName = await FileReNameAsync(uploadPath,file.FileName);     
                bool result =await CopyFileAsync($"{uploadPath}//{fileNewName}", file);
                datas.Add((fileNewName, $"{path}//{fileNewName}"));
                results.Add(result);

            }
            if (results.TrueForAll(r => r.Equals(true)))
            {
                return datas;
            }

            else
                return null;
            
        }
    }
}

