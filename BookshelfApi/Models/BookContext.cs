using Microsoft.EntityFrameworkCore;

namespace BookshelfApi.Models
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions options)
            : base(options)
        { }

        public virtual DbSet<Book> BookItems { get; set; }
    }
}
