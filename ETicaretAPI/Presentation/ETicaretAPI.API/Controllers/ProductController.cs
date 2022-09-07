using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entites;
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

        readonly private IOrderReadRepository _readRepository;

        public ProductController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IOrderReadRepository readRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _readRepository = readRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("merhaba");
        }
    }
}

