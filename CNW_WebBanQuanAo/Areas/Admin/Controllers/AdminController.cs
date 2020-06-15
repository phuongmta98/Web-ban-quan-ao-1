using CNW_WebBanQuanAo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using System.Net;

namespace CNW_WebBanQuanAo.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private MyContext db = new MyContext();
        // GET: Admin/Admin
        public ActionResult Index()
        {
            var hOADON = db.HOADON.Include(m => m.TAIKHOAN).Include(m => m.TAIKHOAN1).Include(m => m.GIAODICH);

            return View(hOADON.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MATHANG mATHANG = db.MATHANG.Find(id);
            if (mATHANG == null)
            {
                return HttpNotFound();
            }
            return View(mATHANG);
        }
    }
}