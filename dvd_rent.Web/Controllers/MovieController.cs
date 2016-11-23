using Dapper;
using dvd_rent.Web.Models;
using dvd_rent.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace dvd_rent.Web.Controllers
{
    public class MovieController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetMovies()
        {
            var connectionString =
                ConfigurationManager
                .ConnectionStrings["DefaultConnection"]
                .ConnectionString;

            var movies = new List<Movie>();
            using (var connection = new SqlConnection(connectionString))
            {
                movies = connection.Query<Movie>("Select * From movie order by Id").ToList();
            }

            return Ok(movies);
        }

        [HttpGet]
        [Route("api/listMovies")]
        public IHttpActionResult GetMovies(string search)
        {
            var connectionString =
                ConfigurationManager
                .ConnectionStrings["DefaultConnection"]
                .ConnectionString;

            var movies = new List<MovieCopy>();
            using (var connection = new SqlConnection(connectionString))
            {
                movies = connection.Query<MovieCopy>(
                    @"Select mc.id, m.Title, mc.SerialNumber, mc.IsOnStock from MovieCopy mc
                        left join Movie m on mc.MovieId = m.Id
                       where m.Title like '%' + @search + '%'
                       order by 2", new
                    {
                        search = search
                    }).ToList();
            }

            return Ok(movies.Select(m => new
            {
                id = m.Id,
                text = $"{m.Title} (serial: {m.SerialNumber})",
                disabled = !m.IsOnStock,
            }));
        }

        [HttpPut]
        public IHttpActionResult SaveMovie(MovieViewModel model)
        {
            var connectionString =
                ConfigurationManager
                .ConnectionStrings["DefaultConnection"]
                .ConnectionString;

            var moviesCopyClient = new List<MovieCopyClient>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(
                    @"insert into [dbo].[Movie] 
                        ([title])
                        values (@Title)",
                    model
                );
            }

            return Ok();
        }
    }
}