using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCart.Models;
namespace ShoppingCart.Controllers
{
    public class ProductsController : Controller
    {
        //
        // GET: /Products/
        //detailes
        private ShoppingCartEntities2 db= new ShoppingCartEntities2();
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {



            return View(db.CateProd.ToList());
        }
        // GET: /Products/
        public ActionResult Index()
        {
            return View(db.CateProd.ToList());
        }
        //
        // GET: /Products/Details/5

        public ActionResult Details(int id)
        {
            Products prod = db.Products.Find(id);
            if (prod.CategoryId != null )
            {
                Category cat = db.Category.Find(prod.CategoryId);
                ViewData.Add("CategoryDesc", cat.CategoryDescription);
            }
            else
            {
                ViewData.Add("CategoryDesc", 1);    
            }
            
            return View(db.Products.Find(id));
        }

        //
        // GET: /Products/Create

        public ActionResult Create()
        {
            ViewData.Add("CategoryTbl", db.Category);
            return View();
        }

        //
        // POST: /Products/Create

        [HttpPost]
        public ActionResult Create(Products Prod, HttpPostedFileBase file)
        {
            string _path = "";
            string _FileName = "";
            try
            {
                try
                {
                    if (file.ContentLength > 0)
                    {
                        _FileName = Path.GetFileName(file.FileName);
                        _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                        file.SaveAs(_path);
                    }
                    ViewBag.Message = "File Uploaded Successfully!!";
                }
                catch
                {
                    ViewBag.Message = "File upload failed!!";
                }


                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    if (file != null)
                        Prod.imgSrc = ("/UploadedFiles/" + _FileName).ToString().Trim();
                    db.Products.Add(Prod);
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
        // GET: /Products/Edit/5

        public ActionResult Edit(int id)
        {
            ViewData.Add("CategoryTbl", db.Category);
            Products prod = db.Products.Find(id);
            if (prod.CategoryId == null )
            {
                prod.CategoryId = 1;
            }
            return View(prod);
        }

        //
        // POST: /Products/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Products prdUpd, HttpPostedFileBase file)
        {
            string _path = "";
            string _FileName = "";
            try
            {
                 try
                 {
                     if (file.ContentLength > 0)
                     {
                         _FileName = Path.GetFileName(file.FileName);
                         _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                         file.SaveAs(_path);
                     }
                     ViewBag.Message = "File Uploaded Successfully!!";
                 }
                 catch
                 {
                     ViewBag.Message = "File upload failed!!";
                 }

                 var prod = db.Products.Find(id);
                 prod.Price = prdUpd.Price;
                 prod.CategoryId = prdUpd.CategoryId;
                 prod.ProductName = prdUpd.ProductName;
                 if (file != null )
                     prod.imgSrc =( "/UploadedFiles/"+ _FileName).ToString().Trim();
                 prod.amount = prdUpd.amount;

                 db.SaveChanges();


                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        //
        // GET: /Products/Delete/5

        public ActionResult Delete(int id)
        {
            return View(db.Products.Find(id));
        }

        //
        // POST: /Products/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Products Prod)
        {
            try
            {
                // TODO: Add delete logic here

                if (ModelState.IsValid)
                {
                    db.Products.Remove( db.Products.Find(id));
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
    }
}
