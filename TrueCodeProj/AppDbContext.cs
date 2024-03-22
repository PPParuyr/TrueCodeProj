using Microsoft.EntityFrameworkCore;
using TrueCodeProj.Models;

namespace TrueCodeTestProj;
public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=TrueCode;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<TagToUser> TagToUsers { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var userGuid = Guid.Parse("67ED6E86-26D3-4A36-BC98-549FC0812829");
        var tagGuid = Guid.Parse("676EDE86-26D3-4A36-BC98-549FC0812820");
        modelBuilder.Entity<User>().HasData(
            new User { UserId = userGuid, Name = "Test User 1", Domain = "example.com" },
            new User { UserId = Guid.NewGuid(), Name = "Test User 2", Domain = "example.com" },
            new User { UserId = Guid.NewGuid(), Name = "Test User 3", Domain = "example.com" },
            new User { UserId = Guid.NewGuid(), Name = "Test User 4", Domain = "example.com" },
            new User { UserId = Guid.NewGuid(), Name = "Test User 5", Domain = "example.com" },
            new User { UserId = Guid.NewGuid(), Name = "Test User 6", Domain = "example.com" },
            new User { UserId = Guid.NewGuid(), Name = "Test User 7", Domain = "example.com" },
            new User { UserId = Guid.NewGuid(), Name = "Test User 8", Domain = "example.com" },
            new User { UserId = Guid.NewGuid(), Name = "Test User 9", Domain = "example.com" },
            new User { UserId = Guid.NewGuid(), Name = "Test User 10", Domain = "example.com" },
            new User { UserId = Guid.NewGuid(), Name = "Test User 11", Domain = "example.com" },
            new User { UserId = Guid.NewGuid(), Name = "Test User 12", Domain = "example.com" },
            new User { UserId = Guid.NewGuid(), Name = "Test User 13", Domain = "example.com" }
        );

        modelBuilder.Entity<Tag>().HasData(
            new Tag { TagId = tagGuid, Value = "Tag1", Domain = "example.com" },
            new Tag { TagId = Guid.NewGuid(), Value = "Tag2", Domain = "example.com" },
            new Tag { TagId = Guid.NewGuid(), Value = "Tag3", Domain = "example1.com" },
            new Tag { TagId = Guid.NewGuid(), Value = "Tag4", Domain = "example2.com" }
        );

        modelBuilder.Entity<TagToUser>().HasData(
            new TagToUser { EntityId = Guid.NewGuid(), TagId = tagGuid, UserId = userGuid  }
        );

        base.OnModelCreating(modelBuilder);
    }
}