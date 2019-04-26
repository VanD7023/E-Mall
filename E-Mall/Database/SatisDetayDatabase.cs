using E_Mall.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace E_Mall.Database
{
    public class SatisDetayDatabase: Database<SatisDetay>
    {
        string _ID { get; } = "ID";
        string _SatisID { get; } = "SatisID";
        string _UrunID { get; } = "UrunID";
        string _Fiyat { get; } = "Fiyat";
        string _IndirimID { get; } = "IndirimID";
        string _IndirimOran { get; } = "IndirimOran";
        string _Adet { get; } = "Adet";
        string _Table { get; } = "SatisDetay";
        string _Table2 { get; } = "SatisDurum";

        public override void Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public override List<SatisDetay> GetAll()
        {
            string sorgu = string.Format("select * from {0} ", _Table);
            List<SatisDetay> satisDetay = new List<SatisDetay>();
            SqlDataReader reader = getReader(sorgu);
            while (reader.Read())
            {
                satisDetay.Add(new SatisDetay()
                {
                    ID = (int)reader[_ID],
                    SatısID = (int)reader[_SatisID],
                    UrunID = (int)reader[_UrunID],
                    Fiyat = float.Parse(reader[_Fiyat].ToString()),
                    IndirimID = (int)reader[_IndirimID],
                    IndirimOran = (int)reader[_IndirimOran],
                    Adet = (int)reader[_Adet]
                });
            }
            reader.Close();
            return satisDetay;
        }

        public override List<SatisDetay> GetForAdi(string value)
        {
            throw new NotImplementedException();
        }

        public override SatisDetay GetForID(int ID)
        {
            throw new NotImplementedException();
        }

        public override void Insert(SatisDetay item)
        {
            throw new NotImplementedException();
        }

        public override void Update(SatisDetay item)
        {
            throw new NotImplementedException();
        }
        public List<SatisDetay> getForSatisID(int ID)
        {
            string sorgu = string.Format("select * from {0} where {1} = {2}", _Table, _SatisID, ID);
            SqlDataReader reader = getReader(sorgu);
            List<SatisDetay> detays = new List<SatisDetay>();
            while (reader.Read())
            {
                detays.Add(new SatisDetay()
                {
                    ID = reader[_ID].getValue<int>(),
                    SatısID = reader[_SatisID].getValue<int>(),
                    UrunID = reader[_UrunID].getValue<int>(),
                    Fiyat = reader[_Fiyat].getValue<float>(),//float.Parse(reader[_Fiyat].ToString())
                    IndirimID =reader[_IndirimID].getValue<int>(),
                    IndirimOran = reader[_IndirimOran].getValue<int>(),
                    Adet = (int)reader[_Adet],
                });
            }
            reader.Close();
            UrunDatabase udatabase = new UrunDatabase();
            foreach (SatisDetay item in detays)
            {
                item.Urun = udatabase.GetForID(item.UrunID);
            }
            return detays;
        }
       /* public SatisDurum getDurum(int ID)
        {
            string sorgu = string.Format("select * from {0} where {1} = {2}",);
        }*/
       
    }
   
}