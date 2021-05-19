using Capgemini.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capgemini.Domain.Interfaces.Repositories
{
    public interface IWaiterRepository
    {
        Task<WaiterDTO> AddWaiters(WaiterDTO waiter);
        Task<IEnumerable<WaiterDTO>> GetAllWaiters();
    }
}
