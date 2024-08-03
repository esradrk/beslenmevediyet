using Okulapp.BLL;
using System;
using System.Windows.Forms;

namespace haftadokuz
{
    public partial class FrmTablom : Form
    {
        private readonly diyetbl _diyetbl;
        private readonly int _userid;

        public FrmTablom(int userid)
        {
            InitializeComponent();
            _userid = userid;
            _diyetbl = new diyetbl();
            DataGridViewiDoldur();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string yiyecekAdi = dataGridView1.SelectedRows[0].Cells["yiyecek_adi"].Value.ToString();
                DateTime tarih = DateTime.Today;
                // Veritabanından kaydı silme işlemi
                bool silindi = _diyetbl.Sil(_userid, yiyecekAdi,tarih); // Sil metodu uygulamanıza özgü olacak şekilde düzenlenmelidir

                if (silindi)
                {
                    MessageBox.Show("Kayıt başarıyla silindi.");
                    DataGridViewiDoldur(); // DataGridView'i yeniden doldurarak güncel verileri gösterme
                }
                else
                {
                    MessageBox.Show("Kayıt silinirken bir hata oluştu.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz kaydı seçin.");
            }
        }

        private void DataGridViewiDoldur()
        {
            DateTime tarih = DateTime.Today; // Örnek olarak bugünün tarihini alın

            var kayitlar = _diyetbl.GetKullaniciDiyetKayitlari(_userid, tarih);

            // DataGridView'e verileri yükleme
            dataGridView1.DataSource = kayitlar;
        }
    }
}
