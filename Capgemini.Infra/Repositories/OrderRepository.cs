using Capgemini.Domain.DTOs;
using Capgemini.Domain.Entities;
using Capgemini.Domain.Interfaces.Repositories;
using Capgemini.Domain.UnitOfWork;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Capgemini.Infra.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OrderDTO> AddOrder(OrderDTO pedido)
        {
            var query = $@"INSERT INTO restaurantecapegmini.order 
                                  (
                            tableNumber,
                            idFood,
                            orderTime,
                            SteakDone,
                            quantity,
                            TotalPrice,
                            idWaiter,
                            closeOrder)
                            VALUES
                            (
                            @TableNumber,
                            @idFood,
                            CURRENT_TIMESTAMP(),
                            @SteakDone,
                            @quantity,
                            @TotalPrice,
                            @idWaiter,
                            CURRENT_TIMESTAMP()); 
";
            await _unitOfWork.Connection.ExecuteAsync(query,new 
            { 
                tableNumber= pedido.TableNumber,
                idFood = pedido.IdFood,
                SteakDone = pedido.SteakDone,
                quantity = pedido.Quantity,
                TotalPrice = pedido.TotalPrice,
                idWaiter = pedido.IdWaiter,
            },
                commandType: CommandType.Text, transaction: _unitOfWork.Transaction);
            return pedido;

        }

        public async Task<IEnumerable<OrderDTO>> GetAllOrders()
        {
            var result = await _unitOfWork.Connection.QueryAsync<OrderDTO>($@"
                SELECT * FROM restaurantecapegmini.order;"
                 , commandType: CommandType.Text, transaction: _unitOfWork.Transaction);

            return result; ;
        }

        public async Task<OrderDTO> GetOrderById(int id)
        {
            var result = await _unitOfWork.Connection.QueryFirstOrDefaultAsync<OrderDTO>($@"
                SELECT * FROM restaurantecapegmini.order where Id = @id;"
               , new
               {
                   id
               }
                , commandType: CommandType.Text, transaction: _unitOfWork.Transaction);

            return result;
        }

        public async Task<IEnumerable<OrderDTO>> GetOrderByTable(int tableNumber)
        {
            var result = await _unitOfWork.Connection.QueryAsync<OrderDTO>($@"
                SELECT * FROM restaurantecapegmini.order where tableNumber = @tableNumber;"
               , new
               {
                   tableNumber
               }
                , commandType: CommandType.Text, transaction: _unitOfWork.Transaction);

            return result;
        }
    }
}
