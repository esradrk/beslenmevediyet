using Okulapp.BLL;
using Okulapp.DAL;
using okulAppModel;
using System;
using System.Data;
using System.Windows.Forms;

namespace haftadokuz
{
    public partial class FrmAnaliz : Form
    {
        private int _userId;  // Kullanıcı kimliği alanı

        public FrmAnaliz(int userId)
        {
            InitializeComponent();
            _userId = userId;  // Kullanıcı kimliği atanır
            this.Load += new EventHandler(FrmAnaliz_Load);  // Form yüklenme olayı ayarlanır
        }

        private void FrmAnaliz_Load(object sender, EventArgs e)
        {
            LoadAnalizData();  // Analiz verileri yüklenir
            CalculateAndDisplayAnaliz();  // Analiz hesaplamaları yapılıp gösterilir
        }

        // Kullanıcı analiz verilerini yükler
        private void LoadAnalizData()
        {
            var diyetService = new diyetbl();  // Diyet iş mantığı servisi oluşturulur
            DataTable analizTable = diyetService.GetKullaniciAnalizByUserId(_userId);  // Kullanıcı analiz verileri getirilir
            dataGridView1.DataSource = analizTable;  // Veri tablosu grid'e bağlanır
        }

        // Analiz hesaplarını yapar ve gösterir
        private void CalculateAndDisplayAnaliz()
        {
            var diyetService = new diyetbl();  // Diyet iş mantığı servisi oluşturulur
            var profil = diyetService.GetProfilByUserId(_userId);  // Kullanıcı profil bilgileri getirilir
            if (profil != null)
            {
                var idealKilo = HealthCalculations.idealkilo(profil.Boy, profil.Cinsiyet);  // İdeal kilo hesaplanır
                var gunlukKalori = HealthCalculations.aktiviteduzey(profil);  // Günlük kalori ihtiyacı hesaplanır
                var gunlukSu = HealthCalculations.almasıgerekensu(profil);  // Günlük su ihtiyacı hesaplanır
                var BMIndeks = HealthCalculations.hesapBMI(profil.Kilo, profil.Boy);  // BMI hesaplanır

                kullanicianaliz sonAnaliz = diyetService.GetLatestKullaniciAnalizByUserId(_userId);  // Son kullanıcı analizi getirilir

                if (sonAnaliz != null)
                {
                    sonAnaliz.Kilo = idealKilo;  // İdeal kilo güncellenir
                    sonAnaliz.BMIndeks = BMIndeks;  // BMI güncellenir
                    sonAnaliz.gunluksu = gunlukSu;  // Günlük su güncellenir
                    sonAnaliz.gunlukKalori = gunlukKalori;  // Günlük kalori güncellenir
                    diyetService.KullaniciAnalizGuncelle(sonAnaliz);  // Kullanıcı analizi güncellenir
                }
                else
                {
                    kullanicianaliz yeniAnaliz = new kullanicianaliz
                    {
                        KullaniciID = _userId,
                        Kilo = idealKilo,
                        BMIndeks = BMIndeks,
                        gunluksu = gunlukSu,
                        gunlukKalori = gunlukKalori
                    };
                    diyetService.KullaniciAnalizEkle(yeniAnaliz);  // Yeni kullanıcı analizi eklenir
                }

                LoadAnalizData();  // Analiz verileri yeniden yüklenir
            }
            else
            {
                MessageBox.Show("Profil bilgileri eksik. Lütfen önce profilinizi kaydedin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Öğün formunu açar
        private void btnogun_Click(object sender, EventArgs e)
        {
            Frmyiyecek ogun = new Frmyiyecek(_userId);  // Öğün formu nesnesi oluşturulur
            ogun.Show();  // Form gösterilir
        }
    }
}