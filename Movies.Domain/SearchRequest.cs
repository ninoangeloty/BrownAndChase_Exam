using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain
{
    public class SearchRequest<TModel> where TModel : class, new()
    {
        public int CurrentPage { get; set; }
        public int TotalRows { get; set; }
        public int TotalPages 
        {
            get
            {
                if (TotalRows == 0) 
                {
                    return 1; 
                }

                return ((TotalRows - 1) / 10) + 1;
            }
        }
        public List<TModel> Result { get; set; }
    }
}
