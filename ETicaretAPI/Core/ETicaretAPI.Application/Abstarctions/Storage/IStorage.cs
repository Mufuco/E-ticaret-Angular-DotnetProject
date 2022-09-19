using System;
using Microsoft.AspNetCore.Http;

namespace ETicaretAPI.Application.Abstarctions.Storage
{
    public interface IStorage
    {
        Task<List<(string fileName, string pathOrContainer)>> UploadAsync(string pathOrContainer, IFormFileCollection files);
        Task DeleteAsync(string pathOrContainer,string fileName);
        List<string> getFiles(string pathOrContainer);
        bool HasFile(string pathOrContainer, string fileName);
    }
}

