using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DEMO_WebAPI_NET.Contexts;
using DEMO_WebAPI_NET.Models;

namespace DEMO_WebAPI_NET.Controllers
{
    public class BooksController : ApiController
    {
        private readonly LibraryContext _context = new LibraryContext();

        // GET: api/books
        public List<Book> Get()
        {
            return _context.Books.ToList();
        }
        
        // GET: api/books/{id}
        public IHttpActionResult Get(int id)
        {
            Book book = _context.Books.Find(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // POST: api/books/create
        [HttpPost]
        public IHttpActionResult Create([FromBody] Book book)
        {
            try
            {
                _context.Books.Add(book);
                _context.SaveChanges();

                var redirectURL = new Uri(Url.Link("DefaultApi", new { id = book.Id }));
                return Created(redirectURL, book);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        // PUT: api/books/update
        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody] Book updatedBook)
        {
            try
            {
                Book book = _context.Books.Find(id);

                if (book == null)
                {
                    return NotFound();
                }

                book.Title = updatedBook.Title;
                book.Author = updatedBook.Author;

                _context.SaveChanges();

                return Ok(book);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        // DELETE: api/books/delete/{id}
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Book book = _context.Books.Find(id);

                if (book == null)
                {
                    return NotFound();
                }

                _context.Books.Remove(book);
                _context.SaveChanges();

                return Ok(book);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }

        }
    }
}
