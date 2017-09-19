using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheChromium.Models;

namespace TheChromium.Controllers
{
    public class EventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Events
        public ActionResult Index()
        {
            var events = db.Events.ToList();

            return View(events);
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Events events = db.Events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Events NewEvent)
        {
           db.Events.Add(NewEvent);
           db.SaveChanges();
           return RedirectToAction("Index");
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Events events = db.Events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        // POST: Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Events events)
        {
            var EventInDB = db.Events.SingleOrDefault(y => y.EventId == events.EventId);

            EventInDB.EventName = events.EventName;
            EventInDB.DateOfEvent = events.DateOfEvent;
            EventInDB.StartOfEvent = events.StartOfEvent;
            EventInDB.EndOfEvent = events.EndOfEvent;
            EventInDB.Description = events.Description;
            EventInDB.Particpants = events.Particpants;

            return RedirectToAction("Index");
        }

        public ActionResult Calendar()
        {
            return View();
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
