using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CNW_WebBanQuanAo.Models;

namespace CNW_WebBanQuanAo.Areas.Admin.Controllers
{
    public class PHANHOIController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Admin/PHANHOI
        public ActionResult Index()
        {
            var pHANHOI = db.PHANHOI.Include(p => p.TAIKHOAN);
            return View(pHANHOI.ToList());
        }

        // GET: Admin/PHANHOI/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHANHOI pHANHOI = db.PHANHOI.Find(id);
            if (pHANHOI == null)
            {
                return HttpNotFound();
            }
            return View(pHANHOI);
        }

        // GET: Admin/PHANHOI/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.TAIKHOAN, "Username", "HoTen");
            return View();
        }

        // POST: Admin/PHANHOI/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPH,MaKH,TieuDe,NoiDung,NgayGui")] PHANHOI pHANHOI)
        {
            if (ModelState.IsValid)
            {
                db.PHANHOI.Add(pHANHOI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.TAIKHOAN, "Username", "HoTen", pHANHOI.MaKH);
            return View(pHANHOI);
        }

        // GET: Admin/PHANHOI/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHANHOI pHANHOI = db.PHANHOI.Find(id);
            if (pHANHOI == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.TAIKHOAN, "Username", "HoTen", pHANHOI.MaKH);
            return View(pHANHOI);
        }

        // POST: Admin/PHANHOI/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPH,MaKH,TieuDe,NoiDung,NgayGui")] PHANHOI pHANHOI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHANHOI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.TAIKHOAN, "Username", "HoTen", pHANHOI.MaKH);
            return View(pHANHOI);
        }

        // GET: Admin/PHANHOI/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHANHOI pHANHOI = db.PHANHOI.Find(id);
            if (pHANHOI == null)
            {
                return HttpNotFound();
            }
            return View(pHANHOI);
        }

        // POST: Admin/PHANHOI/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PHANHOI pHANHOI = db.PHANHOI.Find(id);
            db.PHANHOI.Remove(pHANHOI);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
