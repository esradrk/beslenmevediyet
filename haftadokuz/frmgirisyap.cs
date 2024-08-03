using Okulapp.BLL;
using okulAppModel;
using System;
using System.Windows.Forms;

namespace haftadokuz
{
    public partial class frmgirisyap : Form
    {
        public frmgirisyap()
        {
            InitializeComponent();
        }

        // Üye olma butonuna tıklandığında çalışacak olan metod
        private void btnuye_Click(object sender, EventArgs e)
        {
            // Üye kayıt formunu açar ve modal olarak gösterir
            frmUyeKayit frm = new frmUyeKayit();
            frm.ShowDialog();
        }

        // Giriş yap butonuna tıklandığında çalışacak olan metod
        private void btngiris_Click(object sender, EventArgs e)
        {
            var diyet = new diyetbl();

            // Kullanıcı girişi yapılıyor
            int userId = diyet.GirisYap(new uye { name = txtad.Text.Trim(), sifre = txtsifre.Text.Trim() });

            // Giriş başarılıysa profil oluşturma formunu açar
            if (userId > 0)
            {
                MessageBox.Show("Giriş başarılı!");
                FrmProfilolusturma frm = new FrmProfilolusturma(userId);
                frm.ShowDialog();
            }
            else
            {
                // Giriş başarısız ise hata mesajı gösterir
                MessageBox.Show("Geçersiz kullanıcı adı veya şifre.");
            }
        }
    }
}
