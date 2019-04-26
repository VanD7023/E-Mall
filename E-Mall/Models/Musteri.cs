using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Mall.Models
{
    public class Musteri
    {
        public int ID { set; get; }
        public string UserName { set; get; }
        public string Adi { set; get; }
        public string Soyadi { set; get; }
        public string Email { set; get; }
        public string Telefon { set; get; }
        public DateTime DogumTarih { set; get; }
        public string Sifre { set; get; }
        public string RestToken { set; get; }
        public DateTime RestTokenEndTime { set; get; }
        public DateTime RegisterDate { set; get; }
        public bool Sil { set; get; }
    }
}