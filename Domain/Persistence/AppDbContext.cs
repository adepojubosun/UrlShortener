using System;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Domain.Model;


namespace UrlShortener.Domain.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<UrlShortenerModel> UrlShorteners {get; set;}

        public DbSet<UserModel> Users {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }

}