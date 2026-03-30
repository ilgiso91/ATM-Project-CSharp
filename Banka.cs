using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ATMUygulamasi
{
    internal class Banka
    {
        public List<Hesap> Hesaplar { get; set; } = new List<Hesap>();
        public UserSettings Ayarlar { get; set; } = new UserSettings();

        private const string DosyaAdi = "accounts.json";

        // ============================
        // HESAP İŞLEMLERİ
        // ============================
        public void HesapEkle(Hesap h)
        {
            Hesaplar.Add(h);
        }

        public Hesap HesapBul(string hesapNo)
        {
            return Hesaplar.FirstOrDefault(h => h.HesapNo == hesapNo);
        }

        public string HesapSil(string hesapNo)
        {
            var h = HesapBul(hesapNo);

            if (h == null)
                return "Hesap bulunamadı.";

            Hesaplar.Remove(h);
            return "Hesap başarıyla silindi.";
        }

        // ============================
        // PARA TRANSFERİ
        // ============================
        public string ParaTransfer(string gonderenNo, string alanNo, decimal miktar)
        {
            var gonderen = HesapBul(gonderenNo);
            var alan = HesapBul(alanNo);

            if (gonderen == null || alan == null)
                return "Hesap bulunamadı.";

            if (gonderen.Bakiye < miktar)
                return "Gönderen hesapta yeterli bakiye yok.";

            string cekSonuc = gonderen.ParaCek(miktar);
            if (cekSonuc.Contains("limit") || cekSonuc.Contains("Yetersiz"))
                return cekSonuc;

            alan.ParaYatir(miktar);

            gonderen.LogEkle($"{alanNo} hesabına {miktar} TL gönderildi.");
            alan.LogEkle($"{gonderenNo} hesabından {miktar} TL alındı.");

            return $"{miktar} TL transfer edildi.";
        }

        // ============================
        // JSON KAYDETME
        // ============================
        public void SaveToJson()
        {
            var paket = new
            {
                hesaplar = Hesaplar,
                ayarlar = Ayarlar
            };

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(paket, options);
            File.WriteAllText(DosyaAdi, json);
        }

        // ============================
        // JSON YÜKLEME
        // ============================
        public void LoadFromJson()
        {
            if (!File.Exists(DosyaAdi))
                return;

            string json = File.ReadAllText(DosyaAdi);

            try
            {
                var paket = JsonSerializer.Deserialize<JsonPaket>(json);

                if (paket != null)
                {
                    Hesaplar = paket.hesaplar ?? new List<Hesap>();
                    Ayarlar = paket.ayarlar ?? new UserSettings();
                }
            }
            catch
            {
                // Dosya bozuksa hata vermesin
            }
        }

        // JSON için geçici sınıf
        private class JsonPaket
        {
            public List<Hesap> hesaplar { get; set; }
            public UserSettings ayarlar { get; set; }
        }
    }
}