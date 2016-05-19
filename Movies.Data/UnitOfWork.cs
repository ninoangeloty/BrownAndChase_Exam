using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IMovieRepository repository)
        {
            this.MovieRepository = repository;
        }

        public IMovieRepository MovieRepository { get; set; }
    }
}
