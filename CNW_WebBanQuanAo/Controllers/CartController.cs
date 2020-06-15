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

        public ActionResult AddItem(string returnURL)
        {
            //var sp = context.MATHANG.Find(id);
            int maSP = Convert.ToInt32(Request.Form["idSanPham"]);
            var sp = context.TTSANPHAM.Find(maSP);
            //var sp = (TTSANPHAM) context.TTSANPHAM.Where(s => s.MaQA == maSP);
            var cart = (Cart)Session["CartSession"];
            if (cart is null)
            {
                cart = new Cart();
            }

            int soluong;
            try
            {
                soluong = Convert.ToInt32(Request.Form["quantity"]);
            }
            catch (Exception e)
            {
                soluong = 1;
            }
            //Console.Write(soluong);
            cart.AddItem(sp, soluong);
            Session["CartSession"] = cart;

            if (String.IsNullOrEmpty(returnURL))
            {
                return RedirectToAction("Index");
            }

            return Redirect(returnURL);
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

        public void IncProd(int? maSP)
        {
            if (maSP is null) RedirectToAction("Index");

            var cart = (Cart)Session["CartSession"];
            var sanPham = context.TTSANPHAM.Find(maSP);

            cart.AddItem(sanPham, 1);

            RedirectToAction("Index");
        }
    }
}