using Microsoft.AspNetCore.Mvc;
using SwaggerTest.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SwaggerTest.api.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class MovieController : ControllerBase
    {
        public static List<Movie> Movies { get; set; }

        public MovieController()
        {
            if (Movies == null)
            {
                Movies = new List<Movie>();
            }
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(Movies);
        }

        [HttpGet("{movieId}")]
        public ActionResult Get(string movieId)
        {
            var movie = Movies.FirstOrDefault(x => x.MovieID.Equals(movieId));
            if (movie == null)
            {
                return BadRequest("movie not found");
            }

            return Ok(movie);
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            movie.MovieID = Guid.NewGuid().ToString();
            Movies.Add(movie);

            return Ok(true);
        }

        [HttpGet]
        public ActionResult Delete(string movieId)
        {
            var movie = Movies.FirstOrDefault(x => x.MovieID.Equals(movieId));
            if (movie == null)
            {
                return Ok(false);
            }
            Movies.Remove(movie);
            return Ok(true);
        }
    }
}