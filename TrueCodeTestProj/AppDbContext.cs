using Microsoft.EntityFrameworkCore;

namespace TrueCodeTestProj;
public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<TagToUser> TagToUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=TrueCode;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");
    }

}