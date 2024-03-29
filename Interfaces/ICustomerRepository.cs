using Agreeya.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agreeya.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomerAsync();
        void AddCustomer(Customer customer);
        void UpdateCustomer(int id, Customer customer);
        void DeleteCustomer(int customerId);
        Task<Customer> FindCustomer(int id);
    }
}
