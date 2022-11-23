using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyToDoBookAPI.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDoBookAPI.Model.Data
{
    public class ToDoBookContext : IdentityDbContext<ApplicationUser>
    {
        public ToDoBookContext(DbContextOptions<ToDoBookContext> options) : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.EnableSensitiveDataLogging();
        //}
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.ApplyConfiguration(new BooksConfiguration());
        //    base.OnModelCreating(builder);
        //}
        public DbSet<Books> Books { get; set; }
    }



}
