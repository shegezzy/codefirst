using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sql;
using Microsoft.EntityFrameworkCore;

namespace Person.Models
{
    public class PersonDbContext:DbContext
    {
        public PersonDbContext() { }
        public PersonDbContext(DbContextOptions<PersonDbContext> options) 
            : base(options) 
        { 

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=Persondb;Trusted_Connection=True;TrustServerCertificate=true;");
            }
        }
        public DbSet<PostPerson> Person { get; set; }
    }
}
