using Capgemini.Domain.DTOs;
using Capgemini.Domain.Interfaces.Repositories;
using Capgemini.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capgemini.Infra.Services
{
    public class WaiterService : IWaiterService
    {
        private readonly IWaiterRepository _repository;

        public WaiterService(IWaiterRepository repository)
        {
            _repository = repository;
        }

        public Task<WaiterDTO> AddWaiters(WaiterDTO waiter)
        {
           return _repository.AddWaiters(waiter);
        }

        public async Task<IEnumerable<WaiterDTO>> GetAllWaiters()
        {
            var result =  await _repository.GetAllWaiters();
            return result;
        }
    }
}
