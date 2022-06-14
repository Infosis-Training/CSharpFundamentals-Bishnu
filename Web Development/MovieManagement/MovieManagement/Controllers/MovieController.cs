﻿using Microsoft.AspNetCore.Mvc;
using MovieManagement.Data;
using MovieManagement.Models;
using System.Collections.Generic;

namespace MovieManagement.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieManagementDb _db;

        public MovieController(MovieManagementDb db) // Dependency Injection
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var movies = _db.Movies.ToList();

            ViewBag.Names = new List<string> { "Bishnu", "Ram" };
            ViewData["Names"] = new List<string> { "Bishnu", "Ram" };

            return View(movies);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Movie movie)
        {
            movie.Code = Guid.NewGuid().ToString();

            _db.Movies.Add(movie);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movieToEdit = _db.Movies.Find(id);
            return View(movieToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {   
            _db.Movies.Update(movie);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
