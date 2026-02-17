using ETİcaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    public interface IWriteRepository<T> :IRepository<T> where T : BaseEntity
    {
       Task<bool>AddAsync(T model); //Veri ekleme işlemi yaparken kullanacağız.
       Task<bool>AddRangeAsync(List<T> datas);
       Task<bool> RemoveAsync(string id); //Veri silme işlemi yaparken kullanacağız.
       public bool Remove(T model);
       public bool RemoveRange(List<T> datas);
       public bool UpdateAsync(T model);

        Task<int> SaveAsync(); //Değişiklikleri veritabanına kaydetmek için kullanacağız.

    }
}
