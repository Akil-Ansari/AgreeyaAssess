using Agreeya.Authentication;
using Agreeya.Data;
using Agreeya.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agreeya.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IUnitOfWork uow;

        public CustomerController(IUnitOfWork _uow)
        {
            this.uow = _uow;
        }

        [HttpGet("GetCustomers")]
        public async Task<IActionResult> GetCustomers()
        {
            var cityList = await uow.CustomerRepository.GetCustomerAsync();
            return Ok(cityList);
        }

        [HttpPost("addCustomer")]
        public async Task<IActionResult> addCustomer(Customer customer)
        {
            uow.CustomerRepository.AddCustomer(customer);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCity(int id, Customer customer)
        {
            uow.CustomerRepository.UpdateCustomer(id, customer);
            await uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DelCity(int id)
        {
            uow.CustomerRepository.DeleteCustomer(id);
            await uow.SaveAsync();
            return Ok(id);
        }
    }
}
