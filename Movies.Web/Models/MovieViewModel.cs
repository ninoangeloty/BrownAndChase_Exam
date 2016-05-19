using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movies.Web.Models
{
    public class MovieViewModel
    {
        [Required(ErrorMessage = "{0} is required.")]
        public string[] Cast { get; set; }
        [Required(ErrorMessage = "{0} is required.")]
        public string Classification { get; set; }
        [Required(ErrorMessage = "{0} is required.")]
        public string Genre { get; set; }
        public int MovieId { get; set; }
        [Range(1, 5)]
        [Required(ErrorMessage = "{0} is required.")]
        public int Rating { get; set; }
        [DisplayName("Release Date (Year)")]
        [Required(ErrorMessage = "{0} is required.")]
        public int ReleaseDate { get; set; }
        [Required(ErrorMessage = "{0} is required.")]
        public string Title { get; set; }
    }
}