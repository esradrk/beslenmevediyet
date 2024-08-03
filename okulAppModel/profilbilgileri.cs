namespace okulAppModel
{
    public class ProfilBilgileri
    {
        public int ProfilID { get; set; }
        public int user_id { get; set; }

        public int Yas { get; set; }
        public string Cinsiyet { get; set; }
        public decimal Boy { get; set; }
        public decimal Kilo { get; set; }
        public decimal BMI { get; set; }
        public string FizikselAktiviteDuzeyi { get; set; }
        public string SaglikDurumu { get; set; }
        public string BesinAlerjileri { get; set; }
        public string adsoyad { get; set; }
        public string beslenmetercihi { get; set; }
        public string diyetyapmasebebi { get; set; }
        public decimal hedefkilo { get; set; }


    }
}
