using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.MessagePatterns;
using Newtonsoft.Json;
using System.Threading;

namespace GenericRabbitMQApplication.Entity
{
    public class BaseConsumer<T> where T : class
    {
        byte[] data;
        List<string> jsonStringList = new List<string>();
        List<T> entityList = new List<T>();
        ConnectionFactory factory;
        IConnection connection;
        IModel channel;
        string queueName = string.Empty;
        string jsonString = string.Empty;
        public BaseConsumer(string queueValue)
        {
            this.queueName = queueValue.ToLower() + "_queue";
            jsonStringList = new List<string>();
            entityList = new List<T>();
            factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
        }
        public void Consume()
        {
            channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
            Subscription subscription = new Subscription(channel, queueName, false);
            while (true)
            {
                data = new byte[1024];
                BasicDeliverEventArgs basicDelivery = subscription.Next();
                data = basicDelivery.Body;
                subscription.Ack(basicDelivery);
                jsonString = ASCIIEncoding.Default.GetString(data);
                object deserializedObject = JsonConvert.DeserializeObject(ASCIIEncoding.Default.GetString(data));
                T entity = JsonConvert.DeserializeObject<T>(deserializedObject.ToString());
                jsonStringList.Add(jsonString);
                entityList.Add(entity);
                OnDataReceived(entity);
                Thread.Sleep(10);
            }
        }

        public void OnDataReceived(T entity)
        {
            Console.WriteLine("Alınan entity sayısı : " + entityList.Count);
            Console.WriteLine("Alınan entity : " + entity.ToString());
        }
    }
}
