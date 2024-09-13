using OrderManagement.Application.Interface;
using OrderManagement.Application.Repositiry;
using OrderManagement.Application.ResquestModel;
using OrderManagement.Data.Model;

namespace OrderManagement.Application.Services
{
    public class OrderService : IOrder
    {
        private readonly IGenericRepository<Customer> _customer;
        private readonly IGenericRepository<Order> _order;

        public OrderService(IGenericRepository<Customer> customer, IGenericRepository<Order> order)
        {
            _customer = customer;
            _order = order;
        }
        public ResponseModel AddOrder(OrderRequestModel order)
        {
            if (order == null)
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    Message = OrderManagementConstant.commonMessage.BedRequest,
                    Data = null
                };
            }

            var errors = Validate(order);
            if (errors.Any())
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    Message = OrderManagementConstant.commonMessage.Failed,
                    Data = null,
                    Errors = errors
                };
            }

            if (order.IsDiscountApplicable)
            {
                order.Amount = CalculateDiscount(order.Amount);
            }

            _order.Add(new Order() 
            {
                Id = 0,
                CustomerId= order.CustomerId,
                Amount = order.Amount,
                Date = order.Date
            });

            return new ResponseModel()
            {
                IsSuccess = true,
                Message = OrderManagementConstant.orderValidationMesage.OrderCreated,
                Data = null,
                Errors = null
            };
        }

        public ResponseModel DeleteOrders(int id)
        {
            var order = _order.GetById(id);
            if (order == null)
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    Message = OrderManagementConstant.orderValidationMesage.OrderNotExists,
                    Data = null,
                    Errors = null
                };
            }

            _order.Delete(order);
            
            return new ResponseModel()
            {
                IsSuccess = true,
                Message = OrderManagementConstant.orderValidationMesage.OrderDeleted,
                Data = null,
                Errors = null
            };
        }

        public ResponseModel GetOrderById(int id)
        {
            var order = _order.GetById(id);
            return new ResponseModel()
            {
                IsSuccess = true,
                Message = OrderManagementConstant.commonMessage.Success,
                Data = order,
                Errors = null
            };
        }

        public ResponseModel GetOrders()
        {
            var orders = _order.GetAll();
            return new ResponseModel()
            {
                IsSuccess = true,
                Message = OrderManagementConstant.commonMessage.Success,
                Data = orders,
                Errors = null
            };
        }

        public ResponseModel UpdateOrder(OrderRequestModel order)
        {
            var dataToUpdate= _order.GetById(order.Id);
            if (dataToUpdate == null)
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    Message = OrderManagementConstant.orderValidationMesage.OrdernotExists,
                    Data = null,
                    Errors = null
                };
            }

            dataToUpdate.Amount = order.Amount;
            if (order.IsDiscountApplicable)
            {
                dataToUpdate.Amount = CalculateDiscount(order.Amount);
            }

            _order.Update(dataToUpdate);
            return new ResponseModel()
            {
                IsSuccess = true,
                Message = OrderManagementConstant.orderValidationMesage.OrderUpdated,
                Data = null,
                Errors = null
            };
        }

        private bool IsCustomerExists(int customertId)
        {
            var customer = _customer.Select(x => x.Id == customertId);
            return customer != null;
        }

        private List<string> Validate(OrderRequestModel order)
        {
            var errors = new List<string>();
            if (!IsCustomerExists(order.CustomerId))
            {
                errors.Add(OrderManagementConstant.CustomerValidationMesage.CustomerNotExists);
            }

            if (order.Amount <= 0)
            {
                errors.Add(OrderManagementConstant.orderValidationMesage.InvalidOrderAmount);
            }
            return errors;
        }

        private decimal CalculateDiscount(decimal amount)
        {
            return amount - ((amount * 10) / 100);
        }
    }
}
