using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Common;
using DataExtensions;
using Microsoft.AspNetCore.Mvc;

namespace AuthorsBooks.Controllers
{
  public class AuthorController : Controller
  {
    private readonly IAuthorService _authorService;
    private readonly IAuthorsBooksService _authorsBooksService;
    private ShowModel _paginatedProperties;

    public AuthorController(IAuthorService authorService, IAuthorsBooksService authorsBooksService)
    {
      _authorService = authorService;
      _authorsBooksService = authorsBooksService;
      IEnumerable<AuthorModel> wallets = _authorService.GetAllAuthors().Result;

    }

    // Get /Views/Author/AddPage
    public IActionResult AddPage()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddAuthor(AuthorModel obj)
    {
      await _authorService.CreateAuthor(obj);
      return Redirect("ShowAllPage");
    }

    // Get /Views/Author/ShowAllPage
    [HttpGet]
    public async Task<IActionResult> ShowAllPage(ShowModel paginatedProperties)
    {
      _paginatedProperties = await _authorService.Search(paginatedProperties);

      if (!string.IsNullOrEmpty(_paginatedProperties.SortField))
      {
        return View(SortAuthorsData(_paginatedProperties));
      }

      return View(_paginatedProperties);
    }

    [HttpGet]
    public async Task<ActionResult> Search(ShowModel paginatedProperties)
    {
      _paginatedProperties = await _authorService.Search(paginatedProperties);
      return PartialView("_AuthorsList", _paginatedProperties);
    }

    private ShowModel SortAuthorsData(ShowModel paginatedProperties)
    {
      if (string.IsNullOrEmpty(paginatedProperties.SortField))
      {
        return null;
      }
      else
      {
        if (paginatedProperties.CurrentSortField == paginatedProperties.SortField)
        {
          ViewBag.SortOrder = paginatedProperties.CurrentSortOrder == "Asc" ? "Desc" : "Asc";
        }
        else
        {
          ViewBag.SortOrder = "Asc";
        }
        ViewBag.SortField = paginatedProperties.SortField;
      }

      var propertyInfo = typeof(AuthorModel).GetProperty(ViewBag.SortField);

      paginatedProperties.Authors = ViewBag.SortOrder == "Asc"
          ?
          paginatedProperties.Authors.OrderBy(s => propertyInfo.GetValue(s, null))
          :
          paginatedProperties.Authors.OrderByDescending(s => propertyInfo.GetValue(s, null));

      return paginatedProperties;
    }

    [HttpPost]
    public async Task<IActionResult> EditPage(string id)
    {
      try
      {
        if (string.IsNullOrEmpty(id))
        {
          return RedirectToAction("ShowAllPage", "Author");
        }
        AuthorModel author = await _authorService.GetAuthorById(Convert.ToInt32(id));
        return PartialView("EditPage", author);
      }
      catch (Exception)
      {
        throw;
      }
    }

    [HttpPost]
    public async Task<IActionResult> SaveChanges(AuthorModel obj)
    {
      await _authorService.UpdateAuthor(obj);
      return RedirectToAction("ShowAllPage");
    }

    [HttpPost]
    public async Task<IActionResult> ShowAuthorBooks(string id)
    {
      AuthorModel author = await _authorService.GetAuthorById(Convert.ToInt32(id));
      IEnumerable<BookModel> bookModels = await _authorsBooksService.FindAuthorsBooks(author);
      return PartialView("_ShowBooks", bookModels);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(string id)
    {
      await _authorService.RemoveAuthor(Convert.ToInt32(id));
      return new EmptyResult();
      //return Json(new { IsProcessDone = true, ProcessMessage = "success" });
    }
  }
}