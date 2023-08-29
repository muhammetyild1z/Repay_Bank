using Repay_Bank.DataAccessLayer.Abstract;
using Repay_Bank.DataAccessLayer.Concrete;
using Repay_Bank.DataAccessLayer.Repositories;
using Repay_Bank.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repay_Bank.DataAccessLayer.EntityFramwork
{
    public class efCustomerAccountProcessDal : GenericRepository<CustomerAccountProcess>, ICustomerAccountProcessDAL
    {
        public efCustomerAccountProcessDal(Context context) : base(context)
        {
        }
    }
}
