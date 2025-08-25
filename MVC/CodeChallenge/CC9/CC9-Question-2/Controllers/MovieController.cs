using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CC9_Question_2.Models;
using CC9_Question_2.Data;
using CC9_Question_2.Repository;
namespace CC9_Question_2.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository repo = new MovieRepository();
        // GET: Movie
        public ActionResult Index()
        {
            return View(repo.GetAll());
        }
        public ActionResult Create() => View();
        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                repo.Add(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public ActionResult Edit(int id) => View(repo.GetById(id));
        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                repo.Update(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public ActionResult Delete(int id)
        {
            var movie = repo.GetById(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult SearchByYear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchByYear(int year)
        {
            return RedirectToAction("MoviesByYear", new { year });
        }
        public ActionResult MoviesByYear(int year)
        {
            var movies = repo.GetByYear(year);
            ViewBag.Year = year;
            return View(movies);
        }

        public ActionResult SearchByDirector()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchByDirector(string directorName)
        {
            return RedirectToAction("MoviesByDirector", new { directorName });
        }

        public ActionResult MoviesByDirector(string directorName)
        {
            var movies = repo.GetByDirector(directorName);
            ViewBag.Director = directorName;
            return View(movies);
        }

    }
}