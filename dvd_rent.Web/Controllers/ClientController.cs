using Dapper;
using dvd_rent.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace dvd_rent.Web.Controllers
{
    public class ClientController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetClients()
        {
            var connectionString =
                ConfigurationManager
                .ConnectionStrings["DefaultConnection"]
                .ConnectionString;

            var clients = new List<Client>();
            using (var connection = new SqlConnection(connectionString))
            {
                clients = connection.Query<Client>("Select * From client").ToList();
            }

            return Ok(clients);
        }

        [HttpGet]
        [Route("api/listClients")]
        public IHttpActionResult GetClients(string search)
        {
            var connectionString =
                ConfigurationManager
                .ConnectionStrings["DefaultConnection"]
                .ConnectionString;

            var clients = new List<Client>();
            using (var connection = new SqlConnection(connectionString))
            {
                clients = connection.Query<Client>(
                    "Select * From client where FirstName like '%' + @search + '%' or LastName like '%' + @search + '%'",
                    new
                    {
                        search
                    }).ToList();
                clients = connection.Query<Client>("Select * From client").ToList();
            }

            return Ok(clients.Select(c => new
            {
                id = c.Id,
                text = $"{c.LastName} {c.FirstName}",
            }));
        }
    }
}