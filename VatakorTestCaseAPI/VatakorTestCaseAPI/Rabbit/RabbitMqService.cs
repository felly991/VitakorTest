﻿using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace VatakorTestCaseAPI.Rabbit
{
    public class RabbitMqService : IRabbitMq
    {
        public void SendMessage(object obj)
        {
            var message = JsonSerializer.Serialize(obj);
            SendMessage(message);
        }

        public void SendMessage(string message)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "queue",
                               durable: false,
                               exclusive: false,
                               autoDelete: false,
                               arguments: null);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                               routingKey: "queue",
                               basicProperties: null,
                               body: body);
            }
        }
    }
}
