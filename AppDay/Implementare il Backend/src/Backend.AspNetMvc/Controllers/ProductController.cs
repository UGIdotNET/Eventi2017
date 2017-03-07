using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Backend.Data;

namespace Backend.AspNetMvc.Controllers
{
    public class ProductController : Controller
    {
        public IProductRepository ProductRepository { get; private set; }
        public ProductController(IProductRepository repository)
        {
            ProductRepository = repository;
        }

        //[OutputCache(Duration = 20)]
        [HttpGet]
        public ActionResult GetAll()
        {
            var model = ProductRepository.GetAll();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpGet()]
        public ActionResult GetById(int id)
        {
            var model = ProductRepository
                .GetAll()
                .Where(p => p.Id == id)
                .Single();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        #region REST
        // PATCH api/product
        [HttpPatch()]
        public ActionResult Update(int id, Product model)
        {
            return new HttpStatusCodeResult(200);
        }

        // POST api/product
        [HttpPost()]
        public ActionResult Post(Product model)
        {
            return new HttpStatusCodeResult(200);
        }

        // PUT api/product/5
        [HttpPut]
        [Route("{id}")]
        public ActionResult Create(int id, Product model)
        {
            return new HttpStatusCodeResult(201);
        }

        // DELETE api/product/5
        [HttpDelete()]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            return new HttpStatusCodeResult(200);
        }
        #endregion
    }
}