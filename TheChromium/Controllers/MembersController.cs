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

        public ActionResult Index()
        {
            return View(db.Members.ToList());
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
          var MemberShipTypes = db.Roles.Where(u => u.Name != "Manager").ToList();

          Member NewMember = new Member()
          {
              MemberType = MemberShipTypes
          };

          return View(NewMember);
        }

        // POST: Members/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Member member)
        {
            
            db.Members.Add(member);
            db.SaveChanges();


            return RedirectToAction("Details","Members");
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
            MemberInDB.MembershipId = member.MembershipId;

            return RedirectToAction("Details");
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
