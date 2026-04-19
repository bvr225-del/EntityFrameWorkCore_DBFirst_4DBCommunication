using EntityFrameWorkCore_DBFirst_4DBCommunication.Interfaces;
using EntityFrameWorkCore_DBFirst_4DBCommunication.MidlandModels;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWorkCore_DBFirst_4DBCommunication.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly MidlandContext _context;

        public OrdersRepository(MidlandContext context)
        {
            _context = context;
        }

        public async Task<int> AddOrder(Order orderdetail)
        {
            await _context.Orders.AddAsync(orderdetail);//add the record by using addasync
            _context.SaveChanges();//it will commit/save the data perminently in table
            return 1;
        }

        public async Task<bool> DeleteOrderById(int orderid)
        {
            var result = await _context.Orders.Where(a => a.Orderid == orderid).FirstOrDefaultAsync();
            if (result != null)
            {
                _context.Orders.Remove(result);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Order> GetOrderById(int orderid)
        {
            var rm = await _context.Orders.Where(e => e.Orderid == orderid).FirstOrDefaultAsync();

            if (rm == null)
                return null;
            else
                return rm;
        }

        public async Task<List<Order>> GetOrders()
        {
            var result = _context.Orders.ToList();
            if (result.Count == 0)
            {
                return null;
            }
            else
            {
                return result;
            }
        }

        public async Task<bool> UpdateOrder(Order orderdetail)
        {
            _context.Update(orderdetail);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
