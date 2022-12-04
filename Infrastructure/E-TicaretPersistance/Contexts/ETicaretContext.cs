using E_Ticaret.Domain.Entities;
using E_Ticaret.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TicaretPersistance.Contexts
{
    public class ETicaretContext : DbContext
    {
        public ETicaretContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // ChangeTracker :Entity üzerinde değişiklik yapılırsa yada yeni veri eklenirse yakalanmasını sağlar.
           var datas= ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added=>data.Entity.CreatedDate==DateTime.UtcNow,
                    EntityState.Modified=>data.Entity.UpdateddDate==DateTime.UtcNow,
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
