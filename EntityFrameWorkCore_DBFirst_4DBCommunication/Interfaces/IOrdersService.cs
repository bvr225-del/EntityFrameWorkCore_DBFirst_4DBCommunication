using EntityFrameWorkCore_DBFirst_4DBCommunication.Dtos;

namespace EntityFrameWorkCore_DBFirst_4DBCommunication.Interfaces
{
    public interface IOrdersService
    {
        Task<List<OrderDto>> GetOrders();
        Task<OrderDto> GetOrderById(int orderid);
        Task<int> AddOrder(OrderDto orderdetail);
        Task<bool> DeleteOrderById(int orderid);
        Task<bool> UpdateOrder(OrderDto orderdetail);

    }
}
