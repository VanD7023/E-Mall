using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Mall.Models
{
    public class Satis
    {
        public int ID { set; get; }
        public int KullaniciID { set; get; }
        public DateTime Zaman { set; get; }
        public int SatisDurumID { set; get; }
        public string KargoKod { set; get; }
        public bool KargoDurum { set; get; }
        public float KargoUcret { set; get; }
        public int AdresID { set; get; }
        public List<SatisDetay> satisDetay { set; get; }
        public Musteri Kullanici { set; get; }
        public Adres Adres { set; get; }
        public float Toplam { set; get; }
        public int Adet { set; get; }
    }
}