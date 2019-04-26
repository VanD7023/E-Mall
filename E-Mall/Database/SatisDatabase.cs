using E_Mall.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace E_Mall.Database
{
    public class SatisDatabase : Database<Satis>
    {
        string _ID { get; } = "ID";
        string _KullaniciID { get; } = "KullaniciID";
        string _Zaman { get; } = "Zaman";
        string _SatisDurumID { get; } = "SatisDurumID";
        string _KargoKod { get; } = "KargoKod";
        string _KargoDurum { get; } = "KargoDurum";
        string _KargoUcret { get; } = "KargoUcret";
        string _AdresID { get; } = "AdresID";
        string _Toplam { get; } = "Toplam";
        string _Adet { get; } = "Adet";
        string _Table { get; } = "Satis";


        public override void Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public override List<Satis> GetAll()
        {
            string sorgu = string.Format("select * from {0} ", _Table);
            List<Satis> satislar = new List<Satis>();
            SqlDataReader reader = getReader(sorgu);
            while (reader.Read())
            {
                satislar.Add(new Satis()
                {
                    ID = (int)reader[_ID],
                    KullaniciID = (int)reader[_KullaniciID],
                    Zaman = (DateTime)reader[_Zaman],
                    SatisDurumID = (int)reader[_SatisDurumID],
                    KargoKod = reader[_KargoKod].ToString(),
                    KargoDurum = (bool)reader[_KargoDurum],
                    KargoUcret = float.Parse(reader[_KargoUcret].ToString()),
                    AdresID = (int)reader[_AdresID]
                });
            }
            reader.Close();
            AdresDatabase adresDatabase = new AdresDatabase();
            SatisDetayDatabase satisdatabase = new SatisDetayDatabase();
            MusteriDatabase kdatabase = new MusteriDatabase();
            UrunDatabase udatabase = new UrunDatabase();
            foreach(Satis item in satislar){
                item.Kullanici = kdatabase.GetForID(item.KullaniciID);
                item.satisDetay = satisdatabase.getForSatisID(item.ID);
                float toplam = 0;
                int adet=0;
                foreach (SatisDetay satisDetay in item.satisDetay)
                {
                    toplam += (satisDetay.Fiyat * satisDetay.Adet);
                    adet += (satisDetay.Adet);
                }
                item.Adet = adet;
                item.Toplam = toplam;
                item.Adres = adresDatabase.GetForID(item.AdresID);
            }
            return satislar;
        }

        public override List<Satis> GetForAdi(string value)
        {
            throw new NotImplementedException();
        }

        public override Satis GetForID(int ID)
        {
            string sorgu = string.Format("select * from {0}  where {1}={2}", _Table,_ID,ID);
            Debug.WriteLine("Sorgu " + sorgu);
            SqlDataReader reader = getReader(sorgu);
            if (!reader.Read())
                return null;
            Satis s = new Satis()
            {
                ID = (int)reader[_ID],
                KullaniciID = (int)reader[_KullaniciID],
                Zaman = (DateTime)reader[_Zaman],
                SatisDurumID = (int)reader[_SatisDurumID],
                KargoKod = reader[_KargoKod].ToString(),
                KargoDurum = (bool)reader[_KargoDurum],
                KargoUcret = float.Parse(reader[_KargoUcret].ToString()),
                AdresID = (int)reader[_AdresID]
            };
            AdresDatabase adresDatabase = new AdresDatabase();
            SatisDetayDatabase satisdatabase = new SatisDetayDatabase();
            MusteriDatabase kdatabase = new MusteriDatabase();
            s.Kullanici = kdatabase.GetForID(s.KullaniciID);
            s.satisDetay = satisdatabase.getForSatisID(s.ID);
            float toplam = 0;
            foreach (SatisDetay satisDetay in s.satisDetay)
                toplam += (satisDetay.Fiyat * satisDetay.Adet);
            s.Toplam = toplam;
            s.Adres = adresDatabase.GetForID(s.AdresID);
            return s;
        }

        public override void Insert(Satis item)
        {
            throw new NotImplementedException();
        }
        public List<Satis> Arama(SatisArama arama)
        {
            string sorgu = "select * from Satis where ID in(select Satis.ID from Satis Join Kullanici on Satis.KullaniciID=Kullanici.ID where 1=1";
            if (arama.MusteriAdi!=null&&arama.MusteriAdi.Length != 0)
                sorgu += string.Format(" and Kullanici.Adi like '%{0}%'", arama.MusteriAdi);
            if (arama.Email!=null && arama.Email.Length != 0)
                sorgu += string.Format(" and Kullanici.Email like '%{0}%'", arama.Email);
            if (arama.SatisDurum != 0)
                sorgu += string.Format(" and Satis.SatisDurumID ={0}", arama.SatisDurum);
            if (arama.SatisNo != 0)
                sorgu += string.Format(" Satis.ID={0}", arama.SatisNo);
            sorgu += ")";
            Debug.WriteLine(sorgu + "Sorgu ");
            SqlDataReader reader = getReader(sorgu);
            List<Satis> satislar = new List<Satis>();
            while (reader.Read())
            {
                satislar.Add(new Satis()
                {
                    ID = (int)reader[_ID],
                    KullaniciID = (int)reader[_KullaniciID],
                    Zaman = (DateTime)reader[_Zaman],
                    SatisDurumID = (int)reader[_SatisDurumID],
                    KargoKod = reader[_KargoKod].ToString(),
                    KargoDurum = (bool)reader[_KargoDurum],
                    KargoUcret = float.Parse(reader[_KargoUcret].ToString()),
                    AdresID = (int)reader[_AdresID]
                });
            }
            reader.Close();
            AdresDatabase adresDatabase = new AdresDatabase();
            SatisDetayDatabase satisdatabase = new SatisDetayDatabase();
            MusteriDatabase kdatabase = new MusteriDatabase();
            UrunDatabase udatabase = new UrunDatabase();
            foreach (Satis item in satislar)
            {
                item.Kullanici = kdatabase.GetForID(item.KullaniciID);
                item.satisDetay = satisdatabase.getForSatisID(item.ID);
                float toplam = 0;
                int adet = 0;
                foreach (SatisDetay satisDetay in item.satisDetay)
                {
                    toplam += (satisDetay.Fiyat * satisDetay.Adet);
                    adet += (satisDetay.Adet);
                }
                item.Adet = adet;
                item.Toplam = toplam;
                item.Adres = adresDatabase.GetForID(item.AdresID);
            }
            return satislar;
        }
        public override void Update(Satis item)
        {
            string sorgu = string.Format("update {0} set {1} = '{2}', {3} = '{4}', {5} = {6} where {7} = {8}", _Table, _KargoDurum, item.KargoDurum, _KargoKod, item.KargoKod, _SatisDurumID, item.SatisDurumID,item.ID, _ID);
            Debug.WriteLine("Update Sorgu", sorgu);
            UpdateCommand(sorgu);
        }
    }
}