using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Mall.Models
{
    public class Urun
    {
        public int ID { set; get; }
        public string Adi { set; get; }
        public string Aciklama { set; get; }
        public string Barkod { set; get; }
        public DateTime BaslangicTarih { set; get; }
        public DateTime BitisTarih { set; get; }
        public float Fiyat { set; get; }
        public float EskiFiyat { set; get; }
        public float Maliyet { set; get; }
        public float KargoFiyat { set; get; }
        public bool KargoDurum { set; get; }
        public float Agirlik { set; get; }
        public float Uzunluk { set; get; }
        public float Genislik { set; get; }
        public float Yukseklik { set; get; }
        public int KategoriID { set; get; }
        public string Ureticiler { set; get; }
        public bool sil { set; get; }
    }
}