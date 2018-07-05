using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BookshelfApi.Controllers;
using BookshelfApi.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace BookshelfApiTests
{
    public class BookControllerTests
    {

        [Fact]
        public void LoanBook_Should_Return_NotFound_When_Book_NotExists()
        {
            var options = new DbContextOptionsBuilder<BookContext>()
                .UseInMemoryDatabase(databaseName: "loan_null")
                .Options;

            using (var context = new BookContext(options))
            {
                var service = new BookController(context);
                var result = service.LoanBook(1);
                Assert.IsType<NotFoundResult>(result);
            }
        }

        [Fact]
        public void ReturnBook_Should_Return_NotFoundResult_When_Book_NotExists()
        {
            var options = new DbContextOptionsBuilder<BookContext>()
                .UseInMemoryDatabase(databaseName: "returnBook_null")
                .Options;

            using (var context = new BookContext(options))
            {
                var service = new BookController(context);
                var result = service.ReturnBook(1);
                Assert.IsType<NotFoundResult>(result);
            }
        }
        [Fact]
        public void LoanBook_Should_Returns_NotFound_For_LoanedBook()
        {
            var options = new DbContextOptionsBuilder<BookContext>()
                .UseInMemoryDatabase(databaseName: "loanBook_notFound")
                .Options;

            using (var context = new BookContext(options))
            {
                context.BookItems.Add(new Book()
                {
                    Id = 1,
                    Author = "Mickiewicz Adam",
                    Title = "Szyponka",
                    Isbn = "12343",
                    IsLoaned = true
                });
                context.SaveChanges();
            }

            using (var context = new BookContext(options))
            {
                var service = new BookController(context);
                var result = service.LoanBook(1);
                Assert.IsType<NotFoundResult>(result);
            }
        }

        [Fact]
        public void LoanBook_Should_Change_IsLoaned_To_False_For_Not_Loaned_Book()
        {
            var options = new DbContextOptionsBuilder<BookContext>()
                .UseInMemoryDatabase(databaseName: "LoabBook")
                .Options;

            using (var context = new BookContext(options))
            {
                context.BookItems.Add(new Book()
                {
                    Id = 1,
                    Author = "Mickiewicz Adam",
                    Title = "Szyponka",
                    Isbn = "12343",
                    IsLoaned = false
                });
                context.SaveChanges();
            }

            using (var context = new BookContext(options))
            {
                var service = new BookController(context);
                service.LoanBook(1);

                var results = service.FetchBooks();
                Assert.True(results.Value.First().IsLoaned);
            }
        }

        [Fact]
        public void ReturnBook_Should_Change_IsLoaned_To_False()
        {
            var options = new DbContextOptionsBuilder<BookContext>()
                .UseInMemoryDatabase(databaseName: "ReturBook")
                .Options;

            using (var context = new BookContext(options))
            {
                context.BookItems.Add(new Book()
                {
                    Id = 1,
                    Author = "Mickiewicz Adam",
                    Title = "Szyponka",
                    Isbn = "12343",
                    IsLoaned = false
                });
                context.SaveChanges();
            }

            using (var context = new BookContext(options))
            {
                var service = new BookController(context);
                service.LoanBook(1);

                var results = service.FetchBooks();
                Assert.True(results.Value[0].IsLoaned);
            }
        }

        [Fact]
        public void FetchBooks_Should_Return_All_Books()
        {
            var options = new DbContextOptionsBuilder<BookContext>()
                .UseInMemoryDatabase(databaseName: "FetchBooks")
                .Options;

            var expectedResults = new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    Author = "Mickiewicz Adam",
                    Title = "Szyponka",
                    Isbn = "12343",
                    IsLoaned = false
                },
                new Book()
                {
                    Id = 2,
                    Author = "Justyna Czubówna",
                    Title = "Hari Mona",
                    Isbn = "46456",
                    IsLoaned = false
                }
            };

            using (var context = new BookContext(options))
            {
                context.BookItems.AddRange(expectedResults);
                context.SaveChanges();
            }

            using (var context = new BookContext(options))
            {
                var service = new BookController(context);
                var results = service.FetchBooks();
                Assert.Equal(expectedResults, results.Value);
            }
        }
    }
}
