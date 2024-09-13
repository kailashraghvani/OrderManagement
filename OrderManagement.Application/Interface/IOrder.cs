using OrderManagement.Application.ResquestModel;

namespace OrderManagement.Application.Interface
{
    public interface IOrder
    {
        ResponseModel GetOrders();
        ResponseModel GetOrderById(int id);
        ResponseModel AddOrder(OrderRequestModel order);
        ResponseModel UpdateOrder(OrderRequestModel order);
        ResponseModel DeleteOrders(int id);
    }
}
