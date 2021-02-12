using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using OgrenciOtomasyonu.Entity;

namespace OgrenciOtomasyonu.Entity
{
    class Context: DbContext
    {
        public DbSet<Ogrenciler> Ogrencilers { get; set; }
        public DbSet<Bolumler> Bolumlers { get; set; }
        public DbSet<Siniflar> Siniflars { get; set; }
        public DbSet<Kullanicilar> Kullanicilars { get; set; }
    }
}
