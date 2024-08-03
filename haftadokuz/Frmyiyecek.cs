using Okulapp.BLL;
using Okulapp.DAL;
using okulAppModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace haftadokuz
{
    public partial class Frmyiyecek : Form
    {
        private BindingList<Yemek> sabahYemekleri = new BindingList<Yemek>(); // Sabah öğünü için yiyeceklerin listesi
        private BindingList<Yemek> ogleYemekleri = new BindingList<Yemek>(); // Öğle öğünü için yiyeceklerin listesi
        private BindingList<Yemek> aksamYemekleri = new BindingList<Yemek>(); // Akşam öğünü için yiyeceklerin listesi
        private diyetbl diyetTablosu = new diyetbl(); // Veritabanı işlemlerini yöneten diyetbl sınıfı
        private ComboBox comboOgun; // Öğün seçimi için ComboBox
        private int kullaniciId; // Kullanıcı kimliği

        public Frmyiyecek(int userId)
        {
            InitializeComponent();
            this.kullaniciId = userId;
            this.comboOgun = new ComboBox();

            diyetTablosu = new diyetbl();

            // ComboBox'ları ilgili öğünlerle doldur
            OgunComboBoxDoldur(combosabah, "Sabah");
            OgunComboBoxDoldur(comboogle, "Öğle");
            OgunComboBoxDoldur(comboaksam, "Akşam");

            // ComboBox'ların SelectedIndexChanged olaylarına aynı olay dinleyiciyi ekler
            combosabah.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            comboogle.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            comboaksam.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
        }

        // ComboBox'ın SelectedIndexChanged olayı
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboOgun = (ComboBox)sender; // Seçilen ComboBox'ı comboOgun değişkenine atar
        }

        // Öğün ComboBox'larını dolduran metod
        private void OgunComboBoxDoldur(ComboBox comboBox, string ogunZamani)
        {
            Yemek yemek = new Yemek { ogun = ogunZamani }; // Yemek sınıfı kullanarak belirtilen öğün için yeni bir yemek oluşturur
            List<string> yiyecekler = diyetTablosu.GetFoodsByMealTime(yemek); // Veritabanından belirtilen öğün için yiyecekleri alır

            comboBox.Items.Clear(); // ComboBox'ı temizler
            comboBox.DataSource = yiyecekler; // ComboBox'ı aldığı yiyeceklerle doldurur

            decimal toplamKalori = 0;
            foreach (var yiyecek in yiyecekler)
            {
                var hlp = new Helper(); // Helper sınıfından yeni bir yardımcı nesnesi oluşturur
                var p = new SqlParameter[]
                {
                    new SqlParameter("@yiyecek_adi", yiyecek) // SqlParameter ile yiyecek adını parametre olarak ekler
                };

                string sorgu = "SELECT kalori FROM yiyecekler WHERE yiyecek_adi = @yiyecek_adi"; // SQL sorgusu: yiyecek adına göre kaloriyi seçer
                var kalori = hlp.ExecuteScalar(sorgu, p); // Yardımcı sınıf aracılığıyla SQL sorgusunu çalıştırır ve kaloriyi alır
                toplamKalori += Convert.ToDecimal(kalori); // Aldığı kaloriyi toplam kaloriye ekler
            }

            txtkalori.Text = toplamKalori.ToString(); // Toplam kaloriyi txtkalori TextBox'ına yazdırır
        }

        // Öğün ekleme butonu tıklama olayı
        private void btnogunekleme_Click(object sender, EventArgs e)
        {
            FrmTablom tabl = new FrmTablom(kullaniciId); // FrmTablom formunu kullanıcı kimliği ile oluşturur
            tabl.Show(); // FrmTablom formunu gösterir
        }

        // Toplam kalorileri güncelleyen metod
        private void ToplamKalorileriGuncelle()
        {
            decimal toplamKalori = 0;
            foreach (var yemek in sabahYemekleri.Concat(ogleYemekleri).Concat(aksamYemekleri))
            {
                toplamKalori += yemek.kalori; // Sabah, öğle ve akşam öğünlerindeki tüm yiyeceklerin kalorilerini toplar
            }
            txtkalori.Text = toplamKalori.ToString(); // Toplam kaloriyi txtkalori TextBox'ına yazdırır
        }

        // Sabah öğünü ekleme butonu tıklama olayı
        private void btnSabahEkle_Click(object sender, EventArgs e)
        {
            if (combosabah.SelectedItem != null) // Eğer combosabah ComboBox'ı seçili bir öğe içeriyorsa
            {
                string seciliYiyecek = combosabah.SelectedItem.ToString(); // Seçili yiyeceği alır
                var yiyecekDetaylari = diyetTablosu.FoodDetails(seciliYiyecek); // Seçili yiyeceğin detaylarını alır

                if (yiyecekDetaylari != null && yiyecekDetaylari.Rows.Count > 0) // Eğer yiyecek detayları alınabilirse ve en az bir satır varsa
                {
                    GunlukDiyet diyet = new GunlukDiyet // Yeni bir GunlukDiyet nesnesi oluşturur
                    {
                        user_id = kullaniciId, // Kullanıcı kimliğini atar
                        yiyecek_adi = seciliYiyecek, // Yiyecek adını atar
                        kalori = Convert.ToDecimal(yiyecekDetaylari.Rows[0]["kalori"]), // Kaloriyi atar
                        Protein = Convert.ToDecimal(yiyecekDetaylari.Rows[0]["Protein"]), // Protein miktarını atar
                        Karbonhidrat = Convert.ToDecimal(yiyecekDetaylari.Rows[0]["Karbonhidrat"]), // Karbonhidrat miktarını atar
                        Yag = Convert.ToDecimal(yiyecekDetaylari.Rows[0]["yağ"]), // Yağ miktarını atar
                        yemesecim = yiyecekDetaylari.Rows[0]["yemesecim"].ToString(), // Yeme seçimini atar
                        gluten_icerir = yiyecekDetaylari.Rows[0]["gluten_icerir"].ToString(), // Gluten içeriğini atar
                        saglik_durumuna_uygunluk = yiyecekDetaylari.Rows[0]["saglik_durumuna_uygunluk"].ToString(), // Sağlık durumuna uygunluğunu atar
                        ogun = "Sabah", // Öğünü belirtir
                        tarih = DateTime.Now.Date // Tarihi atar
                    };

                    if (diyetTablosu.GunlukDiyetEkle(diyet)) // GunlukDiyetEkle metodu ile günlük diyet ekler
                    {
                        MessageBox.Show("Yiyecek başarıyla eklendi."); // Başarılı bir şekilde eklendiğine dair mesaj gösterir
                    }
                    else
                    {
                        MessageBox.Show("Yiyecek eklenirken bir hata oluştu."); // Ekleme sırasında bir hata oluştuğunu belirten mesaj gösterir
                    }
                }
                else
                {
                    MessageBox.Show("Yiyecek detayları alınamadı."); // Yiyecek detaylarının alınamadığını belirten mesaj gösterir
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir yiyecek seçin."); // Kullanıcıdan bir yiyecek seçmesi gerektiğini belirten mesaj gösterir
            }
        }

        // Öğle öğünü ekleme butonu tıklama olayı
        private void btnOgleEkle_Click(object sender, EventArgs e)
        {
            if (comboogle.SelectedItem != null) // Eğer comboogle ComboBox'ı seçili bir öğe içeriyorsa
            {
                string seciliYiyecek = comboogle.SelectedItem.ToString(); // Seçili yiyeceği alır
                var yiyecekDetaylari = diyetTablosu.FoodDetails(seciliYiyecek); // Seçili yiyeceğin detaylarını alır

                if (yiyecekDetaylari != null && yiyecekDetaylari.Rows.Count > 0) // Eğer yiyecek detayları alınabilirse ve en az bir satır varsa
                {
                    GunlukDiyet diyet = new GunlukDiyet // Yeni bir GunlukDiyet nesnesi oluşturur
                    {
                        user_id = kullaniciId, // Kullanıcı kimliğini atar
                        yiyecek_adi = seciliYiyecek, // Yiyecek adını atar
                        kalori = Convert.ToDecimal(yiyecekDetaylari.Rows[0]["kalori"]), // Kaloriyi atar
                        Protein = Convert.ToDecimal(yiyecekDetaylari.Rows[0]["Protein"]), // Protein miktarını atar
                        Karbonhidrat = Convert.ToDecimal(yiyecekDetaylari.Rows[0]["Karbonhidrat"]), // Karbonhidrat miktarını atar
                        Yag = Convert.ToDecimal(yiyecekDetaylari.Rows[0]["yağ"]), // Yağ miktarını atar
                        yemesecim = yiyecekDetaylari.Rows[0]["yemesecim"].ToString(), // Yeme seçimini atar
                        gluten_icerir = yiyecekDetaylari.Rows[0]["gluten_icerir"].ToString(), // Gluten içeriğini atar
                        saglik_durumuna_uygunluk = yiyecekDetaylari.Rows[0]["saglik_durumuna_uygunluk"].ToString(), // Sağlık durumuna uygunluğunu atar
                        ogun = "Öğle", // Öğünü belirtir
                        tarih = DateTime.Now.Date // Tarihi atar
                    };

                    if (diyetTablosu.GunlukDiyetEkle(diyet)) // GunlukDiyetEkle metodu ile günlük diyet ekler
                    {
                        MessageBox.Show("Yiyecek başarıyla eklendi."); // Başarılı bir şekilde eklendiğine dair mesaj gösterir
                    }
                    else
                    {
                        MessageBox.Show("Yiyecek eklenirken bir hata oluştu."); // Ekleme sırasında bir hata oluştuğunu belirten mesaj gösterir
                    }
                }
                else
                {
                    MessageBox.Show("Yiyecek detayları alınamadı."); // Yiyecek detaylarının alınamadığını belirten mesaj gösterir
                }
            }
        }

        // Akşam öğünü ekleme butonu tıklama olayı
        private void btnAksamEkle_Click(object sender, EventArgs e)
        {
            if (comboaksam.SelectedItem != null) // Eğer comboaksam ComboBox'ı seçili bir öğe içeriyorsa
            {
                string seciliYiyecek = comboaksam.SelectedItem.ToString(); // Seçili yiyeceği alır
                var yiyecekDetaylari = diyetTablosu.FoodDetails(seciliYiyecek); // Seçili yiyeceğin detaylarını alır

                if (yiyecekDetaylari != null && yiyecekDetaylari.Rows.Count > 0) // Eğer yiyecek detayları alınabilirse ve en az bir satır varsa
                {
                    GunlukDiyet diyet = new GunlukDiyet // Yeni bir GunlukDiyet nesnesi oluşturur
                    {
                        user_id = kullaniciId, // Kullanıcı kimliğini atar
                        yiyecek_adi = seciliYiyecek, // Yiyecek adını atar
                        kalori = Convert.ToDecimal(yiyecekDetaylari.Rows[0]["kalori"]), // Kaloriyi atar
                        Protein = Convert.ToDecimal(yiyecekDetaylari.Rows[0]["Protein"]), // Protein miktarını atar
                        Karbonhidrat = Convert.ToDecimal(yiyecekDetaylari.Rows[0]["Karbonhidrat"]), // Karbonhidrat miktarını atar
                        Yag = Convert.ToDecimal(yiyecekDetaylari.Rows[0]["yağ"]), // Yağ miktarını atar
                        yemesecim = yiyecekDetaylari.Rows[0]["yemesecim"].ToString(), // Yeme seçimini atar
                        gluten_icerir = yiyecekDetaylari.Rows[0]["gluten_icerir"].ToString(), // Gluten içeriğini atar
                        saglik_durumuna_uygunluk = yiyecekDetaylari.Rows[0]["saglik_durumuna_uygunluk"].ToString(), // Sağlık durumuna uygunluğunu atar
                        ogun = "Akşam", // Öğünü belirtir
                        tarih = DateTime.Now.Date // Tarihi atar
                    };

                    if (diyetTablosu.GunlukDiyetEkle(diyet)) // GunlukDiyetEkle metodu ile günlük diyet ekler
                    {
                        MessageBox.Show("Yiyecek başarıyla eklendi."); // Başarılı bir şekilde eklendiğine dair mesaj gösterir
                    }
                    else
                    {
                        MessageBox.Show("Yiyecek eklenirken bir hata oluştu."); // Ekleme sırasında bir hata oluştuğunu belirten mesaj gösterir
                    }
                }
                else
                {
                    MessageBox.Show("Yiyecek detayları alınamadı."); // Yiyecek detaylarının alınamadığını belirten mesaj gösterir
                }
            }
        }

        // Kalori alımını kontrol eden metod
        private void KaloriAlımınıKontrolEt()
        {
            decimal toplamKalori = decimal.Parse(txtkalori.Text); // txtkalori TextBox'ından toplam kaloriyi alır
            decimal gunlukKaloriHedefi = diyetTablosu.GetDailyCalorieGoal(kullaniciId); // Kullanıcının günlük kalori hedefini alır

            if (toplamKalori >= gunlukKaloriHedefi) // Eğer toplam kalori günlük kalori hedefine eşit veya büyükse
            {
                MessageBox.Show("Günlük kalori hedefinize ulaştınız veya geçtiniz!"); // Kullanıcıya mesaj gösterir
            }
            else // Aksi durumda
            {
                decimal kalanKaloriler = gunlukKaloriHedefi - toplamKalori; // Kalan kalorileri hesaplar
                MessageBox.Show($"Günlük kalori hedefinize ulaşmak için {kalanKaloriler} kalori daha tüketmelisiniz."); // Kullanıcıya mesaj gösterir
            }
        }

       
    }
}
