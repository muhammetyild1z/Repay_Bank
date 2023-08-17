using Repay_Bank.BusinessLayer.Abstract;
using Repay_Bank.DataAccessLayer.Abstract;
using Repay_Bank.DataAccessLayer.Concrete;
using Repay_Bank.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repay_Bank.BusinessLayer.Concrate
{
    
    public class CustomerAccountManager : ICustomerAccountService
    {
        private readonly ICustomerAccountDAL _ICustomerAccountDAL;

        public CustomerAccountManager(ICustomerAccountDAL ıCustomerAccountDAL)
        {
            _ICustomerAccountDAL = ıCustomerAccountDAL;
        }

        public void TDelete(CustomerAccount entity)
        {
            _ICustomerAccountDAL.Delete(entity);
        }

        public Task<CustomerAccount> TGetByIDAsync(int id)
        {
           return _ICustomerAccountDAL.GetByIDAsync(id);
        }

        public Task<List<CustomerAccount>> TGetListAsync()
        {
           return _ICustomerAccountDAL.GetListAsync();
        }

        public void TInsert(CustomerAccount entity)
        {
            _ICustomerAccountDAL.Insert(entity);
        }

        public void TUpdate(CustomerAccount entity, CustomerAccount unchanged)
        {
            _ICustomerAccountDAL.Update(entity, unchanged);
        }
    }
}
