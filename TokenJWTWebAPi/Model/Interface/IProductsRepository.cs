using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenJWTWebAPi.Model;

namespace TokenJWTWebAPi.Model.Interface
{
   public interface IProductsRepository
    {

        Task<List<Products>> GetProductsAsync();
        Task<int> AddProducts(Products products);
    }
}
