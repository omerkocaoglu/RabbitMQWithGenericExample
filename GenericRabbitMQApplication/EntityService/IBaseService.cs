using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRabbitMQApplication.EntityService
{
    public interface IBaseService<T>
    {
        List<T> CreateEntity();
    }
}
