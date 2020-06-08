using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TokenJWTWebAPi.Data;
using TokenJWTWebAPi.Model;

using TokenJWTWebAPi.Model.Interface;

namespace TokenJWTWebAPi.Model.Procesos
{
    public class OrdersProcesos : IOrdersRepository
    {
        private ApplicationDbContext context;

        public OrdersProcesos(ApplicationDbContext db)
        {
            context = db;
        }

        public async Task ActualizarOrden(Orders orders)
        {
            if (context != null)
            {
                await context.Orders.AddAsync(orders);
                await context.SaveChangesAsync();
            }
        }

        public async Task<int> EliminarOrden(int? id)
        {
            int result = 0;
            if (context != null)
            {
                var Orden = await context.Orders.FirstOrDefaultAsync(x => x.OrderID == id);
                if (Orden != null)
                {
                    context.Orders.Remove(Orden);
                    result = await context.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task<List<Orders>> GetOrders()
        {
            List<Orders> orders = new List<Orders>();
            if (context != null)
            {
                orders= await context.Orders.Include("OrderDetails").ToListAsync();
                return orders;
            }
            return null;
        }

        public async Task<int> RegistrarOrden(Orders orders)
        {
            if (context != null)
            {
                await context.Orders.AddAsync(orders);
                await context.SaveChangesAsync();
                return Convert.ToInt32(orders.OrderID);
            }
            return 0;
        }
    }
}
