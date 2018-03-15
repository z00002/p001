using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KafkaNet;
using KafkaNet.Model;
using KafkaNet.Protocol;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string payload = "welcome to kafka!";
            string topic = "IDGTestTopic";
            Message msg = new Message(payload);

            Uri uri = new Uri("http://192.168.1.17:9092");
            var options = new KafkaOptions(uri);

            var router = new BrokerRouter(options);
            var client = new Producer(router);

            client.SendMessageAsync(topic, new List<Message> { msg }).Wait();

            Console.ReadLine();
        }
    }
}
