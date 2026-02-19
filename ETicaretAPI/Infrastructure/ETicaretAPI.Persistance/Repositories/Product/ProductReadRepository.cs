using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Persistance.Contexts;
using ETicaretAPI.Persistance.Repositories;
using ETİcaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories;

public class ProductReadRepository(ETicaretAPIDbContext context)
    : ReadRepository<Product>(context), IProductReadRepository
{
    
}