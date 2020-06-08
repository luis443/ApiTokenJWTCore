using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenJWTWebAPi.Model.Interface
{
   public interface IOrdersRepository
    {
        Task<List<Orders>> GetOrders();
        Task<int> RegistrarOrden(Orders orders);
        Task ActualizarOrden(Orders orders);
        Task<int> EliminarOrden(int? id);
    }
}
