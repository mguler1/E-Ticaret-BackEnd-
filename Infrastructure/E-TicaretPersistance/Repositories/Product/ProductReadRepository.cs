using E_Ticaret.Application.Repositories;
using E_Ticaret.Domain.Entities;
using E_TicaretPersistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TicaretPersistance.Repositories
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(ETicaretContext context) : base(context)
        {
        }
    }
}
