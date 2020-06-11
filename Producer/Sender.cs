using RabbitMQ.Client;
using System;
using System.Text;

namespace Producer
{
    public class Sender
    {
       public  static void Main(string[] args)
        {
            var factory = new ConnectionFactory(){HostName="localhost",};
            //Create Connection 
            using (var connection = factory.CreateConnection())
            //Create Channel
            using (var channel=connection.CreateModel() )
            {
                channel.QueueDeclare("BasicTest", false, false, false, null);

                string message = "Getting Started with .Net Core Rabbit MQ";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("","BasicTest",null,body);
                Console.WriteLine("Send Message {0}",message);


               
            }
            Console.WriteLine("Press [enter] exit sender app...");
            Console.ReadLine();
        }
    }
}
