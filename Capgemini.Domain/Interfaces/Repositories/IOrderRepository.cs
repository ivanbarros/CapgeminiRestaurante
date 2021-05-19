using Capgemini.Domain.DTOs;
using Capgemini.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
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
