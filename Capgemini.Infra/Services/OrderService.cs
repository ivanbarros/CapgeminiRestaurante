using Capgemini.Domain.DTOs;
using Capgemini.Domain.Interfaces.Repositories;
using Capgemini.Domain.Interfaces.Services;
using Capgemini.Infra.RabbitMq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capgemini.Infra.Services
{
    public class OrderService : IOrderService
    {
        private readonly IFoodService _foodService;
        private readonly IOrderRepository _repository;
        public OrderService(IFoodService foodService,IOrderRepository repository)
        {
            _foodService = foodService;
            _repository = repository;
        }

        public async Task<OrderDTO> AddOrders(OrderDTO foods)
        {
            try
            {
                var food = await _foodService.GetFoodByName(foods.Name);
                foods.IdFood = food.Id;
                foods.TotalPrice = food.Price * foods.Quantity;
                    
                    switch (food.Type)
                    {

                        case "frito":
                            {
                            RabbitMqSenderToChannel.RabbitMqSenderToChannels(foods, food.Type);
                                await Task.FromResult($"{foods.Name} Enviado para o setor de  Fritas");
                                break;
                            }


                        case "grelhado":
                            {
                            RabbitMqSenderToChannel.RabbitMqSenderToChannels(foods, food.Type);
                            await Task.FromResult($"{foods.Name} Enviado para o setor de Grill");
                                break;
                            }
                        case "salada":
                            {
                            RabbitMqSenderToChannel.RabbitMqSenderToChannels(foods, food.Type);
                            await Task.FromResult($"{foods.Name} Enviado para o setor de  Fritas");
                            break;
                        }
                        case "bebida":
                            {
                            RabbitMqSenderToChannel.RabbitMqSenderToChannels(foods, food.Type);
                            await Task.FromResult($"{foods.Name} Enviado para o setor de  Bebidas");
                            break;
                        }
                        case "desert":
                            {
                            RabbitMqSenderToChannel.RabbitMqSenderToChannels(foods, food.Type);
                            await Task.FromResult($"{foods.Name} Enviado para o setor de  Fritas");
                            break;
                        }
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
            return await _repository.AddOrder(foods);
        }

        public async Task<IEnumerable<OrderDTO>> GetAllOrder()
        {
           return await _repository.GetAllOrders();
        }

        public async Task<OrderDTO> GetOrderById(int id)
        {
           return await _repository.GetOrderById(id);
        }

        public async Task<IEnumerable<OrderDTO>> GetOrderByTable(int table)
        {
            return await _repository.GetOrderByTable(table);
        }
    }
}
