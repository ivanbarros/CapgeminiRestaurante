using Capgemini.Domain.DTOs;
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
            var query = $@"INSERT INTO foodOrders 
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
                            @orderTime,
                            @SteakDone,
                            @quantity,
                            @TotalPrice,
                            @idWaiter,
                            @closeOrder); 
";
            await _unitOfWork.Connection.ExecuteAsync(query,new 
            { 
                tableNumber= pedido.TableNumber,
                idFood = pedido.IdFood,
                orderTime = pedido.OrderTime,
                SteakDone = pedido.SteakDone,
                quantity = pedido.Quantity,
                TotalPrice = pedido.TotalPrice,
                idWaiter = pedido.IdWaiter,
                closeOrder = pedido.CloseOrder
            },
                commandType: CommandType.Text, transaction: _unitOfWork.Transaction);
            return pedido;

        }

        public async Task<IEnumerable<OrderDTO>> GetAllOrders()
        {
            var result = await _unitOfWork.Connection.QueryAsync<OrderDTO>($@"
                SELECT * FROM foodOrders;"
                 , commandType: CommandType.Text, transaction: _unitOfWork.Transaction);

            return result; ;
        }

        public async Task<OrderDTO> GetOrderById(int id)
        {
            var result = await _unitOfWork.Connection.QueryFirstOrDefaultAsync<OrderDTO>($@"
                SELECT * FROM foodOrders where Id = @id;"
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
                SELECT * FROM foodOrders where tableNumber = @tableNumber;"
               , new
               {
                   tableNumber
               }
                , commandType: CommandType.Text, transaction: _unitOfWork.Transaction);

            return result;
        }
    }
}
