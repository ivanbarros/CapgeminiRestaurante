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
                foreach (var item in foods.Foods)
                {

                var food = await _foodService.GetFoodByName(item.Name);
                foods.IdFood = food.Id;
                foods.TotalPrice = food.Price * item.Quantity;
                foods.Quantity = item.Quantity;
                foods.OrderTime = DateTime.UtcNow;
                foods.CloseOrder = null;
                foods.SteakDone = item.SteakDone.ToString();
                    switch (food.Type)

                    {
                        case "frito":
                            {
                            RabbitMqSenderToChannel.RabbitMqSenderToChannels($"{item.Name}, mesa: {foods.TableNumber} quantidade: {item.Quantity}", food.Type);
                                await Task.FromResult($"{item.Name} Enviado para o setor de  Fritas");
                                break;
                            }


                        case "grelhado":
                            {
                                RabbitMqSenderToChannel.RabbitMqSenderToChannels($"{item.Name}, {item.TypeFood}, mesa: {foods.TableNumber} quantidade: {item.Quantity}", food.Type);
                                await Task.FromResult($"{item.Name} Enviado para o setor de Grill");
                                break;
                            }
                        case "salada":
                            {
                                RabbitMqSenderToChannel.RabbitMqSenderToChannels($"{item.Name}, mesa: {foods.TableNumber} quantidade: {item.Quantity}", food.Type);
                                await Task.FromResult($"{item.Name} Enviado para o setor de  Fritas");
                            break;
                        }
                        case "bebida":
                            {
                                RabbitMqSenderToChannel.RabbitMqSenderToChannels($"{item.Name}, mesa: {foods.TableNumber} quantidade: {item.Quantity}", food.Type);
                                await Task.FromResult($"{item.Name} Enviado para o setor de  Bebidas");
                            break;
                        }
                        case "desert":
                            {
                                RabbitMqSenderToChannel.RabbitMqSenderToChannels($"{item.Name}, mesa: {foods.TableNumber} quantidade: {item.Quantity}", food.Type);
                                await Task.FromResult($"{item.Name} Enviado para o setor de  Fritas");
                            break;
                        }
                    
                }
                await _repository.AddOrder(foods);
                }

            }
            catch (Exception ex)
            {

                await Task.FromResult($"{ex.Message}");
            }
            return foods;
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
