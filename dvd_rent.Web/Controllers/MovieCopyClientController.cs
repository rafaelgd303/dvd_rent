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
    public class MovieCopyClientController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetMoviesCopyClient()
        {
            var connectionString =
                ConfigurationManager
                .ConnectionStrings["DefaultConnection"]
                .ConnectionString;

            var moviesCopyClient = new List<MovieCopyClient>();
            using (var connection = new SqlConnection(connectionString))
            {
                moviesCopyClient = connection.Query<MovieCopyClient>(
                    @"select mcc.Id, c.FirstName, c.LastName, m.Title, mc.SerialNumber, mcc.TakeDate, mcc.BackDate 
                        from [dbo].[MovieCopyClient] mcc
                        join [dbo].[Client] c on c.Id = mcc.ClientId
                        join [dbo].[MovieCopy] mc on mc.Id = mcc.MovieCopyId
                        join [dbo].[Movie] m on m.Id = mc.MovieId"
                ).ToList();
            }

            return Ok(moviesCopyClient);
        }

        [HttpPost]
        public IHttpActionResult GetBackMovie(CopyClientMovieViewModel model)
        {
            var connectionString =
                ConfigurationManager
                .ConnectionStrings["DefaultConnection"]
                .ConnectionString;

            var moviesCopyClient = new List<MovieCopyClient>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(
                    @"update [dbo].[MovieCopyClient] set backdate = GETDATE()
                        where id = @Id",
                    new
                    {
                        Id = model.Id,
                    }
                );

                int movieCopyId = (int)connection.ExecuteScalar(@"select [MovieCopyId] from MovieCopyClient where id = @Id",
                    new
                    {
                        Id = model.Id
                    });

                connection.Execute(
                    @"update [dbo].[MovieCopy] 
                        set isonstock = 1 
                      where id = @id",
                    new
                    {
                        id = movieCopyId,
                    }
                );
            }

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult RentMovie(CopyClientMovieViewModel model)
        {
            var connectionString =
                ConfigurationManager
                .ConnectionStrings["DefaultConnection"]
                .ConnectionString;

            var moviesCopyClient = new List<MovieCopyClient>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(
                    @"insert into [dbo].[MovieCopyClient] 
                        ([ClientId], [MovieCopyId], [TakeDate])
                        values (@ClientId, @MovieCopyId, @TakeDate)",
                    new
                    {
                        ClientId = model.ClientId,
                        MovieCopyId = model.MovieId,
                        TakeDate = DateTime.Now,
                    }
                );

                connection.Execute(
                    @"update [dbo].[MovieCopy] 
                        set isonstock = 0 
                      where id = @id",
                    new
                    {
                        id = model.MovieId,
                    }
                );
            }

            return Ok();
        }

        [HttpGet]
        [Route("api/clientCopies")]
        public IHttpActionResult GetClientCopies(int? clientId)
        {
            var connectionString =
                ConfigurationManager
                .ConnectionStrings["DefaultConnection"]
                .ConnectionString;

            var moviesCopyClient = new List<MovieCopyClient>();
            using (var connection = new SqlConnection(connectionString))
            {
                moviesCopyClient = connection.Query<MovieCopyClient>(
                    @"select mcc.Id, c.FirstName, c.LastName, m.Title, mc.SerialNumber, mcc.TakeDate, mcc.BackDate 
                        from [dbo].[MovieCopyClient] mcc
                        join [dbo].[Client] c on c.Id = mcc.ClientId
                        join [dbo].[MovieCopy] mc on mc.Id = mcc.MovieCopyId
                        join [dbo].[Movie] m on m.Id = mc.MovieId
                      where @clientId is null or mcc.ClientId = @clientId",
                    new
                    {
                        clientId,
                    }
                ).ToList();
            }

            return Ok(moviesCopyClient.Select(c => new
            {
                id = c.Id,
                text = $"{c.Title} (ser: {c.SerialNumber}, take date: {c.TakeDate.ToString("yyyy-MM-dd")}",
            }));


        }
    }
}