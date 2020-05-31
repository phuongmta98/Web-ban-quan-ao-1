using CNW_WebBanQuanAo.Models;
using PagedList;
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
            string username = Request.Form["username"];
            string password = Request.Form["password"];

            Console.WriteLine(username + password);

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                var user = context.TAIKHOAN.Where(m => m.Username.Equals(username) && m.Password.Equals(password)).ToList();
                if (user.Count != 0)
                {
                    Response.Write("Dang nhap thanh cong");
                }
            }

            return View();
        }

        //[HttpPost]
        //public ActionResult Login()
        //{

        //    return View();
        //}
        public ActionResult Shop(string sortOrder, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            var model = from m in context.MATHANG select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(s => s.TenMH.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "asc":
                    model = model.OrderBy(s => s.GiaBan);
                    break;
                case "desc":
                    model = model.OrderByDescending(s => s.GiaBan);
                    break;
                default:
                    model = model.OrderBy(s => s.TenMH);
                    break;
            }

            int pageSize = 6;
            int pageIndex = 1;

            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<MATHANG> mh = null;

            //model.OrderBy(s => s.GiaBan).Skip(pageIndex * pageSize).Take(pageSize);
            mh = model.ToPagedList(pageIndex, pageSize);

            return View(mh);
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