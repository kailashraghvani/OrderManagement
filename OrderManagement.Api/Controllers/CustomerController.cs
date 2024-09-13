using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application;
using OrderManagement.Application.Interface;
using OrderManagement.Application.ResquestModel;

namespace OrderManagement.Api.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly ICustomer _customer;

        public CustomerController(ICustomer customer)
        {
            _customer = customer;
        }

        [HttpGet]
        public ActionResult<ResponseModel> GetCustomers()
        {
            return Ok(_customer.GetCustomer());
        }

        [HttpPost]
        public IActionResult CreateCustomer(CustomerRequestModel customer)
        {
            return Ok(_customer.AddCustomer(customer));
        }

        [HttpPost]
        public IActionResult UpdateCustomer(CustomerRequestModel customer)
        {
            return Ok(_customer.UpdateCustomer(customer));
        }

        [HttpPost]
        public IActionResult DeleteCustomer(int id)
        {
            return Ok(_customer.DeleteCustomer(id));
        }

        [HttpPost]
        public IActionResult GetByID(int id)
        {
            return Ok(_customer.GetCustomerById(id));
        }
    }
}
