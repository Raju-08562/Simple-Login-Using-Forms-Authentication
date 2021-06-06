using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using DemoProject1.Login;
using System.Web.Security;

namespace DemoProject1.Controllers
{
    public class MemberLoginsController : Controller
    {
        private EmployeeDBContext db = new EmployeeDBContext();

        // GET: MemberLogins
        //public ActionResult Index()
        //{
        //    return View(db.members.ToList());
        //}

        // GET: MemberLogins/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    MemberLogin memberLogin = db.members.Find(id);
        //    if (memberLogin == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(memberLogin);
        //}

       

        // GET: MemberLogins/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    MemberLogin memberLogin = db.members.Find(id);
        //    if (memberLogin == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(memberLogin);
        //}

        // POST: MemberLogins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,UserName,Password")] MemberLogin memberLogin)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(memberLogin).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(memberLogin);
        //}

        //// GET: MemberLogins/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    MemberLogin memberLogin = db.members.Find(id);
        //    if (memberLogin == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(memberLogin);
        //}

        //// POST: MemberLogins/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    MemberLogin memberLogin = db.members.Find(id);
        //    db.members.Remove(memberLogin);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(MemberLogin member)
        {
            using (EmployeeDBContext employeeDBContext = new EmployeeDBContext())
            {
                bool isValid = employeeDBContext.members.Any(x => x.UserName == member.UserName && x.Password == member.Password);

                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(member.UserName,false);
                    return RedirectToAction("Index", "Employees");
                }
                else
                {
                    ModelState.AddModelError("","UserName and Password incorrect.");
                }
                
            }
            return View();
        }

        // GET: MemberLogins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MemberLogins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,Password")] MemberLogin memberLogin)
        {
            if (ModelState.IsValid)
            {
                db.members.Add(memberLogin);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(memberLogin);
        }

        
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
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
