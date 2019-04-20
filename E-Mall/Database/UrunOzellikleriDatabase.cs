using E_Mall.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace E_Mall.Database
{
    public class UrunOzellikleriDatabase : Database<UrunOzellikleri>
    {
        string _Id { get; } = "ID";
        string _Adi { get; } = "Adi";
        string _Deger { get; } = "Deger";
        string _Table { get; } = "Nitelik";
        string _Sil { get; } = "Sil";
        public override void Delete(int ID)
        {
            string sorgu = string.Format("update {0} set  {1}='True' where {2}={3} ", _Table, _Sil, _Id, ID);
            DeleteCommand(sorgu);
        }

        public override List<UrunOzellikleri> GetAll()
        {
            string sorgu = string.Format("select * from {0} where not ISNULL(Sil,'False')='True'", _Table);
            List<UrunOzellikleri> ozelliks = new List<UrunOzellikleri>();
            SqlDataReader reader = getReader(sorgu);
            while (reader.Read())
                ozelliks.Add(new UrunOzellikleri()
                {
                    ID = (int)reader[_Id],
                    Adi = reader[_Adi].ToString(),
                    Deger = reader[_Deger].ToString(),
                    Sil = false
                });
            reader.Close();
            return ozelliks;
        }

        public override List<UrunOzellikleri> GetForAdi(string value)
        {
            string sorgu = string.Format("select * from {2} where {0} like '%{1}%' and not ISNULL(Sil,'False')='True' ", _Adi, value, _Table);
            List<UrunOzellikleri> ozelliks = new List<UrunOzellikleri>();
            SqlDataReader reader = getReader(sorgu);
            while (reader.Read())
                ozelliks.Add(new UrunOzellikleri()
                {
                    ID = (int)reader[_Id],
                    Adi = reader[_Adi].ToString(),
                    Deger = reader[_Deger].ToString(),
                    Sil = false
                });
            reader.Close();
            return ozelliks;
        }

        public override UrunOzellikleri GetForID(int ID)
        {
            throw new NotImplementedException();
        }

        public override void Insert(UrunOzellikleri item)
        {
            string sorgu = string.Format("insert into {0}({1},{2}) values('{3}','{4}')", _Table, _Adi, _Deger, item.Adi, item.Deger);
            InsertCommand(sorgu);
        }

        public override void Update(UrunOzellikleri item)
        {
            string sorgu = string.Format("update {0} set {1}='{2}', {3}='{4}' where {5}={6}", _Table, _Adi, item.Adi, _Deger, item.Deger, _Id, item.ID);
            UpdateCommand(sorgu);
        }
    }
}