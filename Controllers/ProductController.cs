using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCrud.Models;
using System.Data.Entity;

namespace MvcCrud.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.Products.ToList());
            }
            
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                
                    return View(dbModel.Products.Where(x => x.Id == id).FirstOrDefault());
            }
            
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                // TODO: Add insert logic here

                using (DbModels dbModel = new DbModels())
                {
                    dbModel.Products.Add(product);
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.Products.Where(x => x.Id == id).FirstOrDefault());
            }            
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                // TODO: Add update logic here

                using (DbModels dbModel = new DbModels())
                {
                    dbModel.Entry(product).State = EntityState.Modified;
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.Products.Where(x => x.Id == id).FirstOrDefault());
            }
            
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                using (DbModels dbModel = new DbModels())
                {
                    Product product = dbModel.Products.Where(x => x.Id == id).FirstOrDefault();
                    dbModel.Products.Remove(product);
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
