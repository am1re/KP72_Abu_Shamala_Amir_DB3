using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace lab3.Models
{
    class Context : DbContext
    {

        public Context()
        {
        }

        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Accident> Accident { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=testdb1;";
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
