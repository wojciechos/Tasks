using System.Collections.Generic;
using System.Linq;
using BookshelfApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookshelfApi.Controllers
{
    public class BookController : ControllerBase
    {
        private readonly BookContext _context;

        public BookController(BookContext context)
        {
            _context = context;

            if (_context.BookItems.Any()) return;

            _context.BookItems.AddRange(new Book
            {
                Title = "Ania z zielonego wzgórza",
                Author = "Paweł Mączas",
                Isbn = "123123",
                IsLoaned = false,
            },
            new Book()
            {
                Title = "Supe tytuł",
                Author = "Adam Janos",
                Isbn = "2342342",
                IsLoaned = false,
            },
            new Book()
            {
                Title = "Sowa",
                Author = "Anna Kukiełka",
                Isbn = "345345",
                IsLoaned = true,
            });

            _context.SaveChanges();
        }

        [HttpGet("api/[controller]")]
        public ActionResult<List<Book>> GetAll()
        {
            return _context.BookItems.ToList();
        }

        [HttpPut("api/[controller]/return/{id}")]
        public IActionResult ReturnBook(long id)
        {
            var book = _context.BookItems.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            book.IsLoaned = false;

            _context.BookItems.Update(book);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut("api/[controller]/loan/{id}")]
        public IActionResult LoanBook(long id)
        {
            var book = _context.BookItems.Find(id);
            if (book == null || book.IsLoaned)
            {
                return NotFound();
            }

            book.IsLoaned = true;

            _context.BookItems.Update(book);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
