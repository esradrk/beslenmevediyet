using Okulapp.BLL;
using System.Windows.Forms;
using System;

namespace haftadokuz
{
    public partial class FrmOgunsorulari : Form  // Windows Forms form sınıfı
    {
        private int _userId;  // Sınıf içinde kullanılacak özel bir üye değişken

        public FrmOgunsorulari(int userId)  // Kurucu metot, kullanıcı kimliği alır
        {
            InitializeComponent();  // Form bileşenlerini başlatır
            _userId = userId;  // Kullanıcı kimliğini sınıf üye değişkenine atar
        }

        private void btnanaliz_Click(object sender, EventArgs e)  // Analiz butonu tıklama olayı
        {
            try
            {
                string beslenmeTercihi = combobes.Text;  // Combobox'tan beslenme tercihini alır
                string diyetYapmaSebebi = combodiyet.Text;  // Combobox'tan diyet yapma sebebini alır

                if (string.IsNullOrWhiteSpace(beslenmeTercihi) || string.IsNullOrWhiteSpace(diyetYapmaSebebi) || !decimal.TryParse(txtkilo.Text, out decimal hedefkilo))
                {
                    // Gerekli alanlar boşsa veya geçerli bir hedef kilo girilmemişse hata mesajı gösterir
                    MessageBox.Show("Tüm alanları doldurun ve geçerli değerler girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;  // Metodu sonlandırır
                }

                var diyetService = new diyetbl();  // BLL katmanından hizmet nesnesi oluşturulur
                bool kontrol = diyetService.ProfilBilgileriniGuncelle(_userId, beslenmeTercihi, diyetYapmaSebebi, hedefkilo);  // Profil bilgilerini günceller

                if (kontrol)
                {
                    // Güncelleme başarılıysa bilgi mesajı gösterir ve analiz formunu açar
                    MessageBox.Show("Profil başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmAnaliz ana = new FrmAnaliz(_userId);  // Yeni analiz formu oluşturulur
                    ana.ShowDialog();  // Analiz formunu modal olarak gösterir
                }
                else
                {
                    // Güncelleme sırasında hata oluşmuşsa hata mesajı gösterir
                    MessageBox.Show("Profil güncellenirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Herhangi bir istisna durumunda hata mesajı gösterir
                MessageBox.Show($"Profil güncellenirken bir hata oluştu:\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmOgunsorulari_Load(object sender, EventArgs e)  // Form yükleme olayı
        {
            var diyetService = new diyetbl();  // BLL katmanından hizmet nesnesi oluşturulur
            var profil = diyetService.GetProfilByUserId(_userId);  // Kullanıcı profili bilgisini alır
            if (profil != null)
            {
                // Profil bilgisi varsa, combobox'ları ve kilo metin kutusunu doldurur
                combobes.Text = profil.beslenmetercihi;
                combodiyet.Text = profil.diyetyapmasebebi;
                txtkilo.Text = profil.hedefkilo.ToString();
            }

            // Combobox'ların seçeneklerini tanımlar
            combobes.Items.AddRange(new string[]
            {
                "Tercihim Yok",
                "Vegan",
                "Vejeteryan",
                "Glutensiz",
                "Ketojenik",
                "Fleksiteryon"
            });

            combodiyet.Items.AddRange(new string[]
            {
                "Kilo Verme",
                "Kilo Alma",
                "Vücut Geliştirme",
                "Hastalığa Göre Beslenme"
            });
        }

        private void btnana_Click(object sender, EventArgs e)  // Ana butonu tıklama olayı
        {
            FrmAnaliz FRM = new FrmAnaliz(_userId);  // Yeni analiz formu oluşturulur
            FRM.ShowDialog();  // Analiz formunu modal olarak gösterir
        }
    }
}