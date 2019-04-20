using E_Mall.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace E_Mall.Database
{
    public class UrunDatabase : Database<Urun>
    {
        string _ID { get; } = "ID";
        string _Adi { get; } = "Adi";
        string _Aciklama { get; } = "Aciklama";
        string _Barkod { get; } = "Barkod";
        string _BaslangicTarihi { get; } = "BaslangicTarih";
        string _BitisTarihi { get; } = "BitisTarih";
        string _Fiyat { get; } = "Fiyat";
        string _EskiFiyat { get; } = "EskiFiyat";
        string _Maliyet { get; } = "Maliyet";
        string _KargoFiyat { get; } = "KargoFiyat";
        string _KargoDurum { get; } = "KargoDurum";
        string _Agirlik { get; } = "Agirlik";
        string _Uzunluk { get; } = "Uzunluk";
        string _Genislik { get; } = "Genislik";
        string _Yukseklik { get; } = "Yukseklik";
        string _KategoriID { get; } = "KategoriID";
        string _Ureticiler { get; } = "Ureticiler";
        string _sil { get; } = "Sil";
        string _Table { get; } = "Urun";



        public override void Insert(Urun item)
        {
            //string s = $"insert into {_Table}";
            //insert into Urunler
            string sorgu = string.Format("insert into {0}({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16})" +
                "values ('{17}','{18}','{19}','{20}','{21}',{22},{23},{24},{25},'{26}',{27},{28},{29},{30},{31},'{32}')",
                _Table, _Adi, _Aciklama, _Barkod, _BaslangicTarihi, _BitisTarihi, _Fiyat, _EskiFiyat, _Maliyet, _KargoFiyat, _KargoDurum, _Agirlik, _Uzunluk, _Genislik, _Yukseklik, _KategoriID, _Ureticiler,
                item.Adi, item.Aciklama, item.Barkod, item.BaslangicTarih.ToString(), item.BitisTarih.ToString(), item.Fiyat, item.EskiFiyat, item.Maliyet, item.KargoFiyat, item.KargoDurum, item.Agirlik, item.Uzunluk, item.Genislik, item.Yukseklik, item.KategoriID, item.Ureticiler, item.KategoriID, item.Ureticiler);
            Debug.WriteLine(sorgu);
            InsertCommand(sorgu);
        }

        public override void Delete(int ID)
        {
            string sorgu = string.Format("delete from {0} where {1} = {2}", _Table, _ID, ID);
            DeleteCommand(sorgu);
        }

        public override List<Urun> GetAll()
        {
            string sorgu = string.Format("select * from {0}", _Table);
            List<Urun> uruns = new List<Urun>();
            SqlDataReader reader = getReader(sorgu);
            while (reader.Read())
            {
             
                uruns.Add(new Urun()
                {
                    ID = (int)reader[_ID],
                    Adi = reader[_Adi].ToString(),
                    Aciklama = reader[_Aciklama].ToString(),
                    Barkod = reader[_Barkod].ToString(),
                    BaslangicTarih = (DateTime)reader[_BaslangicTarihi],
                    BitisTarih = (DateTime)reader[_BitisTarihi],
                    Fiyat = float.Parse(reader[_Fiyat].ToString()),
                    EskiFiyat = float.Parse(reader[_EskiFiyat].ToString()),
                    Maliyet = float.Parse(reader[_Maliyet].ToString()),
                    KargoFiyat = float.Parse(reader[_KargoFiyat].ToString()),
                    KargoDurum = (bool)reader[_KargoDurum],
                    Agirlik = float.Parse(reader[_Agirlik].ToString()),
                    Uzunluk = float.Parse(reader[_Uzunluk].ToString()),
                    Genislik = float.Parse(reader[_Genislik].ToString()),
                    Yukseklik = float.Parse(reader[_Yukseklik].ToString()),
                    KategoriID = (int)reader[_KategoriID],
                    Ureticiler = reader[_Ureticiler].ToString()
                });
            }
            reader.Close();
            return uruns;
        }

        public override List<Urun> GetForAdi(string value)
        {
            List<Urun> uruns = new List<Urun>();
            string sorgu = string.Format("select * from {0} where {1} like '%{2}%'", _Table, _Adi, value );
            SqlDataReader reader = getReader(sorgu);
            while (reader.Read())
            {
                uruns.Add(new Urun()
                {
                    ID = (int)reader[_ID],
                    Adi = reader[_Adi].ToString(),
                    Aciklama = reader[_Aciklama].ToString(),
                    Barkod = reader[_Barkod].ToString(),
                    BaslangicTarih = (DateTime)reader[_BaslangicTarihi],
                    BitisTarih = (DateTime)reader[_BitisTarihi],
                    Fiyat = float.Parse(reader[_Fiyat].ToString()),
                    EskiFiyat = float.Parse(reader[_EskiFiyat].ToString()),
                    Maliyet = float.Parse(reader[_Maliyet].ToString()),
                    KargoFiyat = float.Parse(reader[_KargoFiyat].ToString()),
                    KargoDurum = (bool)reader[_KargoDurum],
                    Agirlik = float.Parse(reader[_Agirlik].ToString()),
                    Uzunluk = float.Parse(reader[_Uzunluk].ToString()),
                    Genislik = float.Parse(reader[_Genislik].ToString()),
                    Yukseklik = float.Parse(reader[_Yukseklik].ToString()),
                    KategoriID = (int)reader[_KategoriID],
                    Ureticiler = reader[_Ureticiler].ToString(),
                    sil = false
                });
            }
            reader.Close();
            return uruns;
        }

        public override Urun GetForID(int ID)
        {
            string sorgu = string.Format("select * from {0} where {1} = {2}", _Table, _ID, ID);
            SqlDataReader reader = getReader(sorgu);
            if (!reader.Read())
                return null;
            Urun urun = new Urun()
            {
                ID = (int)reader[_ID],
                Adi = reader[_Adi].ToString(),
                Aciklama = reader[_Aciklama].ToString(),
                Barkod = reader[_Barkod].ToString(),
                BaslangicTarih = (DateTime)reader[_BaslangicTarihi],
                BitisTarih = (DateTime)reader[_BitisTarihi],
                Fiyat = float.Parse(reader[_Fiyat].ToString()),
                EskiFiyat = float.Parse(reader[_EskiFiyat].ToString()),
                Maliyet = float.Parse(reader[_Maliyet].ToString()),
                KargoFiyat = float.Parse(reader[_KargoFiyat].ToString()),
                KargoDurum = (bool)reader[_KargoDurum],
                Agirlik = float.Parse(reader[_Agirlik].ToString()),
                Uzunluk = float.Parse(reader[_Uzunluk].ToString()),
                Genislik = float.Parse(reader[_Genislik].ToString()),
                Yukseklik = float.Parse(reader[_Yukseklik].ToString()),
                KategoriID = (int)reader[_KategoriID],
                Ureticiler = reader[_Ureticiler].ToString(),
                sil = false
            };
            reader.Close();
            return urun;
        }

        public override void Update(Urun item)
        {
            throw new NotImplementedException();
        }
    }
}