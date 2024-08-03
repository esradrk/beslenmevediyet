using Okulapp.DAL;
using okulAppModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Okulapp.BLL
{
    public class diyetbl
    {
        // Yeni üye kaydı ekleme işlemi
        public bool uyeekle(uye u)
        {
            var hlp = new Helper(); // Veritabanı işlemlerini yapmak için Helper sınıfı kullanılacak.
            var p = new SqlParameter[] // Parametreler oluşturuluyor, SQL injection önleme için kullanılıyor.
            {
                new SqlParameter("@name", u.name),
                new SqlParameter("@email", u.email),
                new SqlParameter("@sifre", u.sifre)
            };
            // INSERT sorgusu çalıştırılıyor, etkilenen satır sayısı kontrol ediliyor.
            return hlp.ExecuteNonQuery("INSERT INTO uyeler (name, email, sifre) VALUES (@name, @email, @sifre)", p) > 0;
        }

        // Kullanıcı girişi yapma işlemi
        public int GirisYap(uye u2)
        {
            var hlp = new Helper(); // Veritabanı işlemlerini yapmak için Helper sınıfı kullanılacak.
            var p = new SqlParameter[] // Parametreler oluşturuluyor, SQL injection önleme için kullanılıyor.
            {
                new SqlParameter("@name", u2.name),
                new SqlParameter("@sifre", u2.sifre)
            };
            // SELECT sorgusu ile kullanıcı adı ve şifre kontrol ediliyor, kullanıcı ID döndürülüyor.
            var result = hlp.ExecuteScalar("SELECT User_id FROM uyeler WHERE name=@name AND sifre=@sifre", p);
            return result != null ? (int)result : -1; // Kullanıcı bulunursa ID, bulunmazsa -1 döndürülüyor.
        }

        // Kullanıcının profil bilgilerini eklemek için kullanılan metod
        public bool profilekle(int user_id, ProfilBilgileri profil)
        {
            var hlp = new Helper(); // Veritabanı işlemlerini yapmak için Helper sınıfı kullanılacak.
            var p = new SqlParameter[] // Parametreler oluşturuluyor, SQL injection önleme için kullanılıyor.
            {
                new SqlParameter("@user_id", user_id),
                new SqlParameter("@Yas", profil.Yas),
                new SqlParameter("@Cinsiyet", profil.Cinsiyet),
                new SqlParameter("@Boy", profil.Boy),
                new SqlParameter("@Kilo", profil.Kilo),
                new SqlParameter("@BMI", profil.BMI),
                new SqlParameter("@FizikselAktiviteDuzeyi", profil.FizikselAktiviteDuzeyi),
                new SqlParameter("@SaglikDurumu", profil.SaglikDurumu),
                new SqlParameter("@BesinAlerjileri", profil.BesinAlerjileri),
                new SqlParameter("@adsoyad", profil.adsoyad),
            };

            // INSERT sorgusu ile profil bilgileri ekleniyor.
            string query = "INSERT INTO ProfilBilgileri (user_id, Yas, Cinsiyet, Boy, Kilo, BMI, FizikselAktiviteDuzeyi, " +
                           "SaglikDurumu, BesinAlerjileri, adsoyad) " +
                           "VALUES (@user_id, @Yas, @Cinsiyet, @Boy, @Kilo, @BMI, @FizikselAktiviteDuzeyi, @SaglikDurumu, " +
                           "@BesinAlerjileri, @adsoyad)";

            return hlp.ExecuteNonQuery(query, p) > 0; // Etkilenen satır sayısı kontrol edilerek işlem başarısı döndürülüyor.
        }

        // Kullanıcının profil bilgilerini güncellemek için kullanılan metod
        public bool ProfilGuncelle(int user_id, ProfilBilgileri profil)
        {
            var hlp = new Helper(); // Veritabanı işlemlerini yapmak için Helper sınıfı kullanılacak.
            var p = new SqlParameter[] // Parametreler oluşturuluyor, SQL injection önleme için kullanılıyor.
            {
                new SqlParameter("@user_id", user_id),
                new SqlParameter("@Yas", profil.Yas),
                new SqlParameter("@Cinsiyet", profil.Cinsiyet),
                new SqlParameter("@Boy", profil.Boy),
                new SqlParameter("@Kilo", profil.Kilo),
                new SqlParameter("@BMI", profil.BMI),
                new SqlParameter("@FizikselAktiviteDuzeyi", profil.FizikselAktiviteDuzeyi),
                new SqlParameter("@SaglikDurumu", profil.SaglikDurumu),
                new SqlParameter("@BesinAlerjileri", profil.BesinAlerjileri),
                new SqlParameter("@adsoyad", profil.adsoyad),
            };

            // UPDATE sorgusu ile profil bilgileri güncelleniyor.
            string query = "UPDATE ProfilBilgileri SET Yas=@Yas, Cinsiyet=@Cinsiyet, Boy=@Boy, Kilo=@Kilo, BMI=@BMI, " +
                           "FizikselAktiviteDuzeyi=@FizikselAktiviteDuzeyi, SaglikDurumu=@SaglikDurumu, " +
                           "BesinAlerjileri=@BesinAlerjileri, adsoyad=@adsoyad " +
                           "WHERE user_id=@user_id";

            return hlp.ExecuteNonQuery(query, p) > 0; // Etkilenen satır sayısı kontrol edilerek işlem başarısı döndürülüyor.
        }

        // Kullanıcının profil bilgilerinin belirli alanlarını güncellemek için kullanılan metod
        public bool ProfilBilgileriniGuncelle(int user_id, string beslenmeTercihi, string diyetYapmaSebebi, decimal hedefKilo)
        {
            var hlp = new Helper(); // Veritabanı işlemlerini yapmak için Helper sınıfı kullanılacak.
            var p = new SqlParameter[] // Parametreler oluşturuluyor, SQL injection önleme için kullanılıyor.
            {
                new SqlParameter("@user_id", user_id),
                new SqlParameter("@beslenmetercihi", beslenmeTercihi),
                new SqlParameter("@diyetyapmasebebi", diyetYapmaSebebi),
                new SqlParameter("@hedefkilo", hedefKilo)
            };

            // UPDATE sorgusu ile profil bilgileri güncelleniyor.
            string query = "UPDATE ProfilBilgileri SET beslenmetercihi=@beslenmetercihi, diyetyapmasebebi=@diyetyapmasebebi, hedefkilo=@hedefkilo WHERE user_id=@user_id";

            return hlp.ExecuteNonQuery(query, p) > 0; // Etkilenen satır sayısı kontrol edilerek işlem başarısı döndürülüyor.
        }

        // Kullanıcının ID'sine göre profil bilgilerini getiren metod
        public ProfilBilgileri GetProfilByUserId(int userId)
        {
            var hlp = new Helper(); // Veritabanı işlemlerini yapmak için Helper sınıfı kullanılacak.
            var p = new SqlParameter[] // Parametreler oluşturuluyor, SQL injection önleme için kullanılıyor.
            {
                new SqlParameter("@user_id", userId)
            };

            // SELECT sorgusu ile kullanıcının profil bilgileri alınıyor.
            var reader = hlp.ExecuteReader("SELECT * FROM ProfilBilgileri WHERE user_id = @user_id", p);

            if (reader.Read()) // Veri bulunduysa ProfilBilgileri nesnesi oluşturulup döndürülüyor.
            {
                return new ProfilBilgileri
                {
                    Yas = reader.GetInt32(reader.GetOrdinal("Yas")),
                    Cinsiyet = reader.GetString(reader.GetOrdinal("Cinsiyet")),
                    Boy = reader.GetDecimal(reader.GetOrdinal("Boy")),
                    Kilo = reader.GetDecimal(reader.GetOrdinal("Kilo")),
                    BMI = reader.GetDecimal(reader.GetOrdinal("BMI")),
                    FizikselAktiviteDuzeyi = reader.GetString(reader.GetOrdinal("FizikselAktiviteDuzeyi")),
                    SaglikDurumu = reader.GetString(reader.GetOrdinal("SaglikDurumu")),
                    BesinAlerjileri = reader.GetString(reader.GetOrdinal("BesinAlerjileri")),
                    adsoyad = reader.GetString(reader.GetOrdinal("adsoyad"))
                };
            }

            return null; // Veri bulunamadıysa null döndürülüyor.
        }
    
    public bool KullaniciAnalizEkle(kullanicianaliz analiz)
        {
            var hlp = new Helper();
            var p = new SqlParameter[]
            {
                new SqlParameter("@KullaniciID", analiz.KullaniciID),
                new SqlParameter("@Kilo", analiz.Kilo),
                new SqlParameter("@BMIndeks", analiz.BMIndeks),
                new SqlParameter("@gunluksu", analiz.gunluksu),
                new SqlParameter("@gunlukKalori", analiz.gunlukKalori)
            };

            string query = "INSERT INTO KullaniciAnaliz (KullaniciID, Kilo, BMIndeks, gunluksu, gunlukKalori) " +
                           "VALUES (@KullaniciID, @Kilo, @BMIndeks, @gunluksu, @gunlukKalori)";

            return hlp.ExecuteNonQuery(query, p) > 0;
        }

        public DataTable GetKullaniciAnalizByUserId(int userId)
        {
            var hlp = new Helper();
            var p = new SqlParameter[]
            {
                new SqlParameter("@user_id", userId)
            };

            string query = "SELECT Kilo, BMIndeks, gunluksu, gunlukKalori FROM KullaniciAnaliz WHERE KullaniciID = @user_id";

            var reader = hlp.ExecuteReader(query, p);
            var table = new DataTable();
            table.Load(reader);

            table.Columns.Add("BMICategory", typeof(string));
            foreach (DataRow row in table.Rows)
            {
                decimal bmi = (decimal)row["BMIndeks"];
                row["BMICategory"] = HealthCalculations.BMIkatagori(bmi);
            }

            table.Columns["Kilo"].ColumnName = "Alması Gereken Kilo";
            table.Columns["gunluksu"].ColumnName = "Alması Gereken Su";
            table.Columns["gunlukKalori"].ColumnName = "Alması Gereken Kalori";
            return table;
        }

        public kullanicianaliz GetLatestKullaniciAnalizByUserId(int userId)
        {
            var hlp = new Helper();
            var p = new SqlParameter[]
            {
                new SqlParameter("@user_id", userId)
            };

            string query = "SELECT TOP 1 * FROM KullaniciAnaliz WHERE KullaniciID = @user_id ORDER BY AnalizID DESC";
            var reader = hlp.ExecuteReader(query, p);

            if (reader.Read())
            {
                return new kullanicianaliz
                {
                    AnalizID = reader.GetInt32(reader.GetOrdinal("AnalizID")),
                    KullaniciID = reader.GetInt32(reader.GetOrdinal("KullaniciID")),
                    Kilo = reader.GetDecimal(reader.GetOrdinal("Kilo")),
                    BMIndeks = reader.GetDecimal(reader.GetOrdinal("BMIndeks")),
                    gunluksu = reader.GetDecimal(reader.GetOrdinal("gunluksu")),
                    gunlukKalori = reader.GetInt32(reader.GetOrdinal("gunlukKalori"))
                };
            }

            return null;
        }

        public bool KullaniciAnalizGuncelle(kullanicianaliz analiz)
        {
            var hlp = new Helper();
            var p = new SqlParameter[]
            {
                new SqlParameter("@AnalizID", analiz.AnalizID),
                new SqlParameter("@KullaniciID", analiz.KullaniciID),
                new SqlParameter("@Kilo", analiz.Kilo),
                new SqlParameter("@BMIndeks", analiz.BMIndeks),
                new SqlParameter("@gunluksu", analiz.gunluksu),
                new SqlParameter("@gunlukKalori", analiz.gunlukKalori)
            };

            string query = "UPDATE KullaniciAnaliz SET KullaniciID=@KullaniciID, Kilo=@Kilo, BMIndeks=@BMIndeks, " +
                           "gunluksu=@gunluksu, gunlukKalori=@gunlukKalori WHERE AnalizID=@AnalizID";

            return hlp.ExecuteNonQuery(query, p) > 0;
        }


        public List<string> GetFoodsByMealTime(Yemek yemek)
        {
            List<string> foods = new List<string>();
            var hlp = new Helper();

            using (var conn = new SqlConnection(hlp.cstr))
            {
                var p = new SqlParameter[]
                {
            new SqlParameter("@ogun", yemek.ogun)
                };
                string query = "SELECT yiyecek_adi FROM yiyecekler WHERE ogun = @ogun";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@ogun", yemek.ogun);

                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foods.Add(reader["yiyecek_adi"].ToString());
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Öğün bazında yiyecekleri getirirken bir hata oluştu.", ex);
                }
            }

            return foods;
        }

        public DataTable FoodDetails(string yiyecek_adi)
        {
            var hlp = new Helper();
            var p = new SqlParameter[]
            {
        new SqlParameter("@yiyecek_adi", yiyecek_adi)



            };

            string query = "SELECT * FROM yiyecekler WHERE yiyecek_adi = @yiyecek_adi";

            try
            {
                var reader = hlp.ExecuteReader(query, p);
                var table = new DataTable();
                table.Load(reader);
                return table;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving food details from database.", ex);
            }
        }
        public DataTable kalorial(string yiyecek_adi)
        {
            var hlp = new Helper();
            var p = new SqlParameter[]
            {
        new SqlParameter("@yiyecek_adi", yiyecek_adi)
            };

            string query = "SELECT kalori FROM yiyecekler WHERE yiyecek_adi = @yiyecek_adi";
            var kalori = hlp.ExecuteScalar(query, p);
            decimal foodCalories = Convert.ToDecimal(kalori);

            var table = new DataTable();
            table.Columns.Add("Kalori", typeof(decimal));
            table.Rows.Add(foodCalories);

            return table;
        }
        public decimal GetDailyCalorieGoal(int userId)
        {
            var hlp = new Helper();
            var p = new SqlParameter[]
            {
        new SqlParameter("@user_id", userId)
            };

            string query = "SELECT gunlukKalori FROM KullaniciAnaliz WHERE KullaniciID = @user_id";

            var result = hlp.ExecuteScalar(query, p);
            if (result != null)
            {
                return Convert.ToDecimal(result);
            }
            return 0;
        }

        public bool GunlukDiyetEkle(GunlukDiyet diyet)
        {
            var hlp = new Helper();
            var p = new SqlParameter[]
            {
        new SqlParameter("@user_id", diyet.user_id),  
        new SqlParameter("@yiyecek_adi", diyet.yiyecek_adi),
        new SqlParameter("@kalori", diyet.kalori),
        new SqlParameter("@Protein", diyet.Protein),
        new SqlParameter("@Karbonhidrat", diyet.Karbonhidrat),
        new SqlParameter("@Yag", diyet.Yag),
        new SqlParameter("@yemesecim", diyet.yemesecim),
        new SqlParameter("@gluten_icerir", diyet.gluten_icerir),
        new SqlParameter("@saglik_durumuna_uygunluk", diyet.saglik_durumuna_uygunluk),
        new SqlParameter("@ogun", diyet.ogun),
        new SqlParameter("@tarih", diyet.tarih)
            };

            string query = @"INSERT INTO kullanici_yiyecekler 
                        (KullaniciID, yiyecek_adi, kalori, Protein, Karbonhidrat, Yag, yemesecim, gluten_icerir, saglik_durumuna_uygunluk, ogun, tarih) 
                        VALUES (@user_id, @yiyecek_adi, @kalori, @Protein, @Karbonhidrat, @Yag, @yemesecim, @gluten_icerir, @saglik_durumuna_uygunluk, @ogun, @tarih)";

            return hlp.ExecuteNonQuery(query, p) > 0;
        }


        public List<GunlukDiyet> GetKullaniciDiyetKayitlari(int userId, DateTime date)
        {
            var hlp = new Helper();
            var p = new SqlParameter[]
            {
        new SqlParameter("@user_id", userId),
        new SqlParameter("@tarih", date)
            };

            string query = "Select * from kullanici_yiyecekler where KullaniciID=@user_id and tarih = @tarih";

            var reader = hlp.ExecuteReader(query, p);
            var list = new List<GunlukDiyet>();

            while (reader.Read())
            {
                var yiyecek = new GunlukDiyet()
                {
                    id = reader.GetInt32(reader.GetOrdinal("id")),
                    user_id = reader.GetInt32(reader.GetOrdinal("KullaniciID")),
                    yiyecek_adi = reader.GetString(reader.GetOrdinal("yiyecek_adi")),
                    kalori = reader.GetDecimal(reader.GetOrdinal("kalori")),
                    Protein = reader.GetDecimal(reader.GetOrdinal("Protein")),
                    Karbonhidrat = reader.GetDecimal(reader.GetOrdinal("Karbonhidrat")),
                    Yag = reader.GetDecimal(reader.GetOrdinal("Yag")),
                    yemesecim = reader.GetString(reader.GetOrdinal("yemesecim")),
                    gluten_icerir = reader.GetString(reader.GetOrdinal("gluten_icerir")),
                    saglik_durumuna_uygunluk = reader.GetString(reader.GetOrdinal("saglik_durumuna_uygunluk")),
                    ogun = reader.GetString(reader.GetOrdinal("ogun")),
                    tarih=reader.GetDateTime(reader.GetOrdinal("tarih"))
                };

                list.Add(yiyecek);
            }
            return list;
        }


        public List<Yemek> GetTumDiyetKayitlari()
        {
            var hlp = new Helper();
            string query = "SELECT * FROM yiyecekler";
            var reader = hlp.ExecuteReader(query);
            var list = new List<Yemek>();

            while (reader.Read())
            {
                var yiyecek = new Yemek
                {
                    yiyecek_id = reader.GetInt32(reader.GetOrdinal("yiyecek_id")),
                    yiyecek_adi = reader.GetString(reader.GetOrdinal("yiyecek_adi")),
                    kalori = reader.GetDecimal(reader.GetOrdinal("kalori")),
                    Protein = reader.GetDecimal(reader.GetOrdinal("protein")),
                    Karbonhidrat = reader.GetDecimal(reader.GetOrdinal("karbonhidrat")),
                    Yag = reader.GetDecimal(reader.GetOrdinal("yağ")),
                    yemesecim = reader.GetString(reader.GetOrdinal("yemesecim")),
                    gluten_icerir = reader.GetBoolean(reader.GetOrdinal("gluten_icerir")),
                    saglik_durumuna_uygunluk = reader.GetString(reader.GetOrdinal("saglik_durumuna_uygunluk")),
                    ogun = reader.GetString(reader.GetOrdinal("ogun"))
                };

                list.Add(yiyecek);
            }
            return list;
        }
        public bool IsFoodAlreadyExists(string yiyecekAdi)
        {
            var hlp = new Helper();
            var p = new SqlParameter[]
            {
        new SqlParameter("@yiyecek_adi", yiyecekAdi)
            };

            string sorgu = "SELECT COUNT(*) FROM yiyecekler WHERE yiyecek_adi = @yiyecek_adi";
            int count = (int)hlp.ExecuteScalar(sorgu, p);

            return count > 0;
        }
        public bool Sil(int kullaniciID, string yiyecekAdi, DateTime tarih)
        {
            var hlp = new Helper();
            var p = new SqlParameter[]
            {
        new SqlParameter("@user_id", kullaniciID),
        new SqlParameter("@yiyecek_adi", yiyecekAdi),
        new SqlParameter("@tarih", tarih)
            };

            string query = "DELETE FROM kullanici_yiyecekler WHERE KullaniciID = @user_id AND yiyecek_adi = @yiyecek_adi AND tarih = @tarih";

            return hlp.ExecuteNonQuery(query, p) > 0;
        }

    }
}
    


