using Audio_Junction.Dtos;
using Audio_Junction.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;

namespace Audio_Junction.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }


        //GET api/Movies

        public IEnumerable<MoviesDto> GetMovies(string query = null)
        {
            var moviesQuery = _context.Movies
                .Include(m => m.Genre)
                .Where(m => m.NumberAvailable > 0);

                if (!String.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));   

                return moviesQuery
                .ToList()
                .Select(Mapper.Map<Movie, MoviesDto>);



        }

        //Get api/Movies/1

        public IHttpActionResult GetMovies(int id)
        {

            var movies = _context.Movies.SingleOrDefault(m => m.ID == id);

            if (movies == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MoviesDto>(movies));

        }



        //Post api/Movies
        [HttpPost]
        [Authorize(Roles = RoleName.CanMangeMovies)]
        public IHttpActionResult CreateMovies(MoviesDto moviesDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            var movies = Mapper.Map<MoviesDto, Movie>(moviesDto);

            _context.Movies.Add(movies);
            _context.SaveChanges();

            moviesDto.ID = movies.ID;


            return Created(new Uri(Request.RequestUri + "/" + movies.ID), moviesDto);

        }


        //Put api/Movies
        [HttpPut]
        [Authorize(Roles = RoleName.CanMangeMovies)]
        public void UpdateMovies(int id, MoviesDto moviesDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var moviesInDb = _context.Movies.SingleOrDefault(c => c.ID == id);

            if (moviesInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(moviesDto, moviesInDb);

            moviesInDb.Name = moviesDto.Name;
            moviesInDb.NumberInStock = moviesDto.NumberInStock;
            moviesInDb.ReleaseDate = moviesDto.ReleaseDate;
            moviesInDb.GenreId = moviesDto.GenreId;

            _context.SaveChanges();

        }


        //Delete api/Movies

        [HttpDelete]
        [Authorize(Roles = RoleName.CanMangeMovies)]
        public void DeleteMovies(int id)
        {

            var moviesInDb = _context.Movies.SingleOrDefault(c => c.ID == id);

            if (moviesInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(moviesInDb);

            _context.SaveChanges();

        }

    }
}
