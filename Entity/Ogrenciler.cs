using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciOtomasyonu.Entity
{
    public class Ogrenciler
    {
        [Key]
        public int ogrid { get; set; }

        public string ograd { get; set; }
        public string ogrsoyad { get; set; }
        public Siniflar Siniflar { get; set; }
    }
}
