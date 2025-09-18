using DenemeYapiyorum.Models;
using Microsoft.EntityFrameworkCore;

namespace DenemeYapiyorum.Data
{
    public class DbBaglantisi : DbContext
    {
        public DbBaglantisi(DbContextOptions<DbBaglantisi> options)
            : base(options)
        {
        }

        public DbSet<Kisi> Kisiler { get; set; }
        public DbSet<Araba> Arabalar { get; set; }
    }
}
