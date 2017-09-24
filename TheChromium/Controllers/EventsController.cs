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
            var events = db.Events.Include(y => y.MembershipRequired).ToList();

            return View(events);
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            var SelectedEvent = db.Events.Include(y => y.MembershipRequired).Single(y=>y.EventId == id);

            if (SelectedEvent == null)
            {
                return HttpNotFound();
            }

            return View(SelectedEvent);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            Events NewEvent = new Events()
            {
                Memberships = db.Roles.Where(u => u.Name != "Manager").ToList()
            };

            return View(NewEvent);
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
            var events = db.Events.Include(y => y.MembershipRequired).SingleOrDefault(y => y.EventId == id);

            return View(events);
        }

        // POST: Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Events events)
        {
            var EventInDB = db.Events.Include(y=>y.MembershipRequired).Single(y => y.EventId == events.EventId);

            EventInDB.EventName = events.EventName;
            EventInDB.DateOfEvent = events.DateOfEvent;
            EventInDB.StartOfEvent = events.StartOfEvent;
            EventInDB.EndOfEvent = events.EndOfEvent;
            EventInDB.Memberid = events.Memberid;
            EventInDB.Location = events.Location;
            EventInDB.Particpants = events.Particpants;

            db.SaveChanges();

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

        public JsonResult GetEvents()
        {
            using (CalendarDatabaseEntities dc = new CalendarDatabaseEntities())
            {
                var events = dc.Events.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        [HttpPost]
        public JsonResult SaveEvent(Event e)
        {
            var status = false;
            using (CalendarDatabaseEntities dc = new CalendarDatabaseEntities())
            {
                if (e.EventID > 0)
                {
                    //Update the event
                    var v = dc.Events.FirstOrDefault(a => a.EventID == e.EventID);
                    if (v != null)
                    {
                        v.Subject = e.Subject;
                        v.Start = e.Start;
                        v.End = e.End;
                        v.Description = e.Description;
                        v.IsFullDay = e.IsFullDay;
                        v.ThemeColor = e.ThemeColor;
                    }
                }
                else
                {
                    dc.Events.Add(e);
                }
                dc.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeleteEvent(int eventId)
        {
            var status = false;
            using (CalendarDatabaseEntities dc = new CalendarDatabaseEntities())
            {
                var v = dc.Events.FirstOrDefault(a => a.EventID == eventId);
                if (v != null)
                {
                    dc.Events.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }


    }
}
