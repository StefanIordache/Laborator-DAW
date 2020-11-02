using System;
using System.Collections.Generic;
using System.Linq;
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
            ViewData["books"] = context.Books.ToList();

            return View();
        }

        // GET: /books/details/{id}
        [HttpGet]
        public ActionResult Details(int id)
        {
            var book = context.Books.Find(id);

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

            return View(book);
        }

        // DELETE: /books/delete/{id}
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