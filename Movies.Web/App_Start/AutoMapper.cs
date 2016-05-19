using AutoMapper;
using Movies.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movies.Web
{
    public static class AutoMapper
    {
        public static void InitializeMap()
        {
            Mapper.Initialize(_ =>
            {
                _.CreateMap<Movie, MovieViewModel>();
                _.CreateMap<MovieViewModel, Movie>();
            });
        }
    }
}