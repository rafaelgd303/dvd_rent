using Dapper;
using dvd_rent.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dvd_rent.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            /*
            var connectionString = 
                ConfigurationManager
                .ConnectionStrings["DefaultConnection"]
                .ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                var clients = connection.Query<Client>(
                    "Select * From client");
            }
            */
            return View();
        }
    }
}
