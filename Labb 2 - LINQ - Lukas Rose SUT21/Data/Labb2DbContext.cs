using Labb_2___LINQ___Lukas_Rose_SUT21.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labb_2___LINQ___Lukas_Rose_SUT21.Data
{
    public class Labb2DbContext : DbContext
    {
        public DbSet<Klass> Klasser { get; set; }
        public DbSet<Lärare> Lärare { get; set; }
        public DbSet<Student> Studenter { get; set; }
        public DbSet<Ämne> Ämnen { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = LAPTOP-TOC6LE29; Initial Catalog = Labb2Db; Integrated Security = True; MultipleActiveResultSets=true;");
        }
    }
}
