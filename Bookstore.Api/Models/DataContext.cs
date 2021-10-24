using System.Collections.Immutable;
using Bookstore.Api.Models;
using Bookstore.Api.Profiles.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Api.Models
{
  public class DataContext : IdentityDbContext<Users>
  {
    public DataContext(DbContextOptions<DataContext> opt) : base(opt)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      builder.ApplyConfiguration(new RoleConfiguration());

    }
    public DbSet<Authors> Authors { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Books> Books { get; set; }
    public DbSet<BookSales> BookSales { get; set; }

  }
}