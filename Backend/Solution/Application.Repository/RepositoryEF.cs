using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class RepositoryEF<T> : IRepositoryEF<T> where T : class
    {
        protected readonly DbContext _context;
        public RepositoryEF(DbContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(T entity)
        {
            _context.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<int> Insert(T entity)
        {
            _context.Add(entity);
            return await _context.SaveChangesAsync();
        }
        public async Task<bool> Update(T entity)
        {
            _context.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
