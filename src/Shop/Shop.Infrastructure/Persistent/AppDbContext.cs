using Common.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Users;
using Shop.Infrastructure._Utilities.MediatR;

namespace Shop.Infrastructure.Persistent
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
