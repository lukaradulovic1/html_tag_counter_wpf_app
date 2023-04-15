using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using database_first_aspnet_app_mvc;

namespace database_first_aspnet_app_mvc.Controllers
{
    public class TrainingGroupsController : Controller
    {
        private gymDatabaseEntities db = new gymDatabaseEntities();

        // GET: TrainingGroups
        public ActionResult Index()
        {
            return View(db.TrainingGroups.ToList());
        }

        // GET: TrainingGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingGroup trainingGroup = db.TrainingGroups.Find(id);
            if (trainingGroup == null)
            {
                return HttpNotFound();
            }
            return View(trainingGroup);
        }

        // GET: TrainingGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrainingGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,trainer_id")] TrainingGroup trainingGroup)
        {
            if (ModelState.IsValid)
            {
                db.TrainingGroups.Add(trainingGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trainingGroup);
        }

        // GET: TrainingGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingGroup trainingGroup = db.TrainingGroups.Find(id);
            if (trainingGroup == null)
            {
                return HttpNotFound();
            }
            return View(trainingGroup);
        }

        // POST: TrainingGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,trainer_id")] TrainingGroup trainingGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainingGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainingGroup);
        }

        // GET: TrainingGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingGroup trainingGroup = db.TrainingGroups.Find(id);
            if (trainingGroup == null)
            {
                return HttpNotFound();
            }
            return View(trainingGroup);
        }

        // POST: TrainingGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainingGroup trainingGroup = db.TrainingGroups.Find(id);
            db.TrainingGroups.Remove(trainingGroup);
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
