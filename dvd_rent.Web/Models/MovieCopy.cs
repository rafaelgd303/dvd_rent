using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dvd_rent.Web.Models
{
    public class MovieCopy
    {
        public int Id { get; set; }

        public int MovieId { get; set; }

        public string Title { get; set; }

        public string SerialNumber { get; set; }

        public DateTime BuyDate { get; set; }

        public DateTime? TrashDate { get; set; }

        public bool IsOnStock { get; set; }
    }
}