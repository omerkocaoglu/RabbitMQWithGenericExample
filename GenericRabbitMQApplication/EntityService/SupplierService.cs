using GenericRabbitMQApplication.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRabbitMQApplication.EntityService
{
    public class SupplierService : IBaseService<Supplier>
    {
        List<Supplier> allSuppliers = new List<Supplier>();
        string[] cities = new string[5] { "İzmir", "Amsterdam", "Dortmund", "Roma", "Prag" };
        string[] countries = new string[5] { "Türkiye", "Hollanda", "Almanya", "İtalya", "Çek Cumhuriyeti" };
        public List<Supplier> CreateEntity()
        {
            for (int i = 0; i < 5; i++)
            {
                Supplier supplier = new Supplier()
                {
                    Id = i + 1,
                    Name = "Supplier" + (i + 1),
                    City = cities[i],
                    Country = countries[i]
                };
                allSuppliers.Add(supplier);
            }
            return allSuppliers;
        }
    }
}
