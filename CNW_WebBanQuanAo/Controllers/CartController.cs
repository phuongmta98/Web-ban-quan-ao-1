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


        public ActionResult UpdateCart(int masp, int qty)
        {
            var cart = (Cart)Session["CartSession"];
           

            if (cart != null)
            {
                var product = context.SANPHAM.Find(masp);
                cart.UpdateItem(product, qty);
                Session["CartSession"] = cart;

              
            }

            return RedirectToAction("Gio");

        }

        [HttpGet]
        public ActionResult Payment()
        {
            if (Session["dnhap"] != null)
            {
                var cart = (Cart)Session["CartSession"];
                if (cart == null)
                {

                    cart = new Cart();
                }
                return View(cart);
            }
            return Redirect("https://localhost:44304/Home/DangNhap");
        }


        [HttpPost]
        public ActionResult Payment(DateTime Ngaygiao, string MaKH, string TenKhach, string DiaChiKhach, string TrangThai)
        {
            if (Session["dnhap"] != null)
            {

                HOADON model = new HOADON();
                model.MaKH = MaKH;
                model.TenKhach = TenKhach;
                model.DiaChiKhach = DiaChiKhach;
                model.TrangThai = TrangThai;
                model.NgayDat = DateTime.Now;
                model.NgayGiao = Ngaygiao;
                // var cart = (Cart)Session["CartSession"];
                try
                {
                    var x = context.HOADON.Count();
                    model.MaHD = x + 1;
                    context.HOADON.Add(model);
                    context.SaveChanges();
                    var cart = (Cart)Session["CartSession"];
                    foreach (var item in cart.Lines)
                    {
                        GIAODICH obj = new GIAODICH();
                        obj.MaHD = model.MaHD;
                        obj.MaQA = item.Sanpham.MaQA;

                        obj.SoLuong = item.Quantity;

                        context.GIAODICH.Add(obj);
                        context.SaveChanges();

                        SANPHAM sp = new SANPHAM();
                        sp = context.SANPHAM.Find(obj.MaQA);
                        if (sp.SoLuong > obj.SoLuong)
                        {
                            sp.SoLuong = sp.SoLuong - obj.SoLuong;
                            context.SaveChanges();
                        }
                        else
                        {
                            context.GIAODICH.Remove(obj);
                            context.SaveChanges();
                        }



                    }

                    cart.Clear();
                    Session["CartSession"] = cart;
                    return Redirect("https://localhost:44304/Home/Index");

                }

                catch (Exception ex)
                {
                    //ghi log
                    return RedirectToAction("/Loi");
                }
            }
            else
            {
                return Redirect("https://localhost:44304/Home/DangNhap");
            }


        }

        public ActionResult GioTam()
        {
            var dn = (TAIKHOAN)Session["dnhap"];
            var model1 = (from m in context.TAIKHOAN
                          join n in context.GIOHANG on m.Username equals n.MaKH
                          join k in context.SANPHAM on n.MaQA equals k.MaQA
                          join h in context.MATHANG on k.MaMH equals h.MaMH
                          join a in context.SIZE on k.MaSize equals a.MaSize
                          join b in context.MAU on k.MaMau equals b.MaMau
                          join c in context.ANH on h.MaMH equals c.MaMH
                          where m.Username == dn.Username && c.MaMau == b.MaMau
                          select new dschitietsanpham()
                          {
                              maqa = n.MaQA,
                              so = n.SoLuong.Value,
                              gia = h.GiaBan.Value,
                              size = a.MaSize,
                              tenmau = b.TenMau,
                              url = c.UrlAnh,
                              tenh = h.TenMH

                          }
                         ).ToList();
            return View(model1);

        }


        [HttpGet]

        public ActionResult ThanhToan()
        {
            var dn = (TAIKHOAN)Session["dnhap"];
            var model1 = (from m in context.TAIKHOAN
                          join n in context.GIOHANG on m.Username equals n.MaKH
                          join k in context.SANPHAM on n.MaQA equals k.MaQA
                          join h in context.MATHANG on k.MaMH equals h.MaMH
                          join a in context.SIZE on k.MaSize equals a.MaSize
                          join b in context.MAU on k.MaMau equals b.MaMau
                          join c in context.ANH on h.MaMH equals c.MaMH
                          where m.Username == dn.Username && c.MaMau == b.MaMau
                          select new dschitietsanpham()
                          {
                              maqa = n.MaQA,
                              so = n.SoLuong.Value,
                              gia = h.GiaBan.Value,
                              size = a.MaSize,
                              tenmau = b.TenMau,
                              url = c.UrlAnh,
                              tenh = h.TenMH

                          }
                         ).ToList();
            return View(model1);

        }

        [HttpPost]
        public ActionResult ThanhToan(DateTime Ngaygiao, string MaKH, string TenKhach, string DiaChiKhach, string TrangThai)
        {





            HOADON model = new HOADON();
            var dn = (TAIKHOAN)Session["dnhap"];
            model.NgayDat = DateTime.Now;
            model.MaKH = MaKH;
            model.NgayGiao = Ngaygiao;
            model.TrangThai = TrangThai;
            model.TenKhach = TenKhach;
            model.DiaChiKhach = DiaChiKhach;

           

            var x = context.HOADON.Count();
            model.MaHD = x + 1;
            context.HOADON.Add(model);
            context.SaveChanges();


            //var model3 =model2.

            var model1 = (from m in context.TAIKHOAN
                          join n in context.GIOHANG on m.Username equals n.MaKH
                          join k in context.SANPHAM on n.MaQA equals k.MaQA
                          join h in context.MATHANG on k.MaMH equals h.MaMH
                          join a in context.SIZE on k.MaSize equals a.MaSize
                          join b in context.MAU on k.MaMau equals b.MaMau
                          join c in context.ANH on h.MaMH equals c.MaMH
                          where m.Username == dn.Username && c.MaMau == b.MaMau
                          select new dschitietsanpham()
                          {
                              maqa = n.MaQA,
                              so = n.SoLuong.Value,
                              gia = h.GiaBan.Value,
                              size = a.MaSize,
                              tenmau = b.TenMau,
                              url = c.UrlAnh,
                              tenh = h.TenMH

                          }
                          ).ToList();

            foreach (var item in model1)
            {
                GIAODICH obj = new GIAODICH();
                obj.MaHD = model.MaHD;
                obj.MaQA = item.maqa.Value;

                obj.SoLuong = item.so.Value;

                context.GIAODICH.Add(obj);
                context.SaveChanges();

                SANPHAM sp = new SANPHAM();
                sp = context.SANPHAM.Find(obj.MaQA);
                if (sp.SoLuong > obj.SoLuong)
                {
                    sp.SoLuong = sp.SoLuong - obj.SoLuong;
                    context.SaveChanges();
                }
                else
                {
                    context.GIAODICH.Remove(obj);
                    context.SaveChanges();
                }

            }

            var model2 = (from m in context.TAIKHOAN
                          join n in context.GIOHANG on m.Username equals n.MaKH
                          join k in context.SANPHAM on n.MaQA equals k.MaQA

                          where m.Username == dn.Username
                          select new dsgio()
                          {
                              MaQa = n.MaQA,
                              so = n.SoLuong.Value,
                              name = m.Username

                          }
                       ).ToList();

            foreach (var item in model2)
            {
                GIOHANG g = context.GIOHANG.Find(item.name, item.MaQa);


                context.GIOHANG.Remove(g);
                context.SaveChanges();
            }


            
            return Redirect("https://localhost:44304/Home/Index");

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