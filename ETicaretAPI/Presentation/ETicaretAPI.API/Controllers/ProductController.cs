using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretAPI.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        public ProductController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }


        [HttpGet]
        public async Task Get()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {

                new() { Id = Guid.NewGuid(), Name = "Product1", CreatedDate = DateTime.UtcNow, Stock = 200, Price = 3000 },
                new() { Id = Guid.NewGuid(), Name = "Product2", CreatedDate = DateTime.UtcNow, Stock = 100, Price = 4000 },
                new() { Id = Guid.NewGuid(), Name = "Product3", CreatedDate = DateTime.UtcNow, Stock = 300, Price = 1000 },

            });
            await _productWriteRepository.SaveAsync();
        }
    }
}

