using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace RabbitMQEvalSend
{
    class NewTask
    {
        //public static void Main(string[] args)
        //{
        //    var factory = new ConnectionFactory() { HostName = "localhost" };
        //    using (var connection = factory.CreateConnection())
        //    using (var channel = connection.CreateModel())
        //    {
        //        channel.QueueDeclare(queue: "task_queue",
        //                             durable: true,
        //                             exclusive: false,
        //                             autoDelete: false,
        //                             arguments: null);
        //        var properties = channel.CreateBasicProperties();
        //        properties.SetPersistent(true);

        //        for (var i = 0; i < 10; i++)
        //        {
        //            var text = String.Format("Message Numero {0}", i);
        //            var message = GetMessage(args, text);
        //            var body = Encoding.UTF8.GetBytes(message);
        //            GenerateQueueItems(args, channel, properties, body, message);
        //        }


        //    }

        //    Console.WriteLine(" Press [enter] to exit.");
        //    Console.ReadLine();
        //}

        private static void GenerateQueueItems(string[] args, IModel channel, IBasicProperties properties, byte[] body, string message)
        {
            channel.BasicPublish(exchange: "",
                                 routingKey: "task_queue",
                                 basicProperties: properties,
                                 body: body);
            Console.WriteLine(" [x] Sent {0}", message);
        }

        private static string GetMessage(string[] args, string message)
        {
            return ((args.Length > 0) ? string.Join(" ", args) : message);
        }
    }
}
