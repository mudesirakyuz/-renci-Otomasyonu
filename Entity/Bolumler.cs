using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciOtomasyonu.Entity
{
    public class Bolumler
    {
        [Key]
        public int bolumid { get; set; }
        public string bolumad { get; set; }
        public ICollection<Siniflar> Siniflar { get; set; }
    }
}
