using OrderManagement.Application.ResquestModel;

namespace OrderManagement.Application.Interface
{
    public interface ICustomer
    {
        ResponseModel GetCustomer();
        ResponseModel GetCustomerById(int id);
        ResponseModel AddCustomer(CustomerRequestModel customer);
        ResponseModel UpdateCustomer(CustomerRequestModel customer);
        ResponseModel DeleteCustomer(int id);
    }
}
