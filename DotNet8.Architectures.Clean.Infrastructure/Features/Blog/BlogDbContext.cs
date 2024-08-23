using DotNet8.Architectures.Clean.Domain.Features.Blog;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.Architectures.Clean.Infrastructure.Features.Blog;

public class BlogDbContext : DbContext
{
    public BlogDbContext(DbContextOptions options)
        : base(options) { }

    public DbSet<Tbl_Blog> Tbl_Blogs { get; set; }
}
