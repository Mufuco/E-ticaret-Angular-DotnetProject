using System;
using ETicaretAPI.Application.Abstarctions.Storage;
using Microsoft.AspNetCore.Http;

namespace ETicaretAPI.Infrastructure.Services.Storage
{
    public class StorageService:IStorageService
        
    {
        readonly IStorage _storage;

        

        public StorageService(IStorage storage)
        {
            _storage = storage;
        }

        public string StorageName { get => _storage.GetType().Name; }

        public Task DeleteAsync(string pathOrContainer, string fileName)
            => _storage.DeleteAsync(pathOrContainer, fileName);


        public List<string> getFiles(string pathOrContainer)
            => _storage.getFiles(pathOrContainer);


        public bool HasFile(string pathOrContainer, string fileName) =>
            _storage.HasFile(pathOrContainer, fileName);


        public Task<List<(string fileName, string pathOrContainer)>> UploadAsync(string pathOrContainer, IFormFileCollection files)
        => _storage.UploadAsync(pathOrContainer, files);
    }
}

