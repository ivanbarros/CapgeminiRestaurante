using Capgemini.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capgemini.Domain.Interfaces.Services
{
    public interface IWaiterService
    {
        Task<IEnumerable<WaiterDTO>> GetAllWaiters();
        Task<WaiterDTO> AddWaiters(WaiterDTO waiter);
    }
}
