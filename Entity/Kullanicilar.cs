using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciOtomasyonu.Entity
{
    public class Kullanicilar
    {
        [Key]
        public string kullaniciadi { get; set; }
        public string parola { get; set; }
        public string guvenliksorusu { get; set; }
    }
}
