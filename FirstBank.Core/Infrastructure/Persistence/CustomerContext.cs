using FirstBank.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstBank.Core.Infrastructure.Persistence
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<RequiredField> RequiredFields { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Industry)
                .WithMany()
                .HasForeignKey(c => c.IndustryId);

            modelBuilder.Entity<RequiredField>()
                .HasOne(rf => rf.Industry)
                .WithMany(i => i.RequiredFields)
                .HasForeignKey(rf => rf.IndustryId);

            modelBuilder.Entity<Industry>().HasData(
                new Industry { Id = 1, Name = "Manufacturing" },
                new Industry { Id = 2, Name = "Education" },
                new Industry { Id = 3, Name = "Telecom" }
            );

            modelBuilder.Entity<RequiredField>().HasData(
                new RequiredField { Id = 1, IndustryId = 1, FieldName = "Invoice Number" },
                new RequiredField { Id = 2, IndustryId = 1, FieldName = "Quantity" },
                new RequiredField { Id = 3, IndustryId = 1, FieldName = "Delivery Address" },
                new RequiredField { Id = 4, IndustryId = 2, FieldName = "Matric Number" },
                new RequiredField { Id = 5, IndustryId = 2, FieldName = "Level" },
                new RequiredField { Id = 6, IndustryId = 2, FieldName = "Course" },
                new RequiredField { Id = 7, IndustryId = 3, FieldName = "GSM Number" },
                new RequiredField { Id = 8, IndustryId = 3, FieldName = "Network" },
                new RequiredField { Id = 9, IndustryId = 3, FieldName = "Residential Address" }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, AccountNumber = "1234567890", Name = "Manufacturer A", IndustryId = 1 },
                new Customer { Id = 2, AccountNumber = "2345678901", Name = "School B", IndustryId = 2 },
                new Customer { Id = 3, AccountNumber = "3456789012", Name = "Telecom C", IndustryId = 3 }
            );
        }
    }
}
