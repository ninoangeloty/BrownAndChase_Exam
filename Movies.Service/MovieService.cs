using Movies.Data;
using Movies.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movies.Common.Extensions;

namespace Movies.Service
{
    public class MovieService : IMovieService
    {
        public MovieService(IUnitOfWork uow)
        {
            this.UnitOfWork = uow;
        }

        public Movie GetById(int id)
        {
            return this.UnitOfWork.MovieRepository.GetById(id);
        }

        public SearchRequest<Movie> GetList()
        {
            var data = new SearchRequest<Movie>();

            data.CurrentPage = 1;
            data.TotalRows = this.UnitOfWork.MovieRepository.GetAll().Count();
            data.Result = this.UnitOfWork.MovieRepository
                .GetAll()                
                .OrderBy(_ => _.Title)
                .Take(PageSize)
                .ToList();

            return data;
        }

        public int Create(Movie movie)
        {
            return this.UnitOfWork.MovieRepository.Create(movie);
        }

        public void Update(Movie movie)
        {
            this.UnitOfWork.MovieRepository.Update(movie);
        }

        public SearchRequest<Movie> Search(string title, int page)
        {
            var data = new SearchRequest<Movie>();

            data.CurrentPage = page;
            data.TotalRows = this.UnitOfWork.MovieRepository
                .GetAll()
                .FilterWhen(() => !string.IsNullOrEmpty(title), _ => _.Title.Contains(title))
                .Count();
            data.Result = this.UnitOfWork.MovieRepository
                .GetAll()
                .FilterWhen(() => !string.IsNullOrEmpty(title), _ => _.Title.Contains(title))
                .OrderBy(_ => _.Title)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToList();
            

            return data;
        }

        public IUnitOfWork UnitOfWork { get; set; }

        private const int PageSize = 10;
    }
}
