using EntityFrameWorkCore_DBFirst_4DBCommunication.MidlandModels;

namespace EntityFrameWorkCore_DBFirst_4DBCommunication.Interfaces
{
    public interface IOrdersRepository
    {
        Task<List<Order>> GetOrders();
        Task<Order> GetOrderById(int orderid);
        Task<int> AddOrder(Order orderdetail);
        Task<bool> DeleteOrderById(int orderid);
        Task<bool> UpdateOrder(Order orderdetail);

    }
}
