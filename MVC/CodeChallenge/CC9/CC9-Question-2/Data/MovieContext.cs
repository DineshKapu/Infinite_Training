using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CC9_Question_2.Models;
namespace CC9_Question_2.Data
{
    public class MovieContext:DbContext
    {
        public MovieContext() : base("MoviesDBContext")
        { }
        public DbSet<Movie> Movies { get; set; }

    }
}