using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data
{
    public interface IUnitOfWork
    {
        IMovieRepository MovieRepository { get; set; }
    }
}
