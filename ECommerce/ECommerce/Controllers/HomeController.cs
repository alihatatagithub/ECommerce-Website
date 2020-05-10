using ECommerce.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
       [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }
        [Authorize(Roles ="Customer,Admin")]

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            Session["ProductID"] = product.ProductID;
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
 
        [Authorize(Roles = "Customer,Admin")]
        public ActionResult AddToCart()
        {
           
       
            return View();
        }
        [Authorize(Roles = "Customer,Admin")]
        [HttpPost]
        public ActionResult AddToCart(OrderDetail model)
        {
            var UserId = User.Identity.GetUserId();

            var check = db.OrderDetails.Where(a => a.ProID == model.ProID && a.CustomerID == UserId).ToList();
            int ProdID = int.Parse(Session["ProductID"].ToString());
            model.CustomerID = UserId;
           Product prod = db.Products.Find(ProdID);
            model.ProID = prod.ProductID;
            model.UnitPrice = prod.UnitPrice;
                model.ShoppingDate = DateTime.Now;
                db.OrderDetails.Add(model);
                db.SaveChanges();
            return RedirectToAction("GetProductByCustomer");

        }
        [Authorize(Roles = "Customer,Admin")]
        public ActionResult GetProductByCustomer()
        {
            var UserId = User.Identity.GetUserId();
          var cart = db.OrderDetails.Where(a => a.CustomerID == UserId);
            return View(cart.ToList());

        }
        [Authorize(Roles ="Supplier")]
        public ActionResult GetProductBySupplier()
        {
            var UserId = User.Identity.GetUserId();
            var prods = from cart in db.OrderDetails
                           join prod in db.Products
                           on cart.ProID equals prod.ProductID
                           where prod.Supplier.SupplierID == UserId
                           select cart;
            var grouped = from p in prods
                          group p by p.Product.ProductName
                      into gr
                          select new ProductsViewModel
                          {
                              ProductName = gr.Key,
                              Items = gr
                          };

            return View(grouped.ToList());


        }
 
        public ActionResult DetailsOfProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail ProductCart = db.OrderDetails.Find(id);
            if (ProductCart == null)
            {
                return HttpNotFound();
            }
            return View(ProductCart);
        }
        public ActionResult EditOfProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail ProductCart = db.OrderDetails.Find(id);
            if (ProductCart == null)
            {
                return HttpNotFound();
            }
            return View(ProductCart);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditOfProduct( OrderDetail orderdetail)
        {

            if (ModelState.IsValid)
            {
                orderdetail.ShoppingDate = DateTime.Now;
                orderdetail.CustomerID = User.Identity.GetUserId();

                db.Entry(orderdetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GetProductByCustomer");
            }
            return View(orderdetail);
        }

        public ActionResult DeleteOfProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail ProductCart = db.OrderDetails.Find(id);
            if (ProductCart == null)
            {
                return HttpNotFound();
            }
            return View(ProductCart);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("DeleteOfProduct")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string searchName)
        {
            var result = db.Products.Where(a => a.ProductName.Contains(searchName)
            || a.Supplier.CompanyName.Contains(searchName)
            || a.Category.CategoryName.Contains(searchName));

            return View(result);
        }
        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}