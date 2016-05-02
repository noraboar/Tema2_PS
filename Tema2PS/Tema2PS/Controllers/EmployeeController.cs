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
      [Authorize(Roles = "Employee")]
    public class EmployeeController : Controller
    {
        private DataDBContext db = new DataDBContext();

        // GET: /Employee/
        public ActionResult Index()
        {
            return View(db.tickets.ToList());
        }

        // GET: /Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketModel ticketmodel = db.tickets.Find(id);
            if (ticketmodel == null)
            {
                return HttpNotFound();
            }
            return View(ticketmodel);
        }

        // GET: /Employee/Create
        public ActionResult Create()
        {
            //Get the value from database and then set it to ViewBag to pass it View
            IEnumerable<SelectListItem> items = db.plays.Select(c => new SelectListItem
            {
                Value = c.PlayModelId,
                Text = c.PlayModelId

            });

            ViewData["Plays"] = items;
            return View();
        }

        // POST: /Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="TicketModelId,title,row,place")] TicketModel ticketmodel)
        {


            if (ModelState.IsValid)
            {
                var tickets = from m in db.tickets
                             select m;
                tickets = tickets.Where(s => s.place == ticketmodel.place && s.row == ticketmodel.row);

                if (tickets.ToList().Count == 0)
                {
                    db.tickets.Add(ticketmodel);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    //send alert message
                    return RedirectToAction("Index");

                }

            }
            return View(ticketmodel);
        }

        // GET: /Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketModel ticketmodel = db.tickets.Find(id);
            if (ticketmodel == null)
            {
                return HttpNotFound();
            }
            return View(ticketmodel);
        }

        // POST: /Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="TicketModelId,title,row,place")] TicketModel ticketmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticketmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ticketmodel);
        }

        // GET: /Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketModel ticketmodel = db.tickets.Find(id);
            if (ticketmodel == null)
            {
                return HttpNotFound();
            }
            return View(ticketmodel);
        }

        // POST: /Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TicketModel ticketmodel = db.tickets.Find(id);
            db.tickets.Remove(ticketmodel);
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
