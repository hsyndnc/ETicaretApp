using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Persistance.Contexts;
using ETİcaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistance.Repositories
{
    public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository //Hem soyutlama hem de ıoc de kullanmak için interface ekledik
    {
        public CustomerWriteRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
