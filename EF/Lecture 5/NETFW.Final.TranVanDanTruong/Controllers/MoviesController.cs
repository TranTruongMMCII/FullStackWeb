using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NETFW.Final.TranVanDanTruong.Database;
using NETFW.Final.TranVanDanTruong.Models;
using PagedList;

namespace NETFW.Final.TranVanDanTruong.Controllers
{
    public class MoviesController : Controller
    {
        private MovieManagementContext db = new MovieManagementContext();

        // GET: Movies
        public ActionResult Index(string currentFilter, string searchString, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var movies = db.Movies.Include(m => m.Director).Include(m => m.ProductionCompany);

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(a => a.Title.Contains(searchString));
            }

            movies = movies.OrderBy(m=>m.Title);

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(movies.ToPagedList(pageNumber, pageSize));
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            movie.Director = db.Directors.Where(d => d.ID == id).Select(d => d).FirstOrDefault();
            movie.ProductionCompany = db.ProductionCompanies.Where(d => d.ID == id).Select(d => d).FirstOrDefault();
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            ViewBag.DirectorID = new SelectList(db.Directors, "ID", "Name");
            ViewBag.ProductionCompanyID = new SelectList(db.ProductionCompanies, "ID", "Name");
            return View(new Movie());
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Length,Year,PlotOuline,Genre,DirectorID,ProductionCompanyID")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DirectorID = new SelectList(db.Directors, "ID", "Name", movie.DirectorID);
            ViewBag.ProductionCompanyID = new SelectList(db.ProductionCompanies, "ID", "Name", movie.ProductionCompanyID);
            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.DirectorID = new SelectList(db.Directors, "ID", "Name", movie.DirectorID);
            ViewBag.ProductionCompanyID = new SelectList(db.ProductionCompanies, "ID", "Name", movie.ProductionCompanyID);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Length,Year,PlotOuline,Genre,DirectorID,ProductionCompanyID")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DirectorID = new SelectList(db.Directors, "ID", "Name", movie.DirectorID);
            ViewBag.ProductionCompanyID = new SelectList(db.ProductionCompanies, "ID", "Name", movie.ProductionCompanyID);
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            movie.Director = db.Directors.Where(d => d.ID == id).Select(d => d).FirstOrDefault();
            movie.ProductionCompany = db.ProductionCompanies.Where(d => d.ID == id).Select(d => d).FirstOrDefault();
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
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
