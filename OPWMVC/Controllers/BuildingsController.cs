using OPWMVC.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace OPWMVC.Controllers
{
    public class BuildingsController : Controller
    {
        private OPWEntities db = new OPWEntities();

        // GET: Buildings
        public ActionResult Index()
        {

            var buildings = db.Buildings.Include(b => b.Work);
            return View(buildings.ToList());
        }

        // GET: Buildings/Details/5
        public ActionResult FindBuilding(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "No BuildingID was requested");
            }
            Building building = db.Buildings.Find(id);
            if (building == null)
            {
                return HttpNotFound("Building" + building.BuildingId + "Could not be found");
            }
            return View(building);
        }

        // GET: Buildings/Create
        public ActionResult Create()
        {
            ViewBag.WorkId = new SelectList(db.Works, "WorkId", "OPW_Building_Code");
            return View();
        }

        // POST: Buildings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BuildingId,OPW_Building_Code,Address,County,B_Type,Cost_Centre,B_Team,WorkId")] Building building)
        {
            if (ModelState.IsValid)
            {
                db.Buildings.Add(building);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WorkId = new SelectList(db.Works, "WorkId", "OPW_Building_Code", building.WorkId);
            return View(building);
        }

        // GET: Buildings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Building building = db.Buildings.Find(id);
            if (building == null)
            {
                return HttpNotFound();
            }
            ViewBag.WorkId = new SelectList(db.Works, "WorkId", "OPW_Building_Code", building.WorkId);
            return View(building);
        }

        // POST: Buildings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BuildingId,OPW_Building_Code,Address,County,B_Type,Cost_Centre,B_Team,WorkId")] Building building)
        {
            if (ModelState.IsValid)
            {
                db.Entry(building).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WorkId = new SelectList(db.Works, "WorkId", "OPW_Building_Code", building.WorkId);
            return View(building);
        }

        // GET: Buildings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Building building = db.Buildings.Find(id);
            if (building == null)
            {
                return HttpNotFound();
            }
            return View(building);
        }

        // POST: Buildings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Building building = db.Buildings.Find(id);
            db.Buildings.Remove(building);
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

        // Methods
        // Method to Approve Building work approval requests

        /*
         public string Approveworks(int? Project_id)
        {
            try
            {
                FindBuilding(int ? Project_id);


                if ((Authorisation.User_ID == User_ID) &&
                   (Authorisation.Usersect == User_Section.Accommodation || Authorisation.Usersect == User_Section.Admin) &&
                   (Authorisation.User_Approval_Limit >= Proj_budget_Requested))
                {
                    Proj_budget_Approved = Proj_budget_Requested;
                    Status = Status.Approved;
                    return ("Works have been approved");
                }
                else return ("Works have been approved - Check your Approval Limit");
            }
            catch (Exception e)
            {
                return e.ToString();
            }


            // Method to Approve funding of approved building works requests
            public string Approveworks(Building_Works building_Works)
            {
                try
                {
                    if (Authorisation.User_ID == User_ID && Authorisation.User_Approval_Limit >= Proj_budget_Requested)
                    {
                        Proj_budget_Approved = Proj_budget_Requested;
                        Status = Status.Approved;
                        return ("Works have been approved");
                    }
                    else return ("Works have been approved - Check your Approval Limit");
                }
                catch (Exception e)
                {
                    return e.ToString();
                }
   }
}

*/
}
    
}
