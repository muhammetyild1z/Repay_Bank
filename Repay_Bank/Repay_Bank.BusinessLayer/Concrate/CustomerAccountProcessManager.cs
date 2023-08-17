using Repay_Bank.BusinessLayer.Abstract;
using Repay_Bank.DataAccessLayer.Abstract;
using Repay_Bank.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repay_Bank.BusinessLayer.Concrate
{
    public class CustomerAccountProcessManager : ICustomerAccountProcessService
    {
        private readonly ICustomerAccountProcessDAL _ICustomerAccountProcessDAL;

        public CustomerAccountProcessManager(ICustomerAccountProcessDAL ıCustomerAccountProcessDAL)
        {
            _ICustomerAccountProcessDAL = ıCustomerAccountProcessDAL;
        }

        public void TDelete(CustomerAccountProcess entity)
        {
            _ICustomerAccountProcessDAL.Delete(entity);
        }

        public Task<CustomerAccountProcess> TGetByIDAsync(int id)
        {
           return _ICustomerAccountProcessDAL.GetByIDAsync(id);
        }

        public Task<List<CustomerAccountProcess>> TGetListAsync()
        {
           return _ICustomerAccountProcessDAL.GetListAsync();
        }

        public void TInsert(CustomerAccountProcess entity)
        {
            _ICustomerAccountProcessDAL.Insert(entity);
        }

        public void TUpdate(CustomerAccountProcess entity, CustomerAccountProcess unchanged)
        {
            _ICustomerAccountProcessDAL.Update(entity, unchanged);
        }
    }
}
