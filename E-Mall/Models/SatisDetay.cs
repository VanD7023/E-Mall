using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Mall.Models
{
    public class SatisDetay
    {
        public int ID { set; get; }
        public int SatısID { set; get; }
        public int UrunID { set; get; }
        public float Fiyat { set; get; }
        public int IndirimID { set; get; }
        public int IndirimOran { set; get; }
        public int Adet { set; get; }
        public Urun Urun { set; get; }
    }
}