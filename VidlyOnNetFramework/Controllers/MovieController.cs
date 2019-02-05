using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyOnNetFramework.Models;
using System.Data.Entity.Validation;

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
            if (User.IsInRole(RoleName.CanManageMovie))
            {
                return View("Movie");
            }
            return View("ReadOnlyList");
        }

        [Authorize(Roles = RoleName.CanManageMovie)]
        // GET: Movie/New
        public ActionResult New()
        {
            var genreTypes = _context.GenreTypes.ToList();
            var viewModel = new NewMovieViewModel(genreTypes);

            
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // GET: Movie/Save
        public ActionResult Save(Movie movie)
        {
            //Add Validation
            if (!ModelState.IsValid)
            {
                var genreType = _context.GenreTypes.ToList();
                var viewModel = new NewMovieViewModel(movie, genreType);
                return View("MovieForm", viewModel);
            }

            //New Movie
            if(movie.ID == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var existingMovie = _context.Movies.Single(m => m.ID == movie.ID);
                existingMovie.Name = movie.Name;
                existingMovie.ReleaseDate = movie.ReleaseDate;
                existingMovie.NumInStock = movie.NumInStock;
            }

            try
            {
               _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
            return RedirectToAction("Movie", "Movie");
        }

        [Route("Movie/Edit/{id}")]
        // GET: Movie/Edit/
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.ID == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            else
            {
                var genreTypes = _context.GenreTypes.ToList();
                var viewModel = new NewMovieViewModel(movie, genreTypes);
                return View("MovieForm", viewModel);
            }
        }

        

        
    }
}