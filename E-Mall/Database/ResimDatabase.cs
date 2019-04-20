using E_Mall.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace E_Mall.Database
{
    public class ResimDatabase:Database<Resim>
    {
        private string _ID { get; } = "ID";
        private string _Yol { get; } = "Yol";
        private string _UrunID { get; } = "UrunID";
        private string _Sil { get; } = "Sil";
        private string _Tablo { get; } = "Resim";

        public override void Delete(int ID)
        {
            string sorgu = string.Format("delete from {0} where {1}={2}", _Tablo, _ID, ID);
            DeleteCommand(sorgu);
        }

        public override List<Resim> GetAll()
        {
            throw new NotImplementedException();
        }

        public override List<Resim> GetForAdi(string value)
        {
            throw new NotImplementedException();
        }
        public Resim GetForUrunID(int ID)
        {
            string sorgu = string.Format("select * from {0} where {1} = {2}", _Tablo, _UrunID, ID);
            Debug.WriteLine(sorgu);
            Debug.WriteLine("GetUrunID");
            SqlDataReader reader = getReader(sorgu);
            if (!reader.Read())
                return null;
            Resim item = new Resim()
            {
                ID = (int)reader[_ID],
                Path = reader[_Yol].ToString()
            };
            reader.Close();
            return item;
        }

        public override Resim GetForID(int ID)
        {
            string sorgu = string.Format("select * from {0} where {1}={2}", _Tablo, _ID, ID);
            SqlDataReader reader = getReader(sorgu);
            if (!reader.Read())
                return null;
            Resim item = new Resim()
            {
                ID = (int)reader[_ID],
                Path = reader[_Yol].ToString()
            };
            reader.Close();
            return item;
        }

        /// <summary>
        /// Kullanılmayan
        /// </summary>
        /// <param name="item"></param>
        public override void Insert(Resim item)
        {
            string sorgu = string.Format("insert into {0}({1}) values({2})", _Tablo, _Yol, item.Path);
            InsertCommand(sorgu);
        }

        public Resim Insert(HttpPostedFileBase file, string url)
        {
            string path = HttpContext.Current.Server.MapPath(url);
            file.SaveAs(path);
            SqlCommand command = getCommand(string.Format("insert into {0}({1}) OUTPUT Inserted.ID values('{2}');", _Tablo, _Yol, url));
            return new Resim()
            {
                ID = (int)command.ExecuteScalar(),
                Path = path
            };
        }

        /// <summary>
        /// Kullanılmayan Fonksiyon
        /// </summary>
        /// <param name="item"></param>
        public override void Update(Resim item)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Urunler için kullanılan Resim Ekleme
        /// </summary>
        /// <param name="file"></param>
        /// <param name="url"></param>
        /// <param name="UrunID"></param>
        /// <returns></returns>
        public Resim Insert(HttpPostedFileBase file, string url, int UrunID)
        {
            string path = HttpContext.Current.Server.MapPath(url);
            file.SaveAs(path);
            SqlCommand command = getCommand(string.Format("insert into {0}({1},{3}) OUTPUT Inserted.ID values('{2}',{4});", _Tablo, _Yol, url,_UrunID,UrunID));
            return new Resim()
            {
                ID = (int)command.ExecuteScalar(),
                Path = path
            };
        }
        public Resim Update(HttpPostedFileBase file, string url, int ID)
        {
            string path = HttpContext.Current.Server.MapPath(url);
            file.SaveAs(path);
            UpdateCommand(string.Format("update {0} set {1}='{2}' where {3}={4}", _Tablo, _Yol, url, _ID, ID));
            return new Resim()
            {
                ID = ID,
                Path = path
            };
        }
    }
}