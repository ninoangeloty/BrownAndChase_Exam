using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movies.Web.Models
{
    public class MovieResultViewModel
    {
        public List<Movie> Movies { get; set; }
        public string Search { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        [IgnoreMap]
        public bool NewSearch { get; set; }
        [IgnoreMap]
        public string OldSearch { get; set; }
    }
}