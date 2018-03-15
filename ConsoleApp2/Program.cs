using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KafkaNet;
using KafkaNet.Model;
using KafkaNet.Protocol;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string topic = "IDGTestTopic";
            Uri uri = new Uri("http://192.168.1.17:9092");
            var options = new KafkaOptions(uri);
            var router = new BrokerRouter(options);
            var consumer = new Consumer(new ConsumerOptions(topic, router));
            foreach (var message in consumer.Consume())
            {
                Console.WriteLine(Encoding.UTF8.GetString(message.Value));
            }
            Console.ReadLine();
        }
    }
}
