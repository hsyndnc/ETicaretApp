using ETicaretAPI.Application.Abstraction;
using ETicaretAPI.Application.Repositories;
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
        public void Get()
        {
            _productWriteRepository.AddRangeAsync(new()
                {
                new() { Name = "Product 1", Price = 100, Stock = 10 },
                new() { Name = "Product 2", Price = 200, Stock = 20 },
                new() { Name = "Product 3", Price = 300, Stock = 30 },
                new() { Name = "Product 4", Price = 400, Stock = 40 },
                new() { Name = "Product 5", Price = 500, Stock = 50 }
            });
            _productWriteRepository.SaveAsync();
        }
    }
}
