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
        public ReadRepository(ETicaretAPIDbContext context, bool tracking = true)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>(); //hangi entity kullanıyorsak onun tablosunu verir.

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking) //tracking yoksa yani değişiklik yapmayacaksak, performans için asNoTracking kullanırız.
                query = query.AsNoTracking();

            return query;
        }
        
           
      

        public async Task<T> GetByIdAsync(string id, bool tracking = true) {


            // =>await  Table.FirstOrDefaultAsync(data=>data.Id==Guid.Parse(id)); //Eğer async fonkksiyon varsa hoca async kullandı,  mesela where ina sync i yok.
            // => await Table.FindAsync(Guid.Parse(id)); //FindAsync metodu, primary key ile arama yapar. Bu yüzden daha performanslıdır.

            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }
        
            
        

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }
        
          
        
    }
}
