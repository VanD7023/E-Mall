using E_Mall.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace E_Mall.Database
{
    public class IndirimDatabase : Database<Indirim>
    {
        string _ID { get; } = "ID";
        string _Adi { get; } = "Adi";
        string _TutarOrani { get; } = "Oran";
        string _BaslangicTarih { get; } = "BaslangicTarih";
        string _BitisTarih { get; } = "BitisTarih";
        string _Sil { get; } = "Sil";
        string _Table { get; } = "Indirim";

        public override void Delete(int ID)
        {
            string sorgu = string.Format("update {0} set  {1}='True' where {2}={3} ", _Table, _Sil, _ID, ID);
            DeleteCommand(sorgu);
        }

        public override List<Indirim> GetAll()
        {
            string sorgu = string.Format("select * from {0} where not ISNULL(Sil,'False')='True'", _Table);
            Debug.WriteLine("Indirim getAll sogru = ", sorgu);
            List<Indirim> indirims = new List<Indirim>();
            SqlDataReader reader = getReader(sorgu);
            while (reader.Read())
            {
                indirims.Add(new Indirim()
                {
                    ID = reader[_ID].getValue<int>(),
                    Adi = reader[_Adi].ToString(),
                    TutarOrani = reader[_TutarOrani].getValue<int>(),
                    BaslangicTarih = reader[_BaslangicTarih].getValue<DateTime>(),
                    BitisTarih = reader[_BitisTarih].getValue<DateTime>(),
                    Sil = (bool)reader[_Sil]
                });
            }
            reader.Close();
            return indirims;
        }

        public List<Indirim> Arama(Indirim aranan)
        {
            Debug.WriteLine(aranan.BaslangicTarih.ToString());
            string sorgu = string.Format("select * from {0} where not ISNULL(Sil,'False')='True' ", _Table);
            if (aranan.Adi != null && aranan.Adi.Length != 0)
                sorgu += string.Format("and Adi like '%{0}%'",aranan.Adi);
            if (aranan.BaslangicTarih != null && aranan.BaslangicTarih.CompareTo(DateTime.MinValue) != 0)
                sorgu += string.Format("and BaslangicTarih >= '{0}'", aranan.BaslangicTarih.ToString("yyyy-MM-dd HH:mm:ss"));
            if (aranan.BitisTarih != null && aranan.BitisTarih.CompareTo(DateTime.MinValue) != 0)
                sorgu += string.Format("and BitisTarih <= '{0}'", aranan.BitisTarih.ToString("yyyy-MM-dd HH:mm:ss"));
            Debug.WriteLine("Indim arama sorgu ==>",sorgu);
            SqlDataReader reader = getReader(sorgu);
            List<Indirim> indirims = new List<Indirim>();
            while (reader.Read())
            {
                indirims.Add(new Indirim()
                {
                    ID = reader[_ID].getValue<int>(),
                    Adi = reader[_Adi].ToString(),
                    TutarOrani = reader[_TutarOrani].getValue<int>(),
                    BaslangicTarih = reader[_BaslangicTarih].getValue<DateTime>(),
                    BitisTarih = reader[_BitisTarih].getValue<DateTime>(),
                    Sil = (bool)reader[_Sil]
                });
            }
            reader.Close();
            return indirims;
        }

        public override List<Indirim> GetForAdi(string value)
        {
            throw new NotImplementedException();
        }

        public override Indirim GetForID(int ID)
        {
            string sorgu = string.Format("select * from {2} where {0} = {1} ", _ID, ID, _Table);
            SqlDataReader reader = getReader(sorgu);
            if (!reader.Read())
                return null;
            Indirim item = new Indirim()
            {
                ID = reader[_ID].getValue<int>(),
                Adi = reader[_Adi].ToString(),
                TutarOrani = reader[_TutarOrani].getValue<int>(),
                BaslangicTarih = reader[_BaslangicTarih].getValue<DateTime>(),
                BitisTarih = reader[_BitisTarih].getValue<DateTime>(),
                Sil = (bool)reader[_Sil]
            };
            reader.Close();
            return item;
        }

        public override void Insert(Indirim item)
        {
            string sorgu = string.Format("insert into {0} ({1},{2},{3},{4}) values ('{5}',{6},'{7}','{8}')", _Table, _Adi, _TutarOrani, _BaslangicTarih, _BitisTarih, item.Adi, item.TutarOrani, item.BaslangicTarih.ToString("yyyy-MM-dd HH:mm:ss"), item.BitisTarih.ToString("yyyy-MM-dd HH:mm:ss"));
            Debug.WriteLine("Indirim Ekle Sorgu ==>" + sorgu);
            InsertCommand(sorgu);
        }

        public override void Update(Indirim item)
        {
            string sorgu = string.Format("update {0} set {1} = '{2}', {3} = {4}, {5} = '{6}', {7}='{8}' where {9}={10}",_Table,_Adi,item.Adi,_TutarOrani,item.TutarOrani,_BaslangicTarih,item.BaslangicTarih.ToString("yyyy-MM-dd HH:mm:ss"),_BitisTarih,item.BitisTarih.ToString("yyyy-MM-dd HH:mm:ss"),_ID,item.ID);
            Debug.WriteLine("Update Sorgu ==>" + sorgu);
            UpdateCommand(sorgu);
        }
    }
}