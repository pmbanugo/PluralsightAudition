using Microsoft.EntityFrameworkCore;

namespace PluralsightAudition
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
    }
}