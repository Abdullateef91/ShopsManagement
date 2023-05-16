using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SM.Business.DataServices;
using SM.Business.DataServices.Interfaces;
using SM.Business.Models;
using System.Reflection;

namespace SM.WebApp.Controllers
{    public class ProductController : Controller
    {
        private readonly IProductService _productServices;

        public ProductController(IProductService productServices)
        {
            _productServices = productServices;
        }


        // GET: ProductController
        public ActionResult Index(string? search)
        {
            List<ProductModel> products = null;
            if (search == null)
            {
                products = _productServices.getAll();
            }
            else
            {
                products = _productServices.getAll().Where(
                    x => x.Name.ToLower().Contains(search.Trim().ToLower()
                )).ToList();
            }
            //return View(_productServices.getAll());
            return View(products);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductModel model)
        {
            try
            {
                _productServices.Add(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var product1 = _productServices.getAll().Where(x => x.ProductId == id).FirstOrDefault();

            return View(product1);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductModel model)
        {
            try
            {
                var product = _productServices.getAll().Where(x => x.ProductId == model.ProductId).FirstOrDefault();
                if (product != null)
                {
                    product.Name = model.Name;
                    product.Description = model.Description;
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            _productServices.Delete(id);
            //return View();
            return RedirectToAction(nameof(Index));
        }

       
    }
}
