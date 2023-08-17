using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repay_Bank.DataAccessLayer.Abstract
{
    public interface IGenericDAL<T> where T : class
    {
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity , T unchanged);
        Task<T> GetByIDAsync(int id);
        Task<List<T>> GetListAsync();
    }
}
