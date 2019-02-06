using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers
{
    public class CategoriesController : Controller
    {
        private ShoppingCartEntities2 db = new ShoppingCartEntities2();
        //
        // GET: /Categories/

        public ActionResult Index()
        {
            return View(db.Category.ToList());
        }

        //
        // GET: /Categories/Details/5

        public ActionResult Details(int id)
        {
            return View(db.Category.Find(id));
        }

        //
        // GET: /Categories/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Categories/Create

        [HttpPost]
        public ActionResult Create(Category  cat)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {

                    db.Category.Add(cat);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }



                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Categories/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Categories/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Categories/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Categories/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
