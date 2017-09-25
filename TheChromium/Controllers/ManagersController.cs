using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using TheChromium.Models;
using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;

namespace TheChromium.Controllers
{
    public class ManagersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();



        // GET: Managers
        public ActionResult Index()
        {
            var members = db.Members.Include(y => y.MemberStatus).ToList();

            return View();
        }

        // GET: Managers/Details/5
        public ActionResult Details(int? id)
        {
            var member = db.Members.SingleOrDefault(y => y.id == id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Managers/Create
        public ActionResult Create()
        {
            var MemberShipTypes = db.Roles.Where(u => u.Name != "Manager").ToList();
            var StatusOptions = db.MemberStats.ToList();

            Member NewMember = new Member()
            {
                MemberType = MemberShipTypes,
                StatusOptions = StatusOptions
            };

            return View(NewMember);
        }

        // POST: Managers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Member member)
        {
            db.Members.Add(member);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Managers/Edit/5
        public ActionResult Edit(int? id)
        {
            var member = db.Members.SingleOrDefault(y => y.id == id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Managers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Member member)
        {
            var MemberInDB = db.Members.Include(y => y.MemberStatus).SingleOrDefault(y => y.id == member.id);

            MemberInDB.FirstName = member.FirstName;
            MemberInDB.LastName = member.LastName;
            MemberInDB.Email = member.Email;
            MemberInDB.MembershipId = member.MembershipId;
            MemberInDB.StatusId = member.StatusId;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Events()
        {
            return View(db.Events.ToList());
        }

        public ActionResult Map(int id)
        {
            var EventSelected = db.Events.SingleOrDefault(y => y.EventId == id);

            if (EventSelected == null)
            {
                return HttpNotFound();
            }

            return View();
        }

        //public RedirectResult RedirectToAspx()
        //{
        //    return Redirect("SendSMS.aspx");
        //}
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

      

            
