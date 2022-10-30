using E_Ticaret.Application.Repositories;
using E_Ticaret.Domain.Entities.Common;
using E_TicaretPersistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_TicaretPersistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ETicaretContext _context;
        public ReadRepository(ETicaretContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll()
           => Table;
        public Task<T> GetByIdAsync(string id)
            => Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
        => Table.Where(method);

        public async Task<T> SingleAsync(Expression<Func<T, bool>> method)
        => await Table.FirstOrDefaultAsync(method);
    }
}
