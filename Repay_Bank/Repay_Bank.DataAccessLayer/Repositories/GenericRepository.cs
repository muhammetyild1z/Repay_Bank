using Microsoft.EntityFrameworkCore;
using Repay_Bank.DataAccessLayer.Abstract;
using Repay_Bank.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repay_Bank.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDAL<T> where T : class
    {
        private readonly Context _context;

        public GenericRepository(Context context)
        {
            _context = context;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public async Task<T> GetByIDAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetListAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public void Insert(T entity)
        {
            _context.Set<T>().AddAsync(entity);
            _context.SaveChanges();
        }

        public void Update(T entity, T unchanged)
        {
           _context.Entry(unchanged).CurrentValues.SetValues(entity);
        }
    }
}
