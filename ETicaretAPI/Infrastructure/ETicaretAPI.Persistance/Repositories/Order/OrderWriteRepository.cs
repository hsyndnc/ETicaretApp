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
    public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(ETicaretAPIDbContext context) : base(context)
        {
            //Write repoositoryde oluştutduğumuz generic yapısı sayesinde Order entitysine özel bir şey yapmamıza gerek kalmaz. Sadece base classa contexti göndeririz.
            //Tüm methodlar base den gelir.
            //IOrderWriteRepository de herhangi bir method tanımlamadık. Tekrar tekrar aynı methodları yazmamıza gerek yok, Onun amacı soyutlama yapmak ,
            //ıoc de OrderWriteRepository yi istediğimiz yerde IOrderWriteRepository olarak kullanabilmek. IOrderWriteRepository yi istediğimiz yerde kullanabiliriz, bu sayede bağımlılıklarımızı soyutlamış oluruz.
        }
    }
}
