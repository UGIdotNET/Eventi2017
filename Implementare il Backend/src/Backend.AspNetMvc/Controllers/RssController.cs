using Backend.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMate.Web.Mvc;
using System.ServiceModel.Syndication;

namespace Backend.AspNetMvc.Controllers
{
    public class RssController : Controller
    {
        public IProductRepository ProductRepository { get; private set; }
        public RssController(IProductRepository repository)
        {
            ProductRepository = repository;
        }

        // GET: Rss
        public ActionResult Index()
        {
            var model = GetFeed();
            return this.Rss20(model);
        }

        public ActionResult Custom()
        {
            var model = GetFeed();
            return View("RssFeed", model);
        }

        private SyndicationFeed GetFeed()
        {
            var products = ProductRepository.GetAll();
            var model = new SyndicationFeed();
            model.Title = new TextSyndicationContent("Products");
            var items = new List<SyndicationItem>();
            products.ToList()
                .ForEach(p => items.Add(new SyndicationItem(p.Name, $"{p.Name} - {p.UnitPrice}", new Uri($"http://www.mysite.org/product/{p.Id}/{p.Name}"))));
            model.Items = items;
            return model;
        }
    }
}