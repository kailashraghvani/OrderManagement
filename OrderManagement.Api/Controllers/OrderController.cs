using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application;
using OrderManagement.Application.Interface;
using OrderManagement.Application.ResquestModel;

namespace OrderManagement.Api.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrder _order;

        public OrderController(IOrder order)
        {
            _order = order;
        }
        
        [HttpGet]
        public ActionResult<ResponseModel> GetOrders() 
        {
            return Ok(_order.GetOrders());
        }

        [HttpPost]
        public ActionResult<ResponseModel> CreateOrder(OrderRequestModel order)
        {
            return Ok(_order.AddOrder(order));
        }

        [HttpPost]
        public ActionResult<ResponseModel> UpdateOrder(OrderRequestModel order)
        {
            return Ok(_order.UpdateOrder(order));
        }

        [HttpPost]
        public ActionResult<ResponseModel> DeleteOrder(int id)
        {
            return Ok(_order.DeleteOrders(id));
        }
    }
}
