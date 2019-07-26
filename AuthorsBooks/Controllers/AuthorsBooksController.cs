using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using AutoMapper;
using BLL;
using DAL.Entity;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AuthorsBooks.Controllers
{
    public class AuthorsBooksController : Controller
    {
        private readonly IAuthorsBooksService _authorsBooksService;
      
        public AuthorsBooksController(IAuthorsBooksService authorsBooksService)
        {
            _authorsBooksService = authorsBooksService;
        }

        public IActionResult AddPage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthorsBooks(AuthorsBooksModel authorsBooks)
        {
            await _authorsBooksService.CreateAuthorsBooks(authorsBooks);
            return Redirect("~/Home/Index");
        }
        
        public async Task<IActionResult> FindAuthorBooks(AuthorModel author)
        {
            IEnumerable<BookModel> bookModels =  await _authorsBooksService.FindAuthorsBooks(author);
            TempData.Put("key", bookModels);
            return RedirectToAction("ShowAllPage", "Author");
        }
    }
}