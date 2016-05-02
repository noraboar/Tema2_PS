using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tema2PS.Models;

namespace Tema2PS.Controllers
{
      [Authorize(Roles = "Admin")]
    public class PlaysController : Controller
    {
        private DataDBContext db = new DataDBContext();

        // GET: /Plays/
        public ActionResult Index()
        {
            return View(db.plays.ToList());
        }

        // GET: /Plays/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayModel playmodel = db.plays.Find(id);
            if (playmodel == null)
            {
                return HttpNotFound();
            }
            return View(playmodel);
        }

        // GET: /Plays/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Plays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="PlayModelId,distribution,directedBy,premiereDate,TicketNumber")] PlayModel playmodel)
        {
            if (ModelState.IsValid)
            {
                db.plays.Add(playmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(playmodel);
        }

        // GET: /Plays/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayModel playmodel = db.plays.Find(id);
            if (playmodel == null)
            {
                return HttpNotFound();
            }
            return View(playmodel);
        }

        // POST: /Plays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="PlayModelId,distribution,directedBy,premiereDate,TicketNumber")] PlayModel playmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(playmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(playmodel);
        }

        // GET: /Plays/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayModel playmodel = db.plays.Find(id);
            if (playmodel == null)
            {
                return HttpNotFound();
            }
            return View(playmodel);
        }

        // POST: /Plays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PlayModel playmodel = db.plays.Find(id);
            db.plays.Remove(playmodel);
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
