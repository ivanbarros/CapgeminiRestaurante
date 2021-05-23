using Capgemini.Domain.DTOs;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace Capgemini.Infra.RabbitMq
{
    public class RabbitMqSenderToChannel
    {
        public static void RabbitMqSenderToChannels(OrderDTO messages, string department) 
        {
            //string[] pedidos = { messages.Name,messages.OrderTime.ToString(), messages.SteakDone};
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: department,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var message = JsonConvert.SerializeObject(messages);
                var bytesMessage = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: department,
                                     basicProperties: null,
                                     body: bytesMessage);
            }

        }
    }
}
    

