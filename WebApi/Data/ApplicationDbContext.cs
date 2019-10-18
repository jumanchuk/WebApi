using WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Data
{
    public class ApplicationDbContext: DbContext
    {
            
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Movements> Movements { get; set; }
        public DbSet<MovementsType> MovementsType { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Cliente>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
                
                builder.Entity<Cliente>()
                .HasData(
                    new Cliente {
                        Id = 1,
                        Document = 95699120,
                        Name = "Jury",
                        Lastname = "Umanchuk",
                        Date = DateTime.Now},
                    new Cliente {
                        Id = 2,
                        Document = 95598062,
                        Name = "Linda",
                        Lastname = "Perez",
                        Date = DateTime.Now}
                        );

                builder.Entity<ProductType>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

                builder.Entity<ProductType>()
                .HasData(
                    new ProductType {
                        Id = 1,
                        Product_type = 1,
                        name = "Cuenta Ahorro",
                        status = 1},
                    new ProductType {
                        Id = 2,
                        Product_type = 1,
                        name = "Cuenta Corriente",
                        status = 2});

                builder.Entity<Products>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

                builder.Entity<Products>()
                .HasData(
                    new {
                        Id = 1,
                        current_balance = (decimal)150,
                        status = 1,
                        Opening_date = DateTime.Now,
                        ProductTypeId = 1,
                        ClientId = 1
                    },
                    new {
                        Id = 2,
                        current_balance = (decimal)100,
                        status = 1,
                        Opening_date = DateTime.Now,
                        ProductTypeId = 2,
                        ClientId = 1
                        },
                    new {
                        Id = 3,
                        current_balance = (decimal)500,
                        status = 1,
                        Opening_date = DateTime.Now,
                        ProductTypeId = 1,
                        ClientId = 2
                        });

                builder.Entity<MovementsType>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

                builder.Entity<MovementsType>()
                .HasData(
                    new {
                        Id = 1,
                        Movements_type=1,
                        status = 1,
                        name="Deposito"
                    },
                    new {
                        Id = 2,
                        Movements_type=2,
                        status = 1,
                        name="Extracción"
                        });

                builder.Entity<Movements>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

                builder.Entity<Movements>()
                .HasData(
                    new {
                        Id = 1,
                        ProductsId=1,
                        MovementsTypeId = 1,
                        amount = (decimal)150,
                        status = 1,
                        date = DateTime.Now,
                    },
                    new {
                        Id = 2,
                        ProductsId=1,
                        MovementsTypeId = 2,
                        amount = (decimal)100,
                        status = 1,
                        date = DateTime.Now,
                        });

                base.OnModelCreating(builder);
        }
    }
}
