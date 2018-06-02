using Audio_Junction.Models;
using Audio_Junction.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Audio_Junction.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context;


        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Movies
        public ActionResult Index()
        {
            //var movie = _context.Movies.ToList();

            //return View(movie);

            if (User.IsInRole(RoleName.CanMangeMovies))
                return View("Index");

            return View("ReadOnlyList");

        }

        public ActionResult Details(int id)
        {
            var movies = _context.Movies.SingleOrDefault(m => m.ID == id);

            return View(movies);
        }




        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }



        [Authorize(Roles = RoleName.CanMangeMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.ID == id);

            if (movie == null)
                return HttpNotFound();

            var movieViewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genre = _context.Genre.ToList()
            };


            return View("MovieForm", movieViewModel);
        }


        [Authorize(Roles = RoleName.CanMangeMovies)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    Genre = _context.Genre.ToList()

                };

                return View("MovieForm", viewModel);

            }



            if (movie.ID == 0)
            {
                //movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);

            }

            else
            {
                var movieInDb = _context.Movies.Single(m => m.ID == movie.ID);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.Genre = movie.Genre;
                movieInDb.NumberInStock = movie.NumberInStock;

            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");

        }

        [Authorize(Roles = RoleName.CanMangeMovies)]
        public ViewResult New()
        {

            var genres = _context.Genre.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genre = genres
            };

            return View("MovieForm", viewModel);
        }

    }
}