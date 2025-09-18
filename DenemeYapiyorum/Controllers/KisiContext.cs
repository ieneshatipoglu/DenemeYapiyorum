using DenemeYapiyorum.Models;
using Microsoft.EntityFrameworkCore;

namespace DenemeYapiyorum.Data
    {
        public class KisiContext : DbContext
        {
            public KisiContext(DbContextOptions<KisiContext> options)
                : base(options)
            {
            }

            public DbSet<Kisi> Kisiler { get; set; }
            public DbSet<Araba> Arabalar { get; set; }
        }
    }

