using E_Mall.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace E_Mall.Database
{
    public class MusteriDatabase : Database<Musteri>
    {
        string _ID { get; } = "ID";
        string _UserName { get; } = "UserName";
        string _Adi { get; } = "Adi";
        string _Soyadi { get; } = "Soyadi";
        string _Email { get; } = "Email";
        string _Telefon { get; } = "Telefon";
        string _DogumTarih { get; } = "DogumTarih";
        string _Cinsiyet { get; } = "Cinsiyet";
        string _Sifre { get; } = "Password";
        string _RestToken { get; } = "RestToken";
        string _RestTokenEndTime { get; } = "RestTokenEndTime";
        string _RegisterDate { get; } = "RegisterDate";
        string _Sil { get; } = "Sil";
        string _Table { get; } = "Kullanici";

        public override void Delete(int ID)
        {
            string sorgu = string.Format("update {0} set  {1}='True' where {2}={3} ", _Table, _Sil, _ID, ID);
            Debug.WriteLine("Musteri Delete ", sorgu);
            DeleteCommand(sorgu);
        }

        public override List<Musteri> GetAll()
        {
            string sorgu = string.Format("select * from {0} where not ISNULL(Sil,'False')='True'", _Table);
            SqlDataReader reader = getReader(sorgu);
            List<Musteri> musteris = new List<Musteri>();
            while (reader.Read())
            {
                musteris.Add(new Musteri()
                {
                    ID = (int)reader[_ID],
                    UserName = reader[_UserName].ToString(),
                    Adi = reader[_Adi].ToString(),
                    Soyadi = reader[_Soyadi].ToString(),
                    Email = reader[_Email].ToString(),
                    Telefon = reader[_Telefon].ToString(),
                    DogumTarih = (DateTime)(reader[_DogumTarih].ToString().Length == 0 ? DateTime.MinValue : reader[_DogumTarih]),
                    Sifre = reader[_Sifre].ToString(),
                    Sil = (bool)reader[_Sil]
                });
            }
            reader.Close();
            return musteris;
        }

        public override List<Musteri> GetForAdi(string value)
        {
            throw new NotImplementedException();
        }

        public override Musteri GetForID(int ID)
        {
            string sorgu = string.Format("select * from {0} where {1} = {2}", _Table,_ID, ID);
            Debug.WriteLine(sorgu);
            SqlDataReader reader = getReader(sorgu);
            if (!reader.Read())
                return new Musteri();
            Musteri musteris = new Musteri()
            {
                ID = (int)reader[_ID],
                UserName = reader[_UserName].ToString(),
                Adi = reader[_Adi].ToString(),
                Soyadi = reader[_Soyadi].ToString(),
                Email = reader[_Email].ToString(),
                Telefon = reader[_Telefon].ToString(),
                DogumTarih = (DateTime)(reader[_DogumTarih].ToString().Length == 0 ? DateTime.MinValue : reader[_DogumTarih]),
                Sifre = reader[_Sifre].ToString(),
                Sil = (bool)reader[_Sil]
            };
            Debug.WriteLine(musteris);
            reader.Close();
            return musteris;
        }

        public override void Insert(Musteri item)
        {
            throw new NotImplementedException();
        }

        public override void Update(Musteri item)
        {

        }

        public List<Musteri> Arama(Musteri Aranan)
        {
            string sorgu = string.Format("select * from {0} where 1=1", _Table);
            if (Aranan.Adi != null && Aranan.Adi.Length != 0)
                sorgu += string.Format("and Adi like '%{0}%'", Aranan.Adi);
            if (Aranan.Soyadi != null && Aranan.Soyadi.Length != 0)
                sorgu += string.Format("and SoyAdi like '%{0}%'", Aranan.Soyadi);
            if(Aranan.Email != null && Aranan.Email.Length != 0)
                sorgu += string.Format("and Email like '%{0}%'", Aranan.Email);
            if(Aranan.UserName != null && Aranan.UserName.Length !=0 )
                sorgu += string.Format("and UserName like '%{0}%'", Aranan.UserName);
            Debug.WriteLine(sorgu + "Sorgu ");
            SqlDataReader reader = getReader(sorgu);
            List<Musteri> musteris = new List<Musteri>();
            while (reader.Read())
            {
                musteris.Add(new Musteri()
                {
                    ID = (int)reader[_ID],
                    UserName = reader[_UserName].ToString(),
                    Adi = reader[_Adi].ToString(),
                    Soyadi = reader[_Soyadi].ToString(),
                    Email = reader[_Email].ToString(),
                    Telefon = reader[_Telefon].ToString(),
                    DogumTarih = (DateTime)(reader[_DogumTarih].ToString().Length == 0 ? DateTime.MinValue : reader[_DogumTarih]),
                    Sifre = reader[_Sifre].ToString(),
                    Sil = (bool)reader[_Sil]
                });
            }
            reader.Close();
            return musteris;
        }
    }
}