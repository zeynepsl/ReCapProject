using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarRentalContext:DbContext
    {
        //Context : db tabloları ile proje classlarını bağlamak
        //sql server adı : Server = (localdb)\mssqllocalDB
        //database adı : Database = CarRentalDataBase
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\mssqllocalDB; Database = CarRentalDataBase; Trusted_Connection = true");
        }
        

        //benim hangi class ım (DbSet<T>) veritabanındaki hangi tabloya karşılık gelecek
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
    }
}
