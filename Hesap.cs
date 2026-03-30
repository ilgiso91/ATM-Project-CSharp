using System;
using System.Collections.Generic;

namespace ATMUygulamasi
{
    internal class Hesap
    {
        public string HesapNo { get; set; }
        public string Sahip { get; set; }
        public decimal Bakiye { get; set; }
        public string Sifre { get; set; }

        // Hesap türü
        public string HesapTuru { get; set; } = "Vadesiz"; // Vadesiz / Vadeli
        public decimal FaizOrani { get; set; } = 0.02m;    // Vadeli hesap için faiz

        // Günlük limit
        public decimal GunlukLimit { get; set; } = 5000m;
        public decimal BugunCekilen { get; set; } = 0m;
        public DateTime SonIslemTarihi { get; set; } = DateTime.Today;

        // Loglar
        public List<string> Log { get; set; } = new List<string>();

        public Hesap() { }

        public Hesap(string hesapNo, string sahip, decimal bakiye, string sifre)
        {
            HesapNo = hesapNo;
            Sahip = sahip;
            Bakiye = bakiye;
            Sifre = sifre;
        }

        // Vadeli hesap faizi
        public void FaizIslet()
        {
            if (HesapTuru == "Vadeli")
            {
                decimal faiz = Bakiye * FaizOrani;
                Bakiye += faiz;
                Log.Add($"{DateTime.Now}: Vadeli hesap faizi işlendi: +{faiz} TL");
            }
        }

        public void LogEkle(string mesaj)
        {
            Log.Add($"{DateTime.Now}: {mesaj}");
        }

        private void GunlukLimitKontrol()
        {
            if (SonIslemTarihi.Date != DateTime.Today)
            {
                BugunCekilen = 0m;
                SonIslemTarihi = DateTime.Today;
            }
        }

        public string ParaYatir(decimal miktar)
        {
            Bakiye += miktar;
            LogEkle($"{miktar} TL yatırıldı.");
            return $"{miktar} TL yatırıldı. Yeni bakiye: {Bakiye} TL";
        }

        public string ParaCek(decimal miktar)
        {
            GunlukLimitKontrol();

            if (miktar > Bakiye)
                return "Yetersiz bakiye.";

            if (BugunCekilen + miktar > GunlukLimit)
                return $"Günlük limit aşılıyor. Kalan limit: {GunlukLimit - BugunCekilen} TL";

            Bakiye -= miktar;
            BugunCekilen += miktar;

            LogEkle($"{miktar} TL çekildi.");
            return $"{miktar} TL çekildi. Yeni bakiye: {Bakiye} TL";
        }

        public string BakiyeGoster()
        {
            return $"Hesap: {HesapNo} | Sahip: {Sahip} | Tür: {HesapTuru} | Bakiye: {Bakiye} TL";
        }
    }
}