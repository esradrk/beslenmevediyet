using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Okulapp.DAL
{
    public class Helper
    {
        public string cstr = ConfigurationManager.ConnectionStrings["cstr"].ConnectionString;  // Veritabanı bağlantı dizesi

        // SQL komutunu çalıştırıp etkilenen satır sayısını döndüren metot
        public int ExecuteNonQuery(string cmdtext, SqlParameter[] p = null)
        {
            using (var cn = new SqlConnection(cstr))  // Bağlantı nesnesi oluşturulur ve using bloğu içinde otomatik olarak kapatılır
            {
                using (var cmd = new SqlCommand(cmdtext, cn))  // Komut nesnesi oluşturulur ve using bloğu içinde otomatik olarak kapatılır
                {
                    if (p != null)
                    {
                        cmd.Parameters.AddRange(p);  // Parametreler komuta eklenir
                    }
                    cn.Open();  // Bağlantı açılır
                    return cmd.ExecuteNonQuery();  // Komut çalıştırılır ve etkilenen satır sayısı döndürülür
                }
            }
        }

        // SQL komutunu çalıştırıp tek bir değer döndüren metot
        public object ExecuteScalar(string cmdtext, SqlParameter[] p = null)
        {
            using (var cn = new SqlConnection(cstr))  // Bağlantı nesnesi oluşturulur ve using bloğu içinde otomatik olarak kapatılır
            {
                using (var cmd = new SqlCommand(cmdtext, cn))  // Komut nesnesi oluşturulur ve using bloğu içinde otomatik olarak kapatılır
                {
                    if (p != null)
                    {
                        cmd.Parameters.AddRange(p);  // Parametreler komuta eklenir
                    }
                    cn.Open();  // Bağlantı açılır
                    return cmd.ExecuteScalar();  // Komut çalıştırılır ve ilk sütunun ilk satırındaki değer döndürülür
                }
            }
        }

        // SQL sorgusunu çalıştırıp sonuçları DataTable olarak döndüren metot
        public DataTable ExecuteQuery(string cmdtext, SqlParameter[] parameters = null)
        {
            using (var cn = new SqlConnection(cstr))  // Bağlantı nesnesi oluşturulur ve using bloğu içinde otomatik olarak kapatılır
            {
                using (var cmd = new SqlCommand(cmdtext, cn))  // Komut nesnesi oluşturulur ve using bloğu içinde otomatik olarak kapatılır
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);  // Parametreler komuta eklenir
                    }
                    try
                    {
                        cn.Open();  // Bağlantı açılır
                        var dt = new DataTable();  // Yeni bir DataTable oluşturulur
                        using (var reader = cmd.ExecuteReader())  // Komutu çalıştırıp SqlDataReader nesnesi oluşturulur
                        {
                            dt.Load(reader);  // SqlDataReader'dan DataTable doldurulur
                        }
                        return dt;  // DataTable döndürülür
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Veritabanı işlemi sırasında hata oluştu.", ex);  // SQL hata durumunda özel bir hata fırlatılır
                    }
                }
            }
        }

        // SQL sorgusunu çalıştırıp SqlDataReader nesnesi döndüren metot
        public SqlDataReader ExecuteReader(string cmdtext, SqlParameter[] p = null)
        {
            SqlConnection cn = new SqlConnection(cstr);  // Bağlantı nesnesi oluşturulur
            SqlCommand cmd = new SqlCommand(cmdtext, cn);  // Komut nesnesi oluşturulur

            if (p != null)
            {
                cmd.Parameters.AddRange(p);  // Parametreler komuta eklenir
            }

            cn.Open();  // Bağlantı açılır
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);  // Komut çalıştırılır ve SqlDataReader nesnesi döndürülür (bağlantı kapatıldığında otomatik olarak kapanır)
        }
    }
}