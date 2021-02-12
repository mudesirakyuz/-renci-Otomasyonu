using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciOtomasyonu.Entity
{
    public class Siniflar
    {
        [Key]
        public int sinifid { get; set; }
        public string sinifad { get; set; }
        public Bolumler Bolumler { get; set; }
        public ICollection<Ogrenciler> Ogrenciler { get; set; }
    }
}
