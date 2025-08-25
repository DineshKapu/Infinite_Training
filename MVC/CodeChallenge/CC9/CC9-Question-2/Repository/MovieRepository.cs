using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CC9_Question_2.Models;
using CC9_Question_2.Data;
namespace CC9_Question_2.Repository
{
    public class MovieRepository:IMovieRepository
    {
        private readonly MovieContext db = new MovieContext();
        public void Add(Movie movie)
        {
            db.Movies.Add(movie);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
        }

        public IEnumerable<Movie> GetAll() => db.Movies.ToList();

        public IEnumerable<Movie> GetByDirector(string directorName) => db.Movies.Where(m => m.DirectorName == directorName).ToList();



        public Movie GetById(int id) => db.Movies.Find(id);

        public IEnumerable<Movie> GetByYear(int year) => db.Movies.Where(m => m.DateOfRelease.Year == year).ToList();


        public void Update(Movie movie)
        {
            db.Entry(movie).State = EntityState.Modified;
            db.SaveChanges();
        }

    }
}