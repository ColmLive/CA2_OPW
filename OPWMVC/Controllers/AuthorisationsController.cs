using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OPWMVC.Models;

namespace OPWMVC.Controllers
{
    public class AuthorisationsController : Controller
    {
        private OPWEntities db = new OPWEntities();

        // GET: Authorisations
        public ActionResult Index()
        {
            var authorisations = db.Authorisations.Include(a => a.Work);
            return View(authorisations.ToList());
        }

        // GET: Authorisations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Authorisation authorisation = db.Authorisations.Find(id);
            if (authorisation == null)
            {
                return HttpNotFound();
            }
            return View(authorisation);
        }

        // GET: Authorisations/Create
        public ActionResult Create()
        {
            ViewBag.WorkId = new SelectList(db.Works, "WorkId", "OPW_Building_Code");
            return View();
        }

        // POST: Authorisations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AuthorisationId,User_Name,User_Password,Company,User,User_Section_Code,User_Approval_Limit,WorkId")] Authorisation authorisation)
        {
            if (ModelState.IsValid)
            {
                db.Authorisations.Add(authorisation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WorkId = new SelectList(db.Works, "WorkId", "OPW_Building_Code", authorisation.WorkId);
            return View(authorisation);
        }

        // GET: Authorisations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Authorisation authorisation = db.Authorisations.Find(id);
            if (authorisation == null)
            {
                return HttpNotFound();
            }
            ViewBag.WorkId = new SelectList(db.Works, "WorkId", "OPW_Building_Code", authorisation.WorkId);
            return View(authorisation);
        }

        // POST: Authorisations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AuthorisationId,User_Name,User_Password,Company,User,User_Section_Code,User_Approval_Limit,WorkId")] Authorisation authorisation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(authorisation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WorkId = new SelectList(db.Works, "WorkId", "OPW_Building_Code", authorisation.WorkId);
            return View(authorisation);
        }

        // GET: Authorisations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Authorisation authorisation = db.Authorisations.Find(id);
            if (authorisation == null)
            {
                return HttpNotFound();
            }
            return View(authorisation);
        }

        // POST: Authorisations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Authorisation authorisation = db.Authorisations.Find(id);
            db.Authorisations.Remove(authorisation);
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
