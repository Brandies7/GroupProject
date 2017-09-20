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
    public class MembersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public ActionResult MyAccount()
        {
            return View();
        }

        // GET: Members/Details/5
        public ActionResult Details(int? id)
        {
            Member member = db.Members.SingleOrDefault(y => y.id == id);

            if (member == null)
            {
                return HttpNotFound();
            }

            return View(member);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Member member)
        {
            
            db.Members.Add(member);
            db.SaveChanges();


            return RedirectToAction("Index","Members");
        }

        // GET: Members/Edit/5
        public ActionResult Edit(int? id)
        {
            var member = db.Members.SingleOrDefault(y => y.id == id);

            if (member == null)
            {
                return HttpNotFound();
            }


            return View(member);
        }

        // POST: Members/Edit/5
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
