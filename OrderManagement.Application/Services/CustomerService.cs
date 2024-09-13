using OrderManagement.Application.Interface;
using OrderManagement.Application.Repositiry;
using OrderManagement.Application.ResponseModels;
using OrderManagement.Application.ResquestModel;
using OrderManagement.Data.Model;

namespace OrderManagement.Application.Services
{
    public class CustomerService : ICustomer
    {
        private readonly IGenericRepository<Customer> _repository;

        public CustomerService(IGenericRepository<Customer> repository)
        {
            _repository = repository;
        }
        public ResponseModel AddCustomer(CustomerRequestModel customer)
        {
            if (customer == null)
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    Message = OrderManagementConstant.commonMessage.BedRequest,
                    Data = null
                };
            }

            var errors = Validate(customer);
            if (errors.Any())
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    Message = OrderManagementConstant.commonMessage.Failed,
                    Data = errors
                };
            }

            _repository.Add(new Customer()
            {
                Id = 0,
                Name = customer.Name,
                Email = customer.Email,
            });

            return new ResponseModel()
            {
                IsSuccess = true,
                Message = OrderManagementConstant.commonMessage.Success,
                Data = null
            };
        }

        public ResponseModel DeleteCustomer(int id)
        {
            var customer = _repository.GetById(id);
            if (customer == null)
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    Message = OrderManagementConstant.CustomerValidationMesage.CustomerNotExists,
                    Data = id
                };
            }

            _repository.Delete(customer);

            return new ResponseModel()
            {
                IsSuccess = true,
                Message = OrderManagementConstant.CustomerValidationMesage.CustomerDeleteSuccess,
                Data = customer.Id
            };
        }

        public ResponseModel GetCustomer()
        {
            var dataToReturn = _repository.GetAll().Select(x => new CustomerResponseModel()
            { 
                Id =x.Id,
                Name = x.Name,
                Email = x.Email
            }).ToList();

            return new ResponseModel
            {
                IsSuccess = true,
                Message = OrderManagementConstant.commonMessage.Success,
                Data = dataToReturn
            };
        }

        public ResponseModel GetCustomerById(int id)
        {
            return new ResponseModel()
            {
                IsSuccess = true,
                Message = OrderManagementConstant.commonMessage.Success,
                Data = _repository.GetById(id)
            };
        }

        public ResponseModel UpdateCustomer(CustomerRequestModel customer)
        {
            if (customer == null)
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    Message = OrderManagementConstant.commonMessage.BedRequest,
                    Data = null
                };
            }
            var errors = Validate(customer);
            if (errors.Any())
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    Message = OrderManagementConstant.commonMessage.Failed,
                    Data = errors
                };
            }

            _repository.Update(new Customer()
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
            });

            return new ResponseModel()
            {
                IsSuccess = true,
                Message = OrderManagementConstant.commonMessage.Success,
                Data = customer
            };
        }

        private List<string> Validate(CustomerRequestModel customer)
        {
            var errors = new List<string>();
            if (string.IsNullOrWhiteSpace(customer.Name))
                errors.Add(OrderManagementConstant.CustomerValidationMesage.CustomerNameIsMust);

            if (string.IsNullOrWhiteSpace(customer.Email))
                errors.Add(OrderManagementConstant.EmailValidationMessage.EmailCanNotBeBlank);

            if (!OrderManagementHelper.IsValidEmail(customer.Email))
                errors.Add(OrderManagementConstant.EmailValidationMessage.InvalidEmail);

            if (IsEmailExists (customer.Email))
                errors.Add(OrderManagementConstant.EmailValidationMessage.EmailExists);

            return errors;
        }

        private bool IsEmailExists(string email)
        {
            return (_repository.Select(x => x.Email == email)?.Email ?? null) != null;
        }
    }
}
