using Capgemini.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capgemini.Domain.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task <OrderDTO> AddOrder(OrderDTO pedido);
        Task<IEnumerable<OrderDTO>> GetOrderByTable(int table);
        Task<OrderDTO> GetOrderById(int id);
        Task<IEnumerable<OrderDTO>> GetAllOrders();

    }
}
