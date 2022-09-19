using System;
namespace ETicaretAPI.Application.Abstarctions.Storage
{
    public interface IStorageService:IStorage
    {
        public string StorageName { get;}
    }
}

