using E_Mall.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace E_Mall.Database
{
    public class KategoriDatabase : Database<Kategori>
    {
        string _Id { get; } = "ID";
        string _Adi { get; } = "Adi";
        string _ResimID { get; } = "ResimID";
        string _Aciklama { get; } = "Aciklama";
        string _Sil { get; } = "Sil";
        string _UstID { get; } = "UstID";
        string _Table { get; } = "Kategori";

        public override void Insert(Kategori item)
        {
            string sorgu = string.Format("insert into {8}({0},{1},{2},{3}) values('{4}','{5}',{6},{7})", _Adi, _Aciklama, _UstID, _ResimID, item.Adi, item.Aciklama, 1, 1, _Table);
            InsertCommand(sorgu);
        }

        public override List<Kategori> GetAll()
        {
            string sorgu = string.Format("select * from {0}", _Table);
            List<Kategori> kategoris = new List<Kategori>();
            SqlDataReader reader = getReader(sorgu);
            while (reader.Read())
                kategoris.Add(new Kategori()
                {
                    ID = (int)reader[_Id],
                    Adi = reader[_Adi].ToString(),
                    Aciklama = reader[_Aciklama].ToString(),
                    ResimID = (int)reader[_ResimID],
                    UstID = (int)reader[_UstID],
                    Sil = false
                });
            reader.Close();
            return kategoris;
        }

        public override void Delete(int ID)
        {
            string sorgu = string.Format("delete from {2} where {0} = {1}", _Id, ID, _Table);
            DeleteCommand(sorgu);
        }
        public override Kategori GetForID(int ID)
        {
            string sorgu = string.Format("select * from {2} where {0} = {1} ", _Id, ID, _Table);
            SqlDataReader reader = getReader(sorgu);
            if (!reader.Read())
                return null;
            Kategori item = new Kategori()
            {
                ID = (int)reader[_Id],
                Adi = reader[_Adi].ToString(),
                Aciklama = reader[_Aciklama].ToString(),
                ResimID = (int)reader[_ResimID],
                UstID = (int)reader[_UstID],
                Sil = false
            };
            reader.Close();
            return item;
        }

        public override List<Kategori> GetForAdi(string value)
        {
            List<Kategori> items = new List<Kategori>();
            string sorgu = string.Format("select * from {2} where {0} like '%{1}%'", _Adi, value, _Table);
            SqlDataReader reader = getReader(sorgu);
            while (reader.Read())
                items.Add(new Kategori()
                {
                    ID = (int)reader[_Id],
                    Adi = reader[_Adi].ToString(),
                    Aciklama = reader[_Aciklama].ToString(),
                    ResimID = (int)reader[_ResimID],
                    UstID = (int)reader[_UstID],
                    Sil = false
                });
            reader.Close();
            return items;
        }

    }
}