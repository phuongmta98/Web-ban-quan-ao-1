using CNW_WebBanQuanAo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNW_WebBanQuanAo.Controllers
{
    public class CartController : Controller
    {
        MyContext context = new MyContext();
        // GET: Cart
        public ActionResult Index()
        {
            var model = (Cart) Session["CartSession"];
            if (model is null)
                model = new Cart();

            return View(model);
        }

        public ActionResult AddItem(int id, string returnURL)
        {
            var sp = context.MATHANG.Find(id);
            var cart = (Cart)Session["CartSession"];
            if (cart is null)
            {
                cart = new Cart();
            }

            cart.AddItem(sp, 1);
            Session["CartSession"] = cart;

            if (String.IsNullOrEmpty(returnURL))
            {
                return RedirectToAction("Index");
            }

            return Redirect(returnURL);
        }
    }
}