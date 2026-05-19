using LibraryManagementSystem.Data;
using LibraryManagementSystem.Filters;
using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace LibraryManagementSystem.Controllers
{
    [CustomAuthorize]
    public class FeedbacksController : Controller
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

        // GET: Feedbacks
        public ActionResult Index()
        {
            var feedbacks = db.Feedbacks
                .Include(f => f.Book)
                .Include(f => f.Member);

            return View(feedbacks.ToList());
        }

        // GET: Feedbacks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Feedback feedback = db.Feedbacks.Find(id);

            if (feedback == null)
            {
                return HttpNotFound();
            }

            return View(feedback);
        }

        // GET: Feedbacks/Create
        public ActionResult Create()
        {
            ViewBag.BookId = new SelectList(db.Books, "Id", "Title");
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name");

            return View();
        }

        // POST: Feedbacks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MemberId,BookId,Rating,Comment")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                feedback.FeedbackDate = DateTime.Now;

                db.Feedbacks.Add(feedback);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.BookId = new SelectList(db.Books, "Id", "Title", feedback.BookId);
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name", feedback.MemberId);

            return View(feedback);
        }

        // GET: Feedbacks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Feedback feedback = db.Feedbacks.Find(id);

            if (feedback == null)
            {
                return HttpNotFound();
            }

            ViewBag.BookId = new SelectList(db.Books, "Id", "Title", feedback.BookId);
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name", feedback.MemberId);

            return View(feedback);
        }

        // POST: Feedbacks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MemberId,BookId,Rating,Comment,FeedbackDate")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feedback).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.BookId = new SelectList(db.Books, "Id", "Title", feedback.BookId);
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name", feedback.MemberId);

            return View(feedback);
        }

        // GET: Feedbacks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Feedback feedback = db.Feedbacks.Find(id);

            if (feedback == null)
            {
                return HttpNotFound();
            }

            return View(feedback);
        }

        // POST: Feedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Feedback feedback = db.Feedbacks.Find(id);

            if (feedback != null)
            {
                db.Feedbacks.Remove(feedback);
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