using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Data
{
    public class ProductRepository : IProductRepository
    {
        public IList<Product> GetAll()
        {
            return new List<Product>()
            {
                new Product() { Id = 42, Name ="A product", UnitPrice = 100 },
                new Product() { Id = 101, Name ="Another product", UnitPrice = 150 },
            };
        }
    }
}
