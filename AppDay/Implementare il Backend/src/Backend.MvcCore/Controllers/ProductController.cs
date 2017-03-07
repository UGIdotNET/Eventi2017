using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Backend.Data;

namespace Backend.MvcCore.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        public IProductRepository ProductRepository { get; private set; }
        public ProductController(IProductRepository repository)
        {
            ProductRepository = repository;
        }

        [HttpGet]
        [ResponseCache(Duration =20)]
        public IList<Product> Get()
        {
            var model = ProductRepository.GetAll();
            return model;
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public Product Get(int id)
        {
            var model = ProductRepository
                .GetAll()
                .Where(p => p.Id == id)
                .Single();
            return model;
        }

        #region REST
        // PATCH api/product
        [HttpPatch("{id}")]
        public void Update(int id, [FromBody]Product model)
        {
        }

        //// POST api/product
        [HttpPost("{id}")]
        public void Post([FromBody]Product model)
        {
        }

        // PUT api/product/5
        [HttpPut("{id}")]
        public void Create(int id, [FromBody]Product model)
        {
        }

        // DELETE api/product/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        #endregion

    }
}