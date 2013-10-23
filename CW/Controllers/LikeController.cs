using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CW.Models;

namespace CW.Controllers
{
    public class LikeController : Controller
    {
        private CWContext db = new CWContext();

        //
        // GET: /Like/

        public ActionResult Index()
        {
            var likes = db.Likes.Include(l => l.Post).Include(l => l.User);
            return View(likes.ToList());
        }

        //
        // GET: /Like/Details/5

        public ActionResult Details(int id = 0)
        {
            Like like = db.Likes.Find(id);
            if (like == null)
            {
                return HttpNotFound();
            }
            return View(like);
        }

        //
        // GET: /Like/Create

        public ActionResult Create()
        {
            ViewBag.PostId = new SelectList(db.Posts, "Id", "Content");
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        //
        // POST: /Like/Create

        [HttpPost]
        public ActionResult Create(Like like)
        {
            if (ModelState.IsValid)
            {
                db.Likes.Add(like);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PostId = new SelectList(db.Posts, "Id", "Content", like.PostId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", like.UserId);
            return View(like);
        }

        //
        // GET: /Like/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Like like = db.Likes.Find(id);
            if (like == null)
            {
                return HttpNotFound();
            }
            ViewBag.PostId = new SelectList(db.Posts, "Id", "Content", like.PostId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", like.UserId);
            return View(like);
        }

        //
        // POST: /Like/Edit/5

        [HttpPost]
        public ActionResult Edit(Like like)
        {
            if (ModelState.IsValid)
            {
                db.Entry(like).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PostId = new SelectList(db.Posts, "Id", "Content", like.PostId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", like.UserId);
            return View(like);
        }

        //
        // GET: /Like/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Like like = db.Likes.Find(id);
            if (like == null)
            {
                return HttpNotFound();
            }
            return View(like);
        }

        //
        // POST: /Like/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Like like = db.Likes.Find(id);
            db.Likes.Remove(like);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}