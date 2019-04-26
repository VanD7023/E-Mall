using E_Mall.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace E_Mall.Database
{
    public class AdresDatabase : Database<Adres>
    {
        string _ID { get; } = "ID";
        string _AcikAdres { get; } = "Adres";
        string _AdresAdi { get; } = "AdresAdi";
        string _Sil { get; } = "Sil";
        string _Table { get; } = "Adres";

        public override void Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public override List<Adres> GetAll()
        {
            throw new NotImplementedException();
        }

        public override List<Adres> GetForAdi(string value)
        {
            throw new NotImplementedException();
        }

        public override Adres GetForID(int ID)
        {
            string sorgu = string.Format("select * from {0} where {1} = {2} ", _Table , ID, _ID);
            SqlDataReader reader = getReader(sorgu);
            if (reader.Read())
                return new Adres();
            Adres adres = new Adres()
            {
                ID =reader[_ID].getValue<int>(),
                AcikAdres = reader[_AcikAdres].ToString(),
                AdresAdi = reader[_AdresAdi].ToString(),
            };
            reader.Close();
            return adres;
        }

        public override void Insert(Adres item)
        {
            throw new NotImplementedException();
        }

        public override void Update(Adres item)
        {
            throw new NotImplementedException();
        }
    }
}