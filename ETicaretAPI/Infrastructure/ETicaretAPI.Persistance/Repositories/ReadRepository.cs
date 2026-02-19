using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Persistance.Contexts;
using ETİcaretAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {

        private readonly ETicaretAPIDbContext _context;
        public ReadRepository(ETicaretAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>(); //hangi entity kullanıyorsak onun tablosunu verir.

        public IQueryable<T> GetAll()
        
            =>Table; 
        

        public async Task<T> GetByIdAsync(string id)
            =>await  Table.FirstOrDefaultAsync(data=>data.Id==Guid.Parse(id)); //Eğer async fonkksiyon varsa hoca async kullandı,  mesela where ina sync i yok.

     
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
        
            => await Table.FirstOrDefaultAsync(method);
        

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
        
            =>Table.Where(method); 
        
    }
}
