using Backend.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend.WebApi.Controllers
{
    public class ProductController : ApiController
    {
        public IProductRepository ProductRepository { get; private set; }
        public ProductController(IProductRepository repository)
        {
            ProductRepository = repository;
        }

        public IList<Product> Get()
        {
            var model = ProductRepository.GetAll();
            return model;
        }

        public Product Get(int id)
        {
            var model = ProductRepository
                .GetAll()
                .Where(p => p.Id == id)
                .Single();
            return model;
        }

        #region REST
        // PATCH api/values
        public void Patch(int id, [FromBody]Product model)
        {
        }

        // POST api/values
        public void Post([FromBody]Product model)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Product model)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
        #endregion
    }
}
