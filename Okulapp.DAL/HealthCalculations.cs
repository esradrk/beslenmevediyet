using okulAppModel;
using System;

namespace Okulapp.DAL
{
    public class HealthCalculations
    {
        public static decimal idealkilo(decimal heightCm, string gender)
        {
            decimal idealWeight;

            decimal heightInInches = heightCm / 2.54m;  // Boyu inç cinsine çevirir

            if (gender == "Erkek")
            {
                // Erkek için ideal kilo hesaplama formülü
                idealWeight = 50 + 2.3m * (heightInInches - 60);
            }
            else if (gender == "Kadın")
            {
                // Kadın için ideal kilo hesaplama formülü
                idealWeight = 45.5m + 2.3m * (heightInInches - 60);
            }
            else
            {
                // Geçersiz cinsiyet durumunda istisna fırlatır
                throw new ArgumentException("Geçersiz cinsiyet. 'Erkek' veya 'Kadın' olmalıdır.");
            }

            return idealWeight;  // Hesaplanan ideal kiloyu döndürür
        }

        public static int aktiviteduzey(ProfilBilgileri profil)
        {
            decimal bmr;
            if (profil.Cinsiyet == "Erkek")
            {
                // Erkek için BMR (Basal Metabolic Rate) hesaplama formülü
                bmr = (decimal)((10 * (double)profil.Kilo) + (6.25 * (double)profil.Boy) - (5 * (double)profil.Yas) + 5);
            }
            else
            {
                // Kadın için BMR (Basal Metabolic Rate) hesaplama formülü
                bmr = (decimal)((10 * (double)profil.Kilo) + (6.25 * (double)profil.Boy) - (5 * (double)profil.Yas) - 161);
            }

            decimal activityFactor;
            switch (profil.FizikselAktiviteDuzeyi)
            {
                case "Haraketsiz":
                    activityFactor = 1.2m;
                    break;
                case "Orta Hareketli":
                    activityFactor = 1.55m;
                    break;
                case "Hareketli":
                    activityFactor = 1.725m;
                    break;
                default:
                    activityFactor = 1.2m;  // Varsayılan olarak "Haraketsiz" aktivite düzeyini kullanır
                    break;
            }

            return (int)(bmr * activityFactor);  // Aktivite düzeyine göre günlük kalori ihtiyacını hesaplar ve tam sayı olarak döndürür
        }

        public static decimal almasıgerekensu(ProfilBilgileri profil)
        {
            return profil.Kilo * 0.033m;  // Günlük su ihtiyacını hesaplar ve döndürür
        }

        public static decimal hesapBMI(decimal kilo, decimal boy)
        {
            decimal boyMetreCinsinden = boy / 100m;  // Boyu metre cinsine çevirir
            return kilo / (boyMetreCinsinden * boyMetreCinsinden);  // BMI (Body Mass Index) hesaplama formülü
        }

        public static string BMIkatagori(decimal bmi)
        {
            if (bmi <= 18.5m)
            {
                return "Zayıf";  // BMI kategorisini döndürür
            }
            else if (bmi > 18.5m && bmi < 25.0m)
            {
                return "Normal ağırlıkta";  // BMI kategorisini döndürür
            }
            else if (bmi >= 25.0m && bmi < 30.0m)
            {
                return "Kilolu";  // BMI kategorisini döndürür
            }
            else if (bmi >= 30.0m && bmi < 35.0m)
            {
                return "1. derece obezite";  // BMI kategorisini döndürür
            }
            else if (bmi >= 35.0m && bmi < 40.0m)
            {
                return "2. derece obezite";  // BMI kategorisini döndürür
            }
            else
            {
                return "3. derece obezite";  // BMI kategorisini döndürür
            }
        }
    }
}