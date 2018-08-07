using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!"};

            var customers = new List<Customer>
            {
                new Customer {Name = "Customer1"},
                new Customer() {Name = "Customer2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            

            //these are broken, terrible methods. don't use them
            //ViewData["RandomMovie"] = movie;
            //ViewBag.Movie = movie;

                return View(viewModel);
            //    return Content("Hello World"
            //    return HttpNotFound();
            //    return new EmptyResult();
            //    return RedirectToAction("Index", "Home", new { page = 1, sortBy = "Name"});

        }

        public ActionResult Edit(int id)
        {
            return Content("id=" +id);
        }

        //movies
        [Route("Movies")]
        public ViewResult Index()
        {
            var movies = GetMovies();

           
            return View(movies);

        }

        //attributes routing
        [Route("movies/release/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content($"{year}/{month}");
        }

        public IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>()
            {
                new Movie{Id = 1, Name = "Shrek"},
                new Movie{Id = 2, Name = "Wall-E"}
            };
        }
    }
}