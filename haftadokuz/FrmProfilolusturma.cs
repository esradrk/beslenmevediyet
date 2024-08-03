using Okulapp.BLL;
using okulAppModel;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace haftadokuz
{
    public partial class FrmProfilolusturma : Form
    {
        private int _userId;

        public FrmProfilolusturma(int userId)
        {
            InitializeComponent();
            _userId = userId;

            // Boy ve kilo TextBox'larının TextChanged olaylarına dinleyici ekleniyor
            btnboy.TextChanged += new EventHandler(BoyVeyaKiloDegisti);
            btnkilo.TextChanged += new EventHandler(BoyVeyaKiloDegisti);

            // Form yüklendiğinde FrmProfilolusturma_Load metodunun çalışmasını sağlar
            this.Load += new EventHandler(FrmProfilolusturma_Load);
        }

        // Form yüklendiğinde çalışacak olan metod
        private void FrmProfilolusturma_Load(object sender, EventArgs e)
        {
            // ComboBox'lar için seçenekler ekleniyor
            combosaglik.Items.AddRange(new string[]
            {
                "Sağlıklı",
                "Kalp Damar",
                "Kanser",
                "Anaroksiya",
                "Obezite",
                "Tansiyon",
                "İnsulin Direnci",
                "Karaciğer Yağlanması",
                "Yüksek Kolestrol",
                "Diyabet",
                "Troit"
            });

            combofizik.Items.AddRange(new string[]
            {
                "Hareketli",
                "Haraketsiz",
                "Orta Hareketli"
            });

            combobesin.Items.AddRange(new string[]
            {
                "Yok",
                "Gluten",
                "Laktoz",
                "Fıstık",
                "Deniz Ürünleri",
                "Çilek",
                "Elma",
                "Domates",
                "Yumurta",
                "Süt Ürünleri"
            });

            var diyetService = new diyetbl();
            var profil = diyetService.GetProfilByUserId(_userId);

            // Eğer profil bilgisi varsa, form elemanlarına yükleniyor
            if (profil != null)
            {
                btnyas.Text = profil.Yas.ToString();
                btnboy.Text = profil.Boy.ToString();
                btnkilo.Text = profil.Kilo.ToString();
                btnvucut.Text = profil.BMI.ToString();

                // Cinsiyet RadioButton'larına göre işaretleniyor
                if (profil.Cinsiyet == "Erkek")
                {
                    rderkek.Checked = true;
                }
                else if (profil.Cinsiyet == "Kadın")
                {
                    rdkadin.Checked = true;
                }

                combofizik.Text = profil.FizikselAktiviteDuzeyi;
                combosaglik.Text = profil.SaglikDurumu;
                combobesin.Text = profil.BesinAlerjileri;
                btnadsoyad.Text = profil.adsoyad;
                btnana.Visible = true; // Analiz butonu görünür hale getiriliyor
            }
        }

        // Kaydet butonuna tıklandığında çalışacak olan metod
        private void btnkaydet_Click(object sender, EventArgs e)
        {
            try
            {
                int yas = int.Parse(btnyas.Text);
                decimal boy = decimal.Parse(btnboy.Text);
                decimal kilo = decimal.Parse(btnkilo.Text);
                string cinsiyet = rderkek.Checked ? "Erkek" : (rdkadin.Checked ? "Kadın" : string.Empty);
                string fizikselAktiviteDuzeyi = combofizik.Text;
                string saglikDurumu = combosaglik.Text;
                string besinAlerjileri = combobesin.Text;
                string adsoyad = btnadsoyad.Text;

                // BMI hesaplanıyor
                decimal bmi = kilo / ((boy / 100) * (boy / 100));
                btnvucut.Text = bmi.ToString("0.00");

                var diyetService = new diyetbl();

                ProfilBilgileri profil = new ProfilBilgileri
                {
                    Yas = yas,
                    Boy = boy,
                    Kilo = kilo,
                    BMI = bmi,
                    Cinsiyet = cinsiyet,
                    FizikselAktiviteDuzeyi = fizikselAktiviteDuzeyi,
                    SaglikDurumu = saglikDurumu,
                    BesinAlerjileri = besinAlerjileri,
                    adsoyad = adsoyad
                };

                bool kontrol;
                var mevcutProfil = diyetService.GetProfilByUserId(_userId);

                // Eğer mevcut profil varsa güncelle, yoksa yeni profil ekle
                if (mevcutProfil != null)
                {
                    kontrol = diyetService.ProfilGuncelle(_userId, profil);
                }
                else
                {
                    kontrol = diyetService.profilekle(_userId, profil);
                }

                // Kontrol başarılıysa mesaj gösterilir ve bir sonraki form açılır
                if (kontrol)
                {
                    MessageBox.Show("Profil başarıyla kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmOgunsorulari ogun = new FrmOgunsorulari(_userId);
                    ogun.Show();
                }
                else
                {
                    MessageBox.Show("Profil kaydedilirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Profil kaydedilirken bir hata oluştu:\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Boy veya kilo TextBox'larına girilen değer değiştiğinde çalışacak olan metod
        private void BoyVeyaKiloDegisti(object sender, EventArgs e)
        {
            if (decimal.TryParse(btnboy.Text, out decimal boy) && decimal.TryParse(btnkilo.Text, out decimal kilo))
            {
                // BMI hesaplanıyor ve ilgili TextBox'a yazılıyor
                decimal bmi = kilo / ((boy / 100) * (boy / 100));
                btnvucut.Text = bmi.ToString("0.00");
            }
            else
            {
                btnvucut.Text = string.Empty; // Eğer geçersiz giriş varsa boşaltılıyor
            }
        }

        // Analiz butonuna tıklandığında çalışacak olan metod
        private void btn_Click(object sender, EventArgs e)
        {
            var diyetService = new diyetbl();
            var profil = diyetService.GetProfilByUserId(_userId);

            // Eğer profil bilgisi varsa bir sonraki form açılır
            if (profil != null)
            {
                FrmOgunsorulari ogun = new FrmOgunsorulari(_userId);
                ogun.Show();
            }
            else
            {
                MessageBox.Show("Profil bilgileri eksik. Lütfen önce profilinizi kaydedin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Ana butonuna tıklandığında çalışacak olan metod
        private void btnana_Click(object sender, EventArgs e)
        {
            FrmAnaliz FRM = new FrmAnaliz(_userId);
            FRM.ShowDialog(); // Analiz formunu açar ve modal olarak gösterir
        }
    }
}