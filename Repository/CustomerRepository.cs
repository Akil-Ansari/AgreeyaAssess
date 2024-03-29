using Agreeya.Data;
using Agreeya.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agreeya.Crypto;


namespace Agreeya.Repository
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly ApplicationDBContext dc;

        public CustomerRepository(ApplicationDBContext _dc)
        {
            this.dc = _dc;
        }
        public void AddCustomer(Customer customer)
        {
            customer.Password = AesOperation.EncryptString(customer.Password);
            customer.Email = AesOperation.EncryptString(customer.Email);
            customer.PhoneNumber = AesOperation.EncryptString(customer.PhoneNumber);
            dc.Customer.Add(customer);
        }

        public void DeleteCustomer(int customerId)
        {
            var customer = dc.Customer.Find(customerId);
            dc.Customer.Remove(customer);
        }

        public async Task<Customer> FindCustomer(int id)
        {
            return await dc.Customer.FindAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetCustomerAsync()
        {
            List<Customer> customer = new List<Customer>();
            foreach (var item in await dc.Customer.ToListAsync())
            {
                item.Password = AesOperation.DecryptString(item.Password);
                item.Email = AesOperation.DecryptString(item.Email);
                item.PhoneNumber = AesOperation.DecryptString(item.PhoneNumber);
                customer.Add(item);
            }
            return customer.ToList();
        }

        public void UpdateCustomer(int id, Customer customer)
        {
            var data = dc.Customer.Find(id);
            if (data != null)
            {
                data.FirstName = customer.FirstName;
                data.LastName = customer.LastName;
                data.Password = AesOperation.EncryptString(customer.Password);
                data.LoginUser = customer.LoginUser;
                data.Email = AesOperation.EncryptString(customer.Email);
                data.PhoneNumber = AesOperation.EncryptString(customer.PhoneNumber);
            }
        }
    }
}
