using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers
{
    public class usersController : Controller
    {
        private ShoppingCartEntities2 db = new ShoppingCartEntities2();
        
        //
        // GET: /users/

        public ActionResult Index()
        {
            return View(db.users.ToList());
        }

        //
        // GET: /users/Details/5

        public ActionResult Details(int id = 0)
        {
            users users = db.users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        //
        // GET: /users/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /users/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(users users)
        {
            if (ModelState.IsValid)
            {
                db.users.Add(users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(users);
        }

        //
        // GET: /users/Edit/5

        public ActionResult Edit(int id = 0)
        {
            users users = db.users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        //
        // POST: /users/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(users users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(users);
        }

        //
        // GET: /users/Delete/5

        public ActionResult Delete(int id = 0)
        {
            users users = db.users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        //
        // POST: /users/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            users users = db.users.Find(id);
            db.users.Remove(users);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}