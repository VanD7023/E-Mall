using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Mall.Models
{
    public class Kategori
    {
        public int ID { set; get; }
        public int ResimID { set; get; }
        public string Adi { set; get; }
        public string Aciklama { set; get; }
        public int UstID { set; get; }
        public bool Sil { set; get; }
        public Resim Resim { set; get; }
    }
}