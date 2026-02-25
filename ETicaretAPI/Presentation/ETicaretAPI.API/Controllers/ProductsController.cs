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
       private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly ICustomerWriteRepository _customerWriteRepository;
        IOrderReadRepository _orderReadRepository;

        public ProductsController(IProductReadRepository productReadRepository , IProductWriteRepository productWriteRepository, ICustomerWriteRepository customerWriteRepository, IOrderWriteRepository orderWriteRepository, IOrderReadRepository orderReadRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _customerWriteRepository = customerWriteRepository;
            _orderWriteRepository = orderWriteRepository;
            _orderReadRepository = orderReadRepository;
        }

        [HttpGet]
        public async Task Get()
        {
            Order order = await _orderReadRepository.GetByIdAsync("a3f75d59-3267-46dc-bb62-48cce90d5c53");
            order.Adress = "İstanbul";



            await _orderWriteRepository.SaveAsync();

        }

        



        [HttpGet("{id}")]

        public async Task<IActionResult> Get (string id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id);    
            return Ok(product);
        }
    }
}
