/*using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradixProject.EntityLayer.Concrete;

namespace TradixProject.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.\\SQLEXPRESS;initial catalog=ExchangeRates;integrated Security=true;TrustServerCertificate=True");

        }
        public DbSet<Class1> Class1Entities { get; set; }  // Class1 için DbSet tanımı
    }
}
    

*/
using Intuit.Ipp.Data;
using Microsoft.EntityFrameworkCore;
using TradixProject.DataAccessLayer.Repositories;

namespace TradixProject.DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        public DbSet<ExchangeRate> ExchangeRate
        { get; set; }  // ExchangeRate tablosu için DbSet

        // Diğer DbSet'ler burada yer alabilir

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=.\\SQLEXPRESS;initial catalog=ExchangeRates;integrated Security=true;TrustServerCertificate=True");
            }
        }
    }
}
