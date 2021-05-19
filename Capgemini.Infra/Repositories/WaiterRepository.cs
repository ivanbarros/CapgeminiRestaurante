using Capgemini.Domain.DTOs;
using Capgemini.Domain.Interfaces.Repositories;
using Capgemini.Domain.UnitOfWork;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Capgemini.Infra.Repositories
{
    public class WaiterRepository : IWaiterRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public WaiterRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<WaiterDTO> AddWaiters(WaiterDTO waiter)
        {
            await _unitOfWork.Connection.ExecuteAsync($@"INSERT INTO `testebd_`.`waiter`
                        (
                        `Name`)
                        VALUES
                        (
                        @Name
                        );", waiter
         , commandType: CommandType.Text, transaction: _unitOfWork.Transaction);
            return waiter;

        }

        public async Task<IEnumerable<WaiterDTO>> GetAllWaiters()
        {
            var result = await _unitOfWork.Connection.QueryAsync<WaiterDTO>($@"
                SELECT * FROM testebd_.waiter"
                , commandType: CommandType.Text, transaction: _unitOfWork.Transaction);

            return result;
        }
    }
}
