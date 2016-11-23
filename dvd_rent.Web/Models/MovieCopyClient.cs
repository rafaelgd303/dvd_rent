using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dvd_rent.Web.Models
{
    public class MovieCopyClient
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Title { get; set; }

        public string SerialNumber { get; set; }

        public DateTime TakeDate { get; set; }

        public DateTime? BackDate { get; set; }
    }
}