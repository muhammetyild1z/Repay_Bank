using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repay_Bank.BusinessLayer.Abstract
{
    public interface IGenericService<T>where T : class
    {
        void TInsert(T entity);
        void TDelete(T entity);
        void TUpdate(T entity, T unchanged);
        Task<T> TGetByIDAsync(int id);
        Task<List<T>> TGetListAsync();
    }
}
