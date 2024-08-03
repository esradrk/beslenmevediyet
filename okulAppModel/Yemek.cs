using System;
using System.Collections.Generic;
using System.Text;

namespace okulAppModel
{
    public class Yemek
    {
        public int yiyecek_id { get; set; }
        public string yiyecek_adi { get; set; }
        public decimal kalori { get; set; }
        public decimal Protein { get; set; }
        public decimal Karbonhidrat { get; set; }
        public decimal Yag { get; set; }

        public string yemesecim { get; set; }
        public bool gluten_icerir { get; set; } 

        public string saglik_durumuna_uygunluk { get; set; }
        public string ogun { get; set; }
    }


}
