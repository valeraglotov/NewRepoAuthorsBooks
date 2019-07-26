using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Common;
using AutoMapper;
using BLL;
using DAL.Entity;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AuthorsBooks.Controllers
{
    public class BooksController : Controller
    {
       private readonly IBookService _bookService;
        
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        public IActionResult AddPage()
        {
            return View();
        }

        public IActionResult ShowAllPage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BookModel book)
        {
            await _bookService.CreateBook(book);
            return Redirect("ShowAllPage");
        }

        public async Task<IActionResult> LoadData()
        {
            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
                // Skiping number of Rows count
                var start = Request.Form["start"].FirstOrDefault();
                // Paging Length 10,20
                var length = Request.Form["length"].FirstOrDefault();
                // Sort Column Name
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                // Sort Column Direction ( asc ,desc)
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                // Search Value from (Search box)
                var searchValue = Request.Form["search[value]"].FirstOrDefault();

                //Paging Size (10,20,50,100)
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                IEnumerable<BookModel> list = await _bookService.GetAllBooks();
                IQueryable<BookModel> books = new EnumerableQuery<BookModel>(list.ToList());
                //Sorting
                if (!(string.IsNullOrEmpty(sortColumn) || string.IsNullOrEmpty(sortColumnDirection)))
                {
                    var type = typeof(BookModel);
                    var property = type.GetProperty(sortColumn);
                    var parameter = Expression.Parameter(type, "p");
                    var propertyAccess = Expression.MakeMemberAccess(parameter, property);
                    var orderByExp = Expression.Lambda(propertyAccess, parameter);
                    MethodCallExpression resultExp = Expression.Call(typeof(Queryable),
                        sortColumnDirection == "desc" ? "OrderByDescending" : "OrderBy",
                        new Type[] { type, property.PropertyType },
                        books.Expression, Expression.Quote(orderByExp));

                    books = books.Provider.CreateQuery<BookModel>(resultExp);
                }
                //Search
                if (!string.IsNullOrEmpty(searchValue))
                {
                    books = books.Where
                        (m => m.Publisher.ToString() == searchValue || m.Name == searchValue);
                }

                //total number of rows count 
                recordsTotal = books.Count();
                //Paging 
                var data = books.Skip(skip).Take(pageSize).ToList();
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return RedirectToAction("Index", "Home");
                }
                await _bookService.RemoveBook(Convert.ToInt32(id));
                return View("ShowAllPage");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}