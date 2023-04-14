using Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Repository
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }


        //Her bir Entitiye karşılık DBSet
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configuration içindekileri okuyor.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            // tek tek vermek yerine yukardaki kod bütün configurationları okuyor -->  modelBuilder.ApplyConfiguration(new ProductConfiguration());



            //ProductFeature Seed ekliyoruz sadece örnek olarak feture lar seed den yapılır.
            modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature()
            {
                Id = 1,
                Color = "Kırmızı",
                Height = 100,
                Width = 100,
                ProductId = 1
            },


            new ProductFeature()
            {
                Id = 2,
                Color = "Yeşil",
                Height = 200,
                Width = 600,
                ProductId = 2
            }

            );

            base.OnModelCreating(modelBuilder);
        }

    }
}
