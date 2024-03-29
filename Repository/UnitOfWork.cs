using Agreeya.Data;
using Agreeya.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agreeya.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext dc;
        public UnitOfWork(ApplicationDBContext _dc)
        {
            this.dc = _dc;
        }
        public ICustomerRepository CustomerRepository => new CustomerRepository(dc);

        public async Task<bool> SaveAsync()
        {
            return await dc.SaveChangesAsync() > 0;
        }
    }
}
