using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using TheChromium.Models;

namespace TheChromium.Controllers
{
    public class ManagersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        

        // GET: Managers
        public ActionResult Index()
        {
            return View(db.Members.ToList());
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
            return View();
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
            var member = db.Members.SingleOrDefault(y =>y.id == id);
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
            var MemberInDB = db.Members.SingleOrDefault(y => y.id == member.id);

            MemberInDB.FirstName = member.FirstName;
            MemberInDB.LastName = member.LastName;
            MemberInDB.Email = member.Email;
            MemberInDB.Password = member.Password;
            MemberInDB.MembershipType = member.MembershipType;
            MemberInDB.MembershipStatus = member.MembershipStatus;

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
