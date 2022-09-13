using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.RequestParameters;
using ETicaretAPI.Application.ViewModels.Products;
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
        readonly private IWebHostEnvironment _webHostEnvironment;

        public ProductController(
            IProductWriteRepository productWriteRepository,
            IProductReadRepository productReadRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            this._webHostEnvironment = webHostEnvironment;
            
        }


        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]Pagination pagination)
        {
            var totalCount = _productReadRepository.GetAll(false).Count();
           var products= _productReadRepository.GetAll(false).Skip(pagination.Page * pagination.Size).Take(pagination.Size).Select(p => new
            {
                p.Id,
                p.Name,
                p.Stock,
                p.Price,
                p.CreatedDate,
                p.UpdatedDate


            }).ToList();

            return Ok(new
            {
                totalCount,
                products
            });

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _productReadRepository.GetByIdAsync(id,false)); 
        }

        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Product model)
        {
            if (ModelState.IsValid)
            {

            }

           await _productWriteRepository.AddAsync(new()
            {
                Name=model.Name,
                Price=model.Price,
                Stock=model.Stock
            });
            await _productWriteRepository.SaveAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Product model)
        {
         Product product= await _productReadRepository.GetByIdAsync(model.Id);
            product.Stock = model.Stock;
            product.Price = model.Price;
            product.Name = model.Name;
            _productWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();

            return Ok();
        }
        [HttpPost("[Action]")]
        public async Task<IActionResult> Upload()
        {
                string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "resource/product-images");

                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                foreach (IFormFile file in Request.Form.Files)
                {
                    Guid guid = Guid.NewGuid();
                    string noExtension = Path.GetFileNameWithoutExtension(file.FileName).ToLower()
                        .Replace(" ", "-").Replace("ğ", "g").Replace("ı", "i").Replace("ö", "o")
                        .Replace("ü", "u").Replace("ş", "s").Replace("ç", "c").Replace("Ç", "c")
                        .Replace("Ş", "s").Replace("Ğ", "g").Replace("Ü", "u").Replace("İ", "i")
                        .Replace("Ö", "o").Trim();

                    string fullPath = Path.Combine(uploadPath, $"{noExtension + "-"}{guid}{Path.GetExtension(file.FileName)}");

                    using FileStream fileStream = new(fullPath, FileMode.Create, FileAccess.Write, FileShare.None, 1920 * 1920, useAsync: false);
                    await file.CopyToAsync(fileStream);
                    await fileStream.FlushAsync();
                }
                return Ok();
            
        }
    }

}


