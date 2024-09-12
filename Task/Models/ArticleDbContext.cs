using Microsoft.EntityFrameworkCore;

namespace Task.Models
{
    public class ArticleDbContext : DbContext
    {
        public ArticleDbContext(DbContextOptions<ArticleDbContext> options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Users> Userss { get; set; }
    }
}
