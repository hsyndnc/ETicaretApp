using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    public interface IWriteRepository<T> :IRepository<T> where T : class
    {
       Task<bool>AddAsync(T model); //Veri ekleme işlemi yaparken kullanacağız.
       Task<bool>AddAsync(List<T> model);
       Task<bool>RemoveAsync(string id); //Veri silme işlemi yaparken kullanacağız.
       Task<bool>RemoveAsync(T model);
        Task<bool>UpdateAsync(T model);

    }
}
