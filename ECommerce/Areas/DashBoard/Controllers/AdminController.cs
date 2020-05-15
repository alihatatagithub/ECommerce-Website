using ECommerce.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Areas.DashBoard.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {

        UserManager<ApplicationUser> usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));


        [AllowAnonymous]
        // GET: DashBoard/Admin
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await usermanager.FindAsync(model.UserName, model.Password);
                if (user != null)
                {
                    // HttpContext.User.Identity.IsAuthenticated
                    HttpContext.GetOwinContext().Authentication.SignOut();
                    ClaimsIdentity cid = await usermanager.CreateIdentityAsync(user, "ApplicationCookie");

                    HttpContext.GetOwinContext().Authentication.SignIn
                        (cid);
                    return RedirectToAction("Index");
                }
            }
            return View(model);

        }
        public ActionResult Index()
        {
            return Content("Successsssssssss");
        }
        public ActionResult Contact()
        {
            return View();
        }

    }
}