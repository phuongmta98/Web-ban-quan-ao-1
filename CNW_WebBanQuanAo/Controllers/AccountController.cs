using CNW_WebBanQuanAo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNW_WebBanQuanAo.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        MyContext context = new MyContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginPost()
        {
            ViewBag.Message = "User logins theirs account";
            string username = Request.Form["username"];
            string password = Request.Form["password"];

            string t = Request.Form["checkbox"];
            //Response.Write(t);

            //string k = Response.Cookies["LoginCookie"]["username"];
            //string l = Response.Cookies["LoginCookie"]["password"];
            //Response.Write(Response.Cookies["LoginCookie"]["username"]);
            //Response.Write(Response.Cookies["LoginCookie"]["password"]);

            if (!string.IsNullOrEmpty(t) && t.Equals("remember"))
            {
                Response.Cookies["usernameCookie"].Value = username;
                Response.Cookies["passwordCookie"].Value = password;
            }

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                var user = context.TAIKHOAN.Where(m => m.Username.Equals(username) && m.Password.Equals(password)).ToList();
                if (user.Count != 0)
                {
                    Response.Write("Dang nhap thanh cong");
                    Session["LoggedinUser"] = user[0];
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Login()
        {
            TAIKHOAN tk = new TAIKHOAN();
            tk.Username = Request.Cookies["usernameCookie"].Value;
            tk.Password = Request.Cookies["passwordCookie"].Value;
            //Response.Write("ehe: " + tk.Username + tk.Password);

            return View(tk);
        }
    }
}