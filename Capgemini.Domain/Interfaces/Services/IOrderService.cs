using Capgemini.Domain.DTOs;
using Capgemini.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capgemini.Domain.Interfaces.Services
{
    public interface IOrderService
    {
        Task<OrderDTO> GetOrderById(int id);
        Task <IEnumerable<OrderDTO>> GetAllOrder();
        Task<IEnumerable<OrderDTO>> GetOrderByTable(int table);
        Task<OrderDTO> AddOrders(OrderDTO foods);
    }
}
