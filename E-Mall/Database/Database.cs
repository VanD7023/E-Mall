using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace E_Mall.Database
{
    public abstract class Database<T>
    {
        /// <summary>
        /// Girilen Sorguya Uygun olarak SqlDataReader nesnesi oluşturur
        /// </summary>
        /// <param name="sorgu"></param>
        /// <returns></returns>
        protected SqlDataReader getReader(string sorgu)
        {
            return getCommand(sorgu).ExecuteReader();
        }

        /// <summary>
        /// Girilen Sorguya uygun SqlCommand nesnesi oluşturur 
        /// </summary>
        /// <param name="sorgu"></param>
        /// <returns></returns>
        protected SqlCommand getCommand(string sorgu)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["baglanti"].ToString());
            connection.Open();
            return new SqlCommand(sorgu, connection);
        }

        /// <summary>
        /// Girilen Sorgunun İnsert Olmasını Sağlar
        /// </summary>
        /// <param name="sorgu"> İnsert Yapılacak Sorgu</param>
        /// <returns>Değişiklik yapılan satır sayısı</returns>
        protected int InsertCommand(string sorgu)
        {
            return (int)getCommand(sorgu).ExecuteNonQuery();
        }

        /// <summary>
        /// Girilen Sorguya göre veri silinmesi gerçekleştirir
        /// </summary>
        /// <param name="sorgu">Silinecek Sorgu</param>
        /// <returns>Değişikliğe uğrayan satır sayısı</returns>
        protected int DeleteCommand(string sorgu)
        {
            return (int)getCommand(sorgu).ExecuteNonQuery();
        }

        public abstract List<T> GetAll();

        public abstract void Insert(T item);

        public abstract void Delete(int ID);

        public abstract T GetForID(int ID);

        public abstract List<T> GetForAdi(string value);

    }
}