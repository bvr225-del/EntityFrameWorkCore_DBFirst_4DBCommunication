using EntityFrameWorkCore_DBFirst_4DBCommunication.Dtos;
using EntityFrameWorkCore_DBFirst_4DBCommunication.Interfaces;
using EntityFrameWorkCore_DBFirst_4DBCommunication.MidlandModels;

namespace EntityFrameWorkCore_DBFirst_4DBCommunication.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;

        public OrdersService(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task<int> AddOrder(OrderDto orderdetail)
        {
            Order order = new Order();
            order.Orderid = orderdetail.Orderid;
            order.Ordername = orderdetail.Ordername;
            order.Orderlocation = orderdetail.Orderlocation;
            var res = await _ordersRepository.AddOrder(order);
            return res;
        }

        public async Task<bool> DeleteOrderById(int orderid)
        {
            await _ordersRepository.DeleteOrderById(orderid);
            return true;
        }

        public async Task<OrderDto> GetOrderById(int orderid)
        {
            var res = await _ordersRepository.GetOrderById(orderid);
            OrderDto orderdto = new OrderDto();
            orderdto.Orderid = res.Orderid;
            orderdto.Ordername = res.Ordername;
            orderdto.Orderlocation = res.Orderlocation;
            return orderdto;
        }

        public async Task<List<OrderDto>> GetOrders()
        {
            List<OrderDto> lstorderdto = new List<OrderDto>();
            var res = await _ordersRepository.GetOrders();
            foreach (Order order in res)
            {
                OrderDto ordersDto = new OrderDto();
                ordersDto.Orderid = order.Orderid;
                ordersDto.Ordername = order.Ordername;
                ordersDto.Orderlocation = order.Orderlocation;

                lstorderdto.Add(ordersDto);//Add the orders to list here

            }
            return lstorderdto;
        }

        public async Task<bool> UpdateOrder(OrderDto orderdetail)
        {
            Order obj = new Order();
            obj.Orderid = orderdetail.Orderid;
            obj.Ordername = orderdetail.Ordername;
            obj.Orderlocation = orderdetail.Orderlocation;
            await _ordersRepository.UpdateOrder(obj);
            return true;
        }
    }
}
