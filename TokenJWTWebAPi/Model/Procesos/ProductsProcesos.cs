using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenJWTWebAPi.Data;
using TokenJWTWebAPi.Model.Interface;

namespace TokenJWTWebAPi.Model.Procesos
{
    public class ProductsProcesos : IProductsRepository
    {

        private ApplicationDbContext context;

        public ProductsProcesos(ApplicationDbContext db)
        {
            context = db;
        }

        public async Task<int> AddProducts(Products products)
        {
            if (context != null)
            {
                await context.Products.AddAsync(products);
                await context.SaveChangesAsync();
                return Convert.ToInt32(products.ProductID);
            }
            return 0;
        }

        public async Task<List<Products>> GetProductsAsync()
        {
            if (context != null)
            {
                return await context.Products.ToListAsync();
            }
            return null;
        }
    }
}
