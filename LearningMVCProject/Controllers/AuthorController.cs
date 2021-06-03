using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningMVCProject.Models;
using Microsoft.Extensions.Logging;
using LearningMVCProject.Services;

namespace LearningMVCProject.Controllers
{
    public class AuthorController : Controller
    {
        private ILogger<AuthorController> _logger;
        private IRepo<Author> _repo;

        public AuthorController(IRepo<Author> repo, ILogger<AuthorController> logger)
        {
            _repo = repo;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Author> authors = _repo.GetAll().ToList();
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Author author)
        {
            _repo.Add(author);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            Author author = _repo.Get(id);
            return View(author);
        }
        [HttpPost]
        public IActionResult Edit(int id,Author author)
        {
            _repo.Update(id, author);
            return RedirectToAction("Index");
        }

    }
}
