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
    public class NHASANXUATController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Admin/NHASANXUAT
        public ActionResult Index()
        {
            return View(db.NHASANXUAT.ToList());
        }

        // GET: Admin/NHASANXUAT/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHASANXUAT nHASANXUAT = db.NHASANXUAT.Find(id);
            if (nHASANXUAT == null)
            {
                return HttpNotFound();
            }
            return View(nHASANXUAT);
        }

        // GET: Admin/NHASANXUAT/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NHASANXUAT/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNSX,TenNSX,DiaChi")] NHASANXUAT nHASANXUAT)
        {
            if (ModelState.IsValid)
            {
                db.NHASANXUAT.Add(nHASANXUAT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nHASANXUAT);
        }

        // GET: Admin/NHASANXUAT/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHASANXUAT nHASANXUAT = db.NHASANXUAT.Find(id);
            if (nHASANXUAT == null)
            {
                return HttpNotFound();
            }
            return View(nHASANXUAT);
        }

        // POST: Admin/NHASANXUAT/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNSX,TenNSX,DiaChi")] NHASANXUAT nHASANXUAT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nHASANXUAT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nHASANXUAT);
        }

        // GET: Admin/NHASANXUAT/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHASANXUAT nHASANXUAT = db.NHASANXUAT.Find(id);
            if (nHASANXUAT == null)
            {
                return HttpNotFound();
            }
            return View(nHASANXUAT);
        }

        // POST: Admin/NHASANXUAT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NHASANXUAT nHASANXUAT = db.NHASANXUAT.Find(id);
            db.NHASANXUAT.Remove(nHASANXUAT);
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
