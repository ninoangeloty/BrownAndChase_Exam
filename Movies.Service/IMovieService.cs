using Movies.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Service
{
    public interface IMovieService
    {
        Movie GetById(int id);
        SearchRequest<Movie> GetList();
        int Create(Movie movie);
        void Update(Movie movie);
        SearchRequest<Movie> Search(string title, int page);
    }
}
