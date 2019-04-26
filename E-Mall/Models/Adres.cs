using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Mall.Models
{
    public class Adres
    {
        public int ID { set; get; }
        public string AcikAdres { set; get; }
        public string AdresAdi { set; get; }
        public bool Sil { set; get; }
    }
}