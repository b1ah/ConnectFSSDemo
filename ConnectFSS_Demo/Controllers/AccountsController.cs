using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ConnectFSS_Demo.Models;

namespace ConnectFSS_Demo.Controllers
{
    public class AccountsController : Controller
    {
        private ConnectFSSEntities db = new ConnectFSSEntities();

        // GET: Accounts
        public ActionResult Index()
        {
            if (Session["userId"] is null) { return RedirectToAction("Index", "Login"); }

            int sessionUserId = (int)Session["userId"];
            bool sessionUserAdmin = (bool)Session["userAdmin"];
            var accounts = db.Accounts.Where(a => a.userId == sessionUserId || sessionUserAdmin)
                .Include(a => a.AccountType).Include(a => a.User)
                .OrderBy(a => a.AccountType.id);
            return View(accounts.ToList());
        }

        // GET: Accounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Accounts/Create
        public ActionResult Create()
        {
            ViewBag.typeId = new SelectList(db.AccountTypes, "id", "name");
            ViewBag.userId = new SelectList(db.Users, "id", "first_name");
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,userId,typeId,name,balance")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Accounts.Add(account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.typeId = new SelectList(db.AccountTypes, "id", "name", account.typeId);
            ViewBag.userId = new SelectList(db.Users, "id", "first_name", account.userId);
            return View(account);
        }

        // GET: Accounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            ViewBag.typeId = new SelectList(db.AccountTypes, "id", "name", account.typeId);
            ViewBag.userId = new SelectList(db.Users, "id", "first_name", account.userId);
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,userId,typeId,name,balance")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.typeId = new SelectList(db.AccountTypes, "id", "name", account.typeId);
            ViewBag.userId = new SelectList(db.Users, "id", "first_name", account.userId);
            return View(account);
        }

        // GET: Accounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Account account = db.Accounts.Find(id);
            db.Accounts.Remove(account);
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
