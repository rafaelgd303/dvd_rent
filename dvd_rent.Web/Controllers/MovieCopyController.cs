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
    public class nowy : ApiController
    {
        

    }
    public class MovieCopyController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetMoviesCopies()
        {
            var connectionString = ConfigurationManager
                .ConnectionStrings["DefaultConnection"]
                .ConnectionString;

            var moviesCopies = new List<MovieCopy>();
            using (var connection = new SqlConnection(connectionString))
            {
                moviesCopies = connection.Query<MovieCopy>(
                    @"Select * From MovieCopy c 
                        join movie m on m.id = c.movieid"
                ).ToList();
            }

            return Ok(moviesCopies);
        }

        [HttpPut]
        public IHttpActionResult Save(MovieCopyViewModel model)
        {
            var connectionString =
                ConfigurationManager
                .ConnectionStrings["DefaultConnection"]
                .ConnectionString;

            var moviesCopyClient = new List<MovieCopyClient>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(
                    @"insert into [dbo].[MovieCopy] 
                        ([MovieId], [SerialNumber], [BuyDate], [IsOnStock])
                        values (@MovieId, @SerialNumber, @BuyDate, @IsOnStock)",
                    new
                    {
                        MovieId = model.MovieId,
                        SerialNumber = model.SerialNumber,
                        BuyDate = DateTime.Now,
                        IsOnStock = 1,
                    }
                );
            }

            return Ok();
        }
    }
}