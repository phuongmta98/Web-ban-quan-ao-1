using CNW_WebBanQuanAo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNW_WebBanQuanAo.Controllers
{
    public class HomeController : Controller
    {
        MyContext context = new MyContext();
        public ActionResult Index()
        {
            //var model = context.MATHANG.Where(x => x.TenMH != null).ToList();
            //return View(model);

            var model = context.MATHANG.Where(x => x.MaMH != null).ToList();

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Login()
        {
            ViewBag.Message = "User logins theirs account";

            return View();
        }
        public ActionResult Cart()
        {
            ViewBag.Message = "User checks theirs cart";

            return View();
        }
        public ActionResult Shop()
        {
            var model = context.MATHANG.Where(x => x.TenMH != null).ToList();
            return View(model);
        }

        public ActionResult Checkout()
        {
            ViewBag.Message = "Customers checkout";

            return View();
        }

        [ChildActionOnly]
        public ActionResult LeftMenu()
        {
            var model = context.NHASANXUAT.ToList();
            return PartialView("~/Views/Shared/_LeftMenu.cshtml", model);
        }
        public ActionResult Detail()
        {
            ViewBag.Message = "Details of a specified product";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}