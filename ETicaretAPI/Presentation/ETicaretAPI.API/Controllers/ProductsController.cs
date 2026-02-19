using ETicaretAPI.Application.Abstraction;
using ETicaretAPI.Application.Repositories;
using ETİcaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
       
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public ProductsController(IProductReadRepository productReadRepository , IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        [HttpGet]
        public async Task Get()
        {
            //    await _productWriteRepository.AddRangeAsync(new()
            //    {
            //    new() { Name = "Product 1", Price = 100, Stock = 10 },
            //    new() { Name = "Product 2", Price = 200, Stock = 20 },
            //    new() { Name = "Product 3", Price = 300, Stock = 30 },
            //    new() { Name = "Product 4", Price = 400, Stock = 40 },
            //    new() { Name = "Product 5", Price = 500, Stock = 50 }
            //});
            //_productWriteRepository.SaveAsync();

            Product p = await _productReadRepository.GetByIdAsync("37688a31-98f4-4102-8055-2f0fff5a78ba");
            p.Name = "Telefon";
            await _productWriteRepository.SaveAsync(); //Scope sayesinde Read ve Write repository'leri aynı context'i kullanıyor.
            // O yüzden Read repository üzerinden aldığımız bir nesneyi Write repository üzerinden güncelleyebiliyoruz.
        }
        [HttpGet("{id}")]

        public async Task<IActionResult> Get (string id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id);    
            return Ok(product);
        }
    }
}
