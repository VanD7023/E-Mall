using E_Mall.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace E_Mall.Database
{
    public class LoginDatabase
    {
        string _ID { get; } = "ID";
        string _KullaniciAdi { get; } = "KullaniciAdi";
        string _Sifre { get; } = "Sifre";
        string _Table { get; } = "AdminLogin";

        public Login Kontrol(Login login)
        {
            string sorgu = string.Format("select * from {0} where {1} = '{2}' and {3} = '{4}'", _Table, _KullaniciAdi, login.KullaniciAdi, _Sifre, login.Sifre);
            Debug.WriteLine(login.KullaniciAdi);
            Debug.WriteLine("Login sorgu ==> " + sorgu);
            SqlDataReader reader = getReader(sorgu);
            if (!reader.Read())
                return null;
            Login item = new Login()
            {
                ID = (int)reader[_ID],
                KullaniciAdi = reader[_KullaniciAdi].getValue<string>(),
            };
            reader.Close();
            return item;
        }
        protected SqlCommand getCommand(string sorgu)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["baglanti"].ToString());
            connection.Open();
            return new SqlCommand(sorgu, connection);
        }
        protected SqlDataReader getReader(string sorgu)
        {
            return getCommand(sorgu).ExecuteReader();
        }
    }
}