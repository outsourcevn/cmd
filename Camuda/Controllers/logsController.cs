using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Camuda.Models;
using PagedList;
namespace Camuda.Controllers
{
    public class logsController : Controller
    {
        private carmudaEntities db = new carmudaEntities();

        // GET: logs
        public ActionResult Index(int? pg,string devname)
        {
            int pageSize = 25;
            if (pg == null) pg = 1;
            int pageNumber = (pg ?? 1);
            ViewBag.pg = pg;
            if (devname == null) devname = "";
            var data = (from q in db.logs where q.dev.Contains(devname) select q);
            if (data == null)
            {
                return View(data);
            }

            data = data.OrderByDescending(x => x.id);
            ViewBag.OnePage = data.ToPagedList(pageNumber, pageSize);
            return View(data.ToPagedList(pageNumber, pageSize));
        }

        // GET: logs/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            log log = db.logs.Find(id);
            if (log == null)
            {
                return HttpNotFound();
            }
            return View(log);
        }

        // GET: logs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: logs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,dev,dri,tim,dat,lat,lon,wng,anl,pul,opt,dig,vgp,dir,vsr,mil,old,sat,hwv,fwv,clt,clg,sig,hdo,bat,epw,drt,cdt")] log log)
        {
            if (ModelState.IsValid)
            {
                db.logs.Add(log);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(log);
        }

        // GET: logs/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            log log = db.logs.Find(id);
            if (log == null)
            {
                return HttpNotFound();
            }
            return View(log);
        }

        // POST: logs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,dev,dri,tim,dat,lat,lon,wng,anl,pul,opt,dig,vgp,dir,vsr,mil,old,sat,hwv,fwv,clt,clg,sig,hdo,bat,epw,drt,cdt")] log log)
        {
            if (ModelState.IsValid)
            {
                db.Entry(log).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(log);
        }

        // GET: logs/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            log log = db.logs.Find(id);
            if (log == null)
            {
                return HttpNotFound();
            }
            return View(log);
        }

        // POST: logs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            log log = db.logs.Find(id);
            db.logs.Remove(log);
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
