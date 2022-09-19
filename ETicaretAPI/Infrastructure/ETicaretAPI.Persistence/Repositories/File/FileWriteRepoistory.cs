using System;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Persistence.Contexts;

namespace ETicaretAPI.Persistence.Repositories
{
    public class FileWriteRepoistory : WriteRepository<ETicaretAPI.Domain.Entites.File>, IFileWriteRepository
    {
        public FileWriteRepoistory(ETicaretAPIDbContext eTicaretAPIDbContext) : base(eTicaretAPIDbContext)
        {
        }
    }
}

