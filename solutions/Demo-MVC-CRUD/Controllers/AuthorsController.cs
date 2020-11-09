using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo_MVC_CRUD.Data;
using Demo_MVC_CRUD.Models;

namespace Demo_MVC_CRUD.Controllers
{
    public class AuthorsController : Controller
    {
        private LibraryContext context = new LibraryContext();

        // GET: /authors/index
        [HttpGet]
        public ActionResult Index()
        {
            ViewData["authors"] = context.Author.ToList();

            return View();
        }

        // GET: /authors/details/{id}
        [HttpGet]
        public ActionResult Details(int id)
        {
            var author = context.Author.Find(id);

            if (author == null)
            {
                return HttpNotFound();
            }

            return View(author);
        }

        // GET: /authors/create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /author/create
        [HttpPost]
        public ActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                context.Author.Add(author);

                context.SaveChanges();

                return RedirectToAction("Index", "Authors");
            }

            return View(author);
        }

        // GET: /authors/edit/{id}
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var author = context.Author.Find(id);

            if (author == null)
            {
                return HttpNotFound();
            }

            return View(author);
        }

        // POST: /authors/edit
        [HttpPost]
        public ActionResult Edit(Author author)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var oldAuthor = context.Author.Find(author.Id);

                    if (oldAuthor == null)
                    {
                        return HttpNotFound();
                    }

                    oldAuthor.FirstName = author.FirstName;
                    oldAuthor.LastName = author.LastName;
                    oldAuthor.Email = author.Email;

                    TryUpdateModel(oldAuthor);

                    context.SaveChanges();

                    return RedirectToAction("Index", "Authors");
                }
            }
            catch (Exception e)
            {
                return Json(new { error_message = e.Message }, JsonRequestBehavior.AllowGet);
            }

            return View(author);
        }

        // GET: /authors/delete/{id}
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var author = context.Author.Find(id);

            if (author == null)
            {
                return HttpNotFound();
            }

            context.Author.Remove(author);

            context.SaveChanges();

            return RedirectToAction("Index", "Authors");
        }
    }
}