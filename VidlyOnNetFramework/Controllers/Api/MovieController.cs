using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using VidlyOnNetFramework.Dtos;
using VidlyOnNetFramework.Models;

namespace VidlyOnNetFramework.Controllers.Api
{
    public class MovieController : ApiController
    {
        //Database context
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool isDisposing)
        {
            _context.Dispose();
        }

        //GET /api/Movie
        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movies
                .Include(m => m.GenreType)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
        }

        //GET /api/Movie/1
        public MovieDto GetMovies(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.ID == id);
            if (movie == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            //Return MovieDto
            return Mapper.Map<Movie, MovieDto>(movie);
        }

        //POST /api/Movie
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            //Form submit is invalid 
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //Save new movie to db
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            //Get current db movie  ID
            movieDto.ID = movie.ID;

            //Return Uri as http status 201 instead of 200
            return Created(new Uri(Request.RequestUri + "/" + movie.ID), movieDto);
        }

        //PUT Update movie
        [HttpPut]
        public IHttpActionResult UpdateMovie(MovieDto movieDto)
        {
            //Get exisiting movie
            var existingMovie = _context.Movies.SingleOrDefault(m => m.ID == movieDto.ID);
            if (existingMovie == null)
            {
                return BadRequest();
            }

            //Update existing movie with automap
            Mapper.Map(movieDto, existingMovie);
            _context.SaveChanges();
            existingMovie.ID = movieDto.ID;
            return Created(new Uri(Request.RequestUri + "/" + existingMovie.ID), movieDto);
        }

        //PUT Update movie
        [HttpDelete]
        //public void DeleteMovie(MovieDto movieDto)
        public void DeleteMovie(int id, Movie movie)
        {
            //Get exisiting movie
            var existingMovie = _context.Movies.SingleOrDefault(m => m.ID == id);
            if (existingMovie == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            //Update existing movie with automap
            _context.Movies.Remove(existingMovie);
            _context.SaveChanges();
        }
    }
}
