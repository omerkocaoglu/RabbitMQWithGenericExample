using GenericRabbitMQApplication.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRabbitMQApplication.EntityService
{
    public class ProductService : IBaseService<Product>
    {
        List<Product> allProducts = new List<Product>();
        public List<Product> CreateEntity()
        {
            for (int i = 0; i < 10; i++)
            {
                Product product = new Product()
                {
                    Id = i + 1,
                    Name = "Product" + (i + 1),
                    Price = 100 + (i * 50),
                    ProductionDate = DateTime.Now.AddDays(-(i + 1))
                };
                allProducts.Add(product);
            }
            return allProducts;
        }
    }
}
