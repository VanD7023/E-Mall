using E_Mall.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace E_Mall.Database
{
    public class SatisDurumDatabase : Database<SatisDurum>
    {
        public override void Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public override List<SatisDurum> GetAll()
        {
            List<SatisDurum> durums = new List<SatisDurum>();
            string sorgu = "select * from SatisDurum";
            SqlDataReader rd = getReader(sorgu);
            while (rd.Read())
            {
                durums.Add(new SatisDurum()
                {
                    ID = (int)rd["ID"],
                    Adi = rd["Adi"].ToString()
                });
            }
            rd.Close();
            return durums;
        }

        public override List<SatisDurum> GetForAdi(string value)
        {
            throw new NotImplementedException();
        }

        public override SatisDurum GetForID(int ID)
        {
            throw new NotImplementedException();
        }

        public override void Insert(SatisDurum item)
        {
            throw new NotImplementedException();
        }

        public override void Update(SatisDurum item)
        {
            throw new NotImplementedException();
        }
    }
}