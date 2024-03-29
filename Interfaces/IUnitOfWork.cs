using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agreeya.Interfaces
{
    public interface IUnitOfWork
    {
        ICustomerRepository CustomerRepository { get; }

        Task<bool> SaveAsync();
    }
}
