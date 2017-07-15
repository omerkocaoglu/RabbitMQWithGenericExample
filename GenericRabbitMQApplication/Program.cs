using GenericRabbitMQApplication.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using GenericRabbitMQApplication.EntityService;
using System.Threading;

namespace GenericRabbitMQApplication
{
    class Program
    {
        public static void Main(string[] args)
        {

            if (args.Length > 0)
            {
                if (args[0] == "creating")
                {
                    while (true)
                    {
                        Start start = new Start();
                        Thread threadCreateEntity = new Thread(start.CreatingEntity);
                        threadCreateEntity.Start();
                        Console.WriteLine("Entitiler kuyruğa gönderildi...");
                        Console.Write("Yeni bir gönderim yapmak istiyor musunuz? EVET (E) / HAYIR (H)");
                        string selection = Console.ReadLine();
                        if (selection.ToLower() == "h")
                        {
                            Environment.Exit(0);
                        }

                    }

                }
                else
                {
                    if (args[0] == "product")
                    {
                        BaseConsumer<Product> productConsumer = new BaseConsumer<Product>(args[0]);
                        Thread threadProductConsumer = new Thread(productConsumer.Consume);
                        threadProductConsumer.Start();
                    }
                    else if (args[0] == "supplier")
                    {
                        BaseConsumer<Supplier> supplierConsumer = new BaseConsumer<Supplier>(args[0]);
                        Thread threadSupplierConsumer = new Thread(supplierConsumer.Consume);
                        threadSupplierConsumer.Start();
                    }
                }
            }
        }
    }
}
