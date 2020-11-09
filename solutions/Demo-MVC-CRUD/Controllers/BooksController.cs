using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demo_MVC_CRUD.Data;
using Demo_MVC_CRUD.Models;

namespace Demo_MVC_CRUD.Controllers
{
    public class BooksController : Controller
    {
        private LibraryContext context = new LibraryContext();

        // GET: /books/index
        [HttpGet]
        public ActionResult Index()
        {
            ViewData["books"] = context.Books.Include(x => x.Author).ToList();

            return View();
        }

        // GET: /books/details/{id}
        [HttpGet]
        public ActionResult Details(int id)
        {
            var book = context.Books.Include(x => x.Author).FirstOrDefault(x => x.Id == id);

            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }

        // GET: /books/create
        [HttpGet]
        public ActionResult Create()
        {
            var authors = context.Author.Select(x => new
            {
                AuthorId = x.Id,
                AuthorName = x.FirstName + " " + x.LastName
            }).ToList();

            ViewBag.Authors = new SelectList(authors, "AuthorId", "AuthorName");

            return View();
        }

        // POST: /books/create
        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                context.Books.Add(book);

                context.SaveChanges();

                return RedirectToAction("Index", "Books");
                //return Redirect("Index");
                //return View("Index");
            }

            var authors = context.Author.Select(x => new
            {
                AuthorId = x.Id,
                AuthorName = x.FirstName + " " + x.LastName
            }).ToList();

            ViewBag.Authors = new SelectList(authors, "AuthorId", "AuthorName", book.AuthorId);

            return View(book);
        }

        // GET: /books/edit/{id}
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var book = context.Books.Find(id);
            //var book = context.Books.Where(x => x.Id == id);

            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }

        // POST: /books/edit
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var oldBook = context.Books.Find(book.Id);

                    if (oldBook == null)
                    {
                        return HttpNotFound();
                    }

                    oldBook.Title = book.Title;
                    oldBook.Author = book.Author;
                    oldBook.Publisher = book.Publisher;
                    oldBook.Year = book.Year;
                    oldBook.Description = book.Description;

                    TryUpdateModel(oldBook);

                    context.SaveChanges();

                    return RedirectToAction("Index", "Books");
                }
            }
            catch (Exception e)
            {
                return Json(new {error_message = e.Message}, JsonRequestBehavior.AllowGet);
            }

            return View(book);
        }

        // GET: /books/delete/{id}
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var book = context.Books.Find(id);

            if (book == null)
            {
                return HttpNotFound();
            }

            context.Books.Remove(book);

            context.SaveChanges();

            return RedirectToAction("Index", "Books");
        }
    }
}