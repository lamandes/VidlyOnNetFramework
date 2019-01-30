using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyOnNetFramework.Models;

namespace VidlyOnNetFramework.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("Movie")]
        // GET: Movie
        public ActionResult Movie()
        {
            //List<Movie>
            var movieList = _context.Movies.Include(c=> c.GenreType).ToList();
            var viewModel = new MovieViewModel
            {
                MovieList = movieList
            };
            return View(viewModel);
        }

        [Route("Movie/Details/{id}")]
        public ActionResult Detail(int id)
        {
            var movie = _context.Movies.Include(c=> c.GenreType).SingleOrDefault(c => c.ID == id);

            return View(movie);
        }
    }
}