using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Mall.Models
{
    public class Indirim
    {
        public int ID { set; get; }
        public string Adi { set; get; }
        public int TutarOrani { set; get; }
        public DateTime BaslangicTarih { set; get; }
        public DateTime BitisTarih { set; get; }
        public bool Sil { set; get; }
    }
}