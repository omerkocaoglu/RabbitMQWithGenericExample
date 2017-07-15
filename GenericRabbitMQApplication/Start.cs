using GenericRabbitMQApplication.Entity;
using GenericRabbitMQApplication.EntityService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRabbitMQApplication
{
    public class Start
    {
        BaseProducer<Product> productProducer;
        BaseProducer<Supplier> supplierProducer;
        ProductService productService;
        SupplierService supplierService;
        public Start()
        {
            productProducer = new BaseProducer<Product>("product_queue");
            supplierProducer = new BaseProducer<Supplier>("supplier_queue");
            productService = new ProductService();
            supplierService = new SupplierService();
        }

        public void CreatingEntity()
        {
            productProducer.SendQueue(productService.CreateEntity());
            supplierProducer.SendQueue(supplierService.CreateEntity());
        }
    }
}
