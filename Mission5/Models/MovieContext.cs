using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission5.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext (DbContextOptions<MovieContext> options) : base (options)
        {

        }

        public DbSet<MovieInfo> MovieInfo { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                    new Category { CategoryId = 1, CategoryName = "Action"},
                    new Category { CategoryId = 2, CategoryName = "Comedy"},
                    new Category { CategoryId = 3, CategoryName = "Drama"},
                    new Category { CategoryId = 4, CategoryName = "Horror"},
                    new Category { CategoryId = 5, CategoryName = "Romance"}
                );

            mb.Entity<MovieInfo>().HasData(

                new MovieInfo
                {
                    CategoryId = 1,
                    Title = "The Dark Knight",
                    Year = 2008,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new MovieInfo
                {
                    CategoryId = 2,
                    Title = "Nacho Libre",
                    Year = 2006,
                    Director = "Jared Hess",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new MovieInfo
                {
                    CategoryId = 1,
                    Title = "Hacksaw Ridge",
                    Year = 2016,
                    Director = "Mel Gibson",
                    Rating = "R",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                }
            );
        }
    }
}
