using Okulapp.BLL;
using okulAppModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace haftadokuz
{
    public partial class frmUyeKayit : Form
    {
        public frmUyeKayit()
        {
            InitializeComponent();
        }

        // Üye kaydet butonuna tıklandığında çalışacak olan metod
        private void btnkaydet_Click(object sender, EventArgs e)
        {
            try
            {
                var obl = new diyetbl();

                // Yeni üye kaydı yapılıyor
                bool sonuc = obl.uyeekle(new uye { name = txtad.Text.Trim(), email = txtemail.Text.Trim(), sifre = txtsifre.Text.Trim() });

                // Kayıt başarılıysa bilgilendirme mesajı gösterilir ve giriş formu açılır
                if (sonuc)
                {
                    MessageBox.Show("Üye Olundu");
                    frmgirisyap frm = new frmgirisyap();
                    frm.Show();
                }
            }
            catch (SqlException ex)
            {
                // Veritabanı hatası durumunda özel işlemler yapılır
                MessageBox.Show($"Veritabanı Hatası: {ex.Message}");
                switch (ex.Number)
                {
                    case 2627: // Benzersiz anahtar hatası durumu
                        MessageBox.Show("Bu email daha önce girilmiş!");
                        break;
                    default:
                        MessageBox.Show("Veritabanı Hatası!");
                        break;
                }
            }
            catch (Exception ex)
            {
                // Genel hata durumu
                MessageBox.Show($"Bir Hata Oluştu: {ex.Message}");
            }
        }
    }
}