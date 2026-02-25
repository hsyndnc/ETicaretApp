using ETİcaretAPI.Domain.Entities;
using ETİcaretAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistance.Contexts
{
    public  class ETicaretAPIDbContext :DbContext
    {
        public ETicaretAPIDbContext(DbContextOptions options) :base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) //Kullandığımız metodu bul, Hem parametreli hem de parametresiz olanı var.
        {
            //Change Tracker :Entityler üzerinden yapılan değişikliklerin ya da eklenen yeni bir entitynin yakalanmasını sağlayan bir mekanizmadır.
            //Track edilen verileri yakalayıp, o veriler üzerinde işlem yapmamızı sağlar. Mesela eklenen bir entity varsa onun CreatedDate'ini güncellemek gibi.

            var datas = ChangeTracker.Entries<BaseEntity>(); //BaseEntity'den kalıtım alan tüm entityleri yakala.

            foreach (var entity in datas)
            {
                var result = entity.State switch
                {
                    EntityState.Added => entity.Entity.CreateDate = DateTime.UtcNow, //Eğer eklenen bir entity varsa onun CreatedDate'ini güncelle.
                    EntityState.Modified => entity.Entity.UpdateDate = DateTime.UtcNow, //Eğer güncellenen bir entity varsa onun UpdatedDate'ini güncelle.
                    _ => DateTime.UtcNow
                };
            }
            //çalıştırılan savechanges metodu burayı rerikler burada tarihler eklenir ve tekrar savechanges çalıştırılır.
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
