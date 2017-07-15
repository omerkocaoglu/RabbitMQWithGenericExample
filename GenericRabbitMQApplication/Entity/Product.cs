using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRabbitMQApplication.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime ProductionDate { get; set; }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
