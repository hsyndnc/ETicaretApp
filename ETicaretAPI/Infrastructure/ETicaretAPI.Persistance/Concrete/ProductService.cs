using ETicaretAPI.Application.Abstraction;
using ETİcaretAPI.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ETicaretAPI.Persistance.Concrete
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts()
            //Target type kullanımı
            => new()
            {

                new(){Id =Guid.NewGuid(), Name="Apple", Price=100, Stock=10}, 
                new(){Id =Guid.NewGuid(), Name="Grapes", Price=120, Stock=8}, 
                new() {Id =Guid.NewGuid(), Name = "Orange", Price = 80, Stock = 15},
                new(){ Id =Guid.NewGuid() ,Name="Banana", Price=50, Stock=20},
                new (){Id =Guid.NewGuid(), Name="Mango", Price=150, Stock=5}
            };
        
    }
}
