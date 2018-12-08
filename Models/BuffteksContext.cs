using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using FinalProg_BuffTeks.Models;
using System.Collections.Generic;
using System.Linq;

namespace FinalProg_BuffTeks
{
    //here, we extend the DbContext class with our own class 'AppDbContext'
    public class BuffteksContext : DbContext
    {
        //The connection string is used by the SQL Server database provider to find the database
        public const string ConnectionString = @"Data Source=BuffteksDb.db";

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            //Using the SQLite database provider’s UseSqlServer command sets up the options ready for creating the applications’s DBContext
            optionsBuilder.UseSqlite(ConnectionString); //#B
        }        

        //   //public DbSet<Student> Students { get; set; } 
         
         public DbSet<Client> Clients { get; set; }
         public DbSet<Member> Members { get; set; } 
            public DbSet<Project> Projects { get; set; }

            protected override void  OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Member>().ToTable("Client");
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Project>().ToTable("Project");

}
          
    }    
}