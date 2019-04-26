using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace E_Mall.Database
{
    public static class objectExtensions
    {
       /// <summary>
       /// 
       /// </summary>
       /// <typeparam name="T"></typeparam>
       /// <param name="o"></param>
       /// <returns></returns>
        public static T getValue<T>(this object o)
        {
            if (o == null || o.ToString().Length == 0)
                return default(T);
            if (o is T)
                return (T)o;
            else
                return (T)Convert.ChangeType(o, typeof(T));
        }
    }
}