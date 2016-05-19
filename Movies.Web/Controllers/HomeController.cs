using AutoMapper;
using Microsoft.Practices.Unity;
using Movies.Service;
using Movies.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movies.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var data = MovieService.GetList();

            var model = new MovieResultViewModel();
            model.CurrentPage = 1;
            model.Movies = data.Result;
            model.TotalPage = data.TotalPages;
            
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(MovieResultViewModel model)
        {
            if (!model.NewSearch)
            {
                model.Search = model.OldSearch;
            }

            model.OldSearch = model.Search;
            var data = MovieService.Search(model.Search, model.CurrentPage);

            model.CurrentPage = model.NewSearch ? 1 : data.CurrentPage;
            model.Movies = data.Result;
            model.TotalPage = data.TotalPages;

            return View(model);
        }

        public ActionResult Create()
        {
            var model = new MovieViewModel();
            model.ReleaseDate = DateTime.Now.Year;
            model.Rating = 5;
            model.Cast = new string[] { };

            return View(model);
        }
        
        [HttpPost]
        public ActionResult Create(MovieViewModel model)
        {
            if (ModelState.IsValid)
            {
                MovieService.Create(Mapper.Map<Movie>(model));
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var model = Mapper.Map<MovieViewModel>(MovieService.GetById(id));

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(MovieViewModel model)
        {
            if (ModelState.IsValid)
            {
                MovieService.Update(Mapper.Map<Movie>(model));
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [Dependency]
        public IMovieService MovieService { get; set; }
    }
}