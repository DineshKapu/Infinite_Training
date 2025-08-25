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
            repo.Add(movie);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id) => View(repo.GetById(id));
        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            repo.Update(movie);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id) => View(repo.GetById(id));
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult MoviesByYear(int year) => View(repo.GetByYear(year));
        public ActionResult MoviesByDirector(string directorName) => View(repo.GetByDirector(directorName));

    }
}