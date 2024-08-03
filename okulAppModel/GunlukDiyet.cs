using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace okulAppModel
{
    public class GunlukDiyet
    {
        public int id { get; set; }
        public int user_id { get; set; }


      
        public string yiyecek_adi { get; set; }
        public decimal kalori { get; set; }
        public decimal Protein { get; set; }
        public decimal Karbonhidrat { get; set; }
        public decimal Yag { get; set; }

        public string yemesecim { get; set; }
        public string gluten_icerir { get; set; }

        public string saglik_durumuna_uygunluk { get; set; }
        public string ogun { get; set; }
     

        public DateTime tarih { get; set; }

    }
}
