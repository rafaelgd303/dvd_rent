using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dvd_rent.Web.ViewModels
{
    public class CopyClientMovieViewModel
    {
        public int Id { get; set; }

        public int MovieId { get; set; }

        public int ClientId { get; set; }
    }
}