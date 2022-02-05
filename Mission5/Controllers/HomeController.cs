using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission5.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission5.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext Context { get; set; }
        public HomeController(MovieContext Temp)
        {
            Context = Temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcast()
        {
            return View("MyPodcast");
        }
        [HttpGet]
        public IActionResult MovieInfo()
        {
            ViewBag.Categories = Context.Categories.ToList();

            return View();
        }
        [HttpPost]
        public IActionResult MovieInfo(MovieInfo ar)
        {
            if (ModelState.IsValid)
            {
                Context.Add(ar);
                Context.SaveChanges();

                return View("Confirmation", ar);
            }
            else
            {
                ViewBag.Categories = Context.Categories.ToList();

                return View(ar);
            }
        }
        public IActionResult MovieCollection()
        {
            var applications = Context.MovieInfo.
                Include(x => x.Category).
                ToList();

            return View(applications);
        }
        [HttpGet]
        public IActionResult Edit (string title)
        {
            ViewBag.Categories = Context.Categories.ToList();

            var info = Context.MovieInfo.Single (x => x.Title == title);

            return View("MovieInfo", info);
        }

        [HttpPost]
        public IActionResult Edit (MovieInfo blah)
        {
            Context.Update(blah);
            Context.SaveChanges();

            return RedirectToAction("MovieCollection");
        }
        [HttpGet]
        public IActionResult Delete(string title)
        {
            var info = Context.MovieInfo.Single(x => x.Title == title);

            return View(info);
        }
        
        [HttpPost]
        public IActionResult Delete (MovieInfo ar)
        {
            Context.MovieInfo.Remove(ar);
            Context.SaveChanges();

            return RedirectToAction("MovieCollection");
        }

    }
}
