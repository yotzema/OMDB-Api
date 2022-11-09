using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Model;


namespace Data
{
    public class FilmContext : DbContext
    {
        public FilmContext()
        {

        }
        public FilmContext(DbContextOptions<FilmContext> options) : base(options)
        {

        }
        public DbSet<Film> Films { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog=FilmsDatabase");
        }

    }
}
