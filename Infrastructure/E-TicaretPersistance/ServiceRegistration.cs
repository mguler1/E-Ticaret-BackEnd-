using Microsoft.EntityFrameworkCore;
using E_TicaretPersistance.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Ticaret.Application.Repositories;
using E_TicaretPersistance.Repositories;

namespace E_TicaretPersistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ETicaretContext>(options => options.UseSqlServer(@"server=.;database=ECommerce;integrated security=true;"));

            services.AddScoped<ICustomerReadRepository,CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository,CustomerWriteRepository>();

            services.AddScoped<IOrderWriteRepository,OrderWriteRepository>();
            services.AddScoped<IOrderReadRepository,OrderReadRepository>();

            services.AddScoped<IProductReadRepository,ProductReadRepository>();
            services.AddScoped<IProductWriteRepository,ProductWriteRepository>();
        }
    }

}
