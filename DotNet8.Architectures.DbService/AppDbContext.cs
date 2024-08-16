namespace DotNet8.Architectures.DbService;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options)
        : base(options) { }

    public DbSet<Tbl_Blog> Tbl_Blogs { get; set; }
}
