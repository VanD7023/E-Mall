using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Mall.Models
{
    public class UrunOzellikleri
    {
        public int ID { set; get; }
        public string Deger { set; get; }
        public string Adi { set; get; }
        public bool Sil { set; get; }
    }
}