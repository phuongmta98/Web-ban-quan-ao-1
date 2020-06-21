using CNW_WebBanQuanAo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using PagedList.Mvc;
using CNW_WebBanQuanAo.ViewModel;
using System.Web.Mvc;

namespace CNW_WebBanQuanAo.Controllers
{
    public class CartController : Controller
    {
        MyContext context = new MyContext();
        // GET: Cart
        public ActionResult Gio()
        {

            var cart = (Cart)Session["CartSession"];

            if (cart == null)
            {
                cart = new Cart();
            }
            return View(cart);


        }

        [HttpGet]
        public ActionResult AddItem(int id)
        {
            var product = context.SANPHAM.Find(id);

            var cart = (Cart)Session["CartSession"];

            if (cart == null)
            {
                //tạo mới đối tượng cart item
                cart = new Cart();
                cart.AddItem(product, 1);
                //Gán vào session
                Session["CartSession"] = cart;
            }
            if (cart != null)
            {
                cart.AddItem(product, 1);
                //Gán vào session
                Session["CartSession"] = cart;
            }


            return RedirectToAction("Gio");


        }

        [HttpPost]
        public ActionResult AddItemCSDL(GIOHANG model)
        {

            context.GIOHANG.Add(model);
            context.SaveChanges();

            return Redirect("https://localhost:44304/Home/Index");


        }

        public ActionResult RemoveLine(int id)
        {

            var product = context.SANPHAM.Find(id);

            var cart = (Cart)Session["CartSession"];

            if (cart != null)
            {
                cart.RemoveLine(product);
                //Gán vào session
                Session["CartSession"] = cart;
            }
            return RedirectToAction("Gio");
        }

        public ActionResult Checkout()
        {
            var cart = (Cart)Session["CartSession"];
            if (cart is null)
            {
                cart = new Cart();
            }

            return View(cart);
        }

      
    }
}