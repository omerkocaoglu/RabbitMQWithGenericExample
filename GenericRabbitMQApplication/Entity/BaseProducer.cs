using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using Newtonsoft.Json;

namespace GenericRabbitMQApplication.Entity
{
    public class BaseProducer<T> where T : class
    {
        string jsonString = string.Empty;
        byte[] data;
        ConnectionFactory factory;
        IConnection connection;
        IModel channel;
        string queueName = string.Empty;
        public BaseProducer(string queueName)
        {
            this.queueName = queueName;
            factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        public void SendQueue(List<T> Entity)
        {
            foreach (var item in Entity)
            {
                data = new byte[1024];
                jsonString = JsonConvert.SerializeObject(item);
                data = ASCIIEncoding.Default.GetBytes(jsonString);
                channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: data);
            }      
        }
    }
}
