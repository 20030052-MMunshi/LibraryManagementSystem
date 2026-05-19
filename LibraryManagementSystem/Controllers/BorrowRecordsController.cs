using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Filters;

namespace LibraryManagementSystem.Controllers
{
    [CustomAuthorize(Role = "Librarian")]
    public class BorrowRecordsController : Controller
    {
        private LibraryManagementSystemContext db = new LibraryManagementSystemContext();

        // SECURITY CHECK: Login required
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["UserName"] == null)
            {
                filterContext.Result = RedirectToAction("Login", "Home");
                return;
            }

            base.OnActionExecuting(filterContext);
        }

        // GET: BorrowRecords
        public ActionResult Index()
        {
            var borrowRecords = db.BorrowRecords
                .Include(b => b.Book)
                .Include(b => b.Member);

            return View(borrowRecords.ToList());
        }

        // GET: BorrowRecords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            BorrowRecord borrowRecord = db.BorrowRecords.Find(id);

            if (borrowRecord == null)
            {
                return HttpNotFound();
            }

            return View(borrowRecord);
        }

        // GET: BorrowRecords/Create
        public ActionResult Create()
        {
            ViewBag.BookId = new SelectList(db.Books, "Id", "Title");
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name");

            return View();
        }

        // POST: BorrowRecords/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MemberId,BookId,BorrowDate,DueDate,ReturnDate,Status,FineAmount")] BorrowRecord borrowRecord)
        {
            if (ModelState.IsValid)
            {
                db.BorrowRecords.Add(borrowRecord);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.BookId = new SelectList(db.Books, "Id", "Title", borrowRecord.BookId);
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name", borrowRecord.MemberId);

            return View(borrowRecord);
        }

        // GET: BorrowRecords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            BorrowRecord borrowRecord = db.BorrowRecords.Find(id);

            if (borrowRecord == null)
            {
                return HttpNotFound();
            }

            ViewBag.BookId = new SelectList(db.Books, "Id", "Title", borrowRecord.BookId);
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name", borrowRecord.MemberId);

            return View(borrowRecord);
        }

        // POST: BorrowRecords/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MemberId,BookId,BorrowDate,DueDate,ReturnDate,Status,FineAmount")] BorrowRecord borrowRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(borrowRecord).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.BookId = new SelectList(db.Books, "Id", "Title", borrowRecord.BookId);
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name", borrowRecord.MemberId);

            return View(borrowRecord);
        }

        // GET: BorrowRecords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            BorrowRecord borrowRecord = db.BorrowRecords.Find(id);

            if (borrowRecord == null)
            {
                return HttpNotFound();
            }

            return View(borrowRecord);
        }

        // POST: BorrowRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BorrowRecord borrowRecord = db.BorrowRecords.Find(id);

            if (borrowRecord != null)
            {
                db.BorrowRecords.Remove(borrowRecord);
                db.SaveChanges();
            }

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