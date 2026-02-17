using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : class
    {
        //Sorgu ile read işlemleri yaparken burayı kullanıyoruz. 

        IQueryable<T> GetAll(); //Hangi emtity kullanıyorsak , tüm örneklerini getirecek.
        IQueryable<T> GetWhere(Expression<Func<T, bool>> merhod);  //şarta bağlı olarak getirecek.

        Task<T> GetSingleAsync(Expression<Func<T, bool>> method); //şarta bağlı tek bir örneği getirecek.

        Task<T> GetByIdAsync(int id);

    }
}
