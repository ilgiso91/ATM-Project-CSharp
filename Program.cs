using System;
using System.Collections.Generic;

namespace ATMUygulamasi
{
    internal class Program
    {
        static Banka banka = new Banka();
        static Hesap aktifHesap = null;
        static Dictionary<string, string> Lang = Language.TR;

        static void Main(string[] args)
        {
            // JSON yükle
            banka.LoadFromJson();

            // Tema uygula
            Theme.Apply(banka.Ayarlar.Tema);

            // Açılış animasyonu
            ATM_AcilisAnimasyonu();

            // Dil seçimi
            DilSecimi();

            // Tema seçimi
            TemaSecimi();

            // JSON tekrar kaydet (ayarlar değiştiyse)
            banka.SaveToJson();

            // Eğer hiç hesap yoksa örnek hesap ekle
            if (banka.Hesaplar.Count == 0)
            {
                banka.HesapEkle(new Hesap("1001", "Gizem", 5000, "1234") { HesapTuru = "Vadesiz" });
                banka.HesapEkle(new Hesap("1002", "Ahmet", 3000, "1111") { HesapTuru = "Vadeli" });
                banka.SaveToJson();
            }

            bool programCalisiyor = true;

            while (programCalisiyor)
            {
                GirisEkrani(ref programCalisiyor);

                if (aktifHesap != null)
                    KullaniciMenu();
            }

            banka.SaveToJson();
            Console.WriteLine("\nVeriler kaydedildi. Program kapandı.");
        }

        // ============================
        // AÇILIŞ ANİMASYONU
        // ============================
        static void ATM_AcilisAnimasyonu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;

            string[] logo =
            {
                "   █████╗ ████████╗███╗   ███╗",
                "  ██╔══██╗╚══██╔══╝████╗ ████║",
                "  ███████║   ██║   ██╔████╔██║",
                "  ██╔══██║   ██║   ██║╚██╔╝██║",
                "  ██║  ██║   ██║   ██║ ╚═╝ ██║",
                "  ╚═╝  ╚═╝   ╚═╝   ╚═╝     ╚═╝"
            };

            foreach (var line in logo)
            {
                Console.WriteLine(line);
                System.Threading.Thread.Sleep(80);
            }

            Console.ResetColor();
            Console.WriteLine();

            // Kart takma animasyonu
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Kart takılıyor...");
            System.Threading.Thread.Sleep(500);

            string[] anim =
            {
                "[■□□□□]",
                "[■■□□□]",
                "[■■■□□]",
                "[■■■■□]",
                "[■■■■■]"
            };

            foreach (var a in anim)
            {
                Console.Write("\r" + a);
                System.Threading.Thread.Sleep(200);
            }

            Console.ResetColor();
            Console.WriteLine("\nKart okundu.\n");

            // Yavaş yazı efekti
            Console.ForegroundColor = ConsoleColor.Green;
            string mesaj = Lang["welcome"];
            foreach (char c in mesaj)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(25);
            }
            Console.ResetColor();

            Console.WriteLine("\n");
        }

        // ============================
        // DİL SEÇİMİ
        // ============================
        static void DilSecimi()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Language.TR["lang_select_title"]);
            Console.ResetColor();

            Console.WriteLine(Language.TR["lang_tr"]);
            Console.WriteLine(Language.TR["lang_en"]);
            Console.WriteLine(Language.TR["lang_de"]);

            Console.Write(Language.TR["lang_choice"]);
            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1": Lang = Language.TR; banka.Ayarlar.Dil = "TR"; break;
                case "2": Lang = Language.EN; banka.Ayarlar.Dil = "EN"; break;
                case "3": Lang = Language.DE; banka.Ayarlar.Dil = "DE"; break;
                default: Lang = Language.TR; break;
            }
        }

        // ============================
        // TEMA SEÇİMİ
        // ============================
        static void TemaSecimi()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nTema Seçiniz:");
            Console.ResetColor();

            Console.WriteLine("1 - Açık Tema");
            Console.WriteLine("2 - Koyu Tema");
            Console.WriteLine("3 - Renkli Tema");

            Console.Write("Seçim: ");
            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1": banka.Ayarlar.Tema = "light"; break;
                case "2": banka.Ayarlar.Tema = "dark"; break;
                case "3": banka.Ayarlar.Tema = "colorful"; break;
                default: banka.Ayarlar.Tema = "dark"; break;
            }

            Theme.Apply(banka.Ayarlar.Tema);
        }

        // ============================
        // GİRİŞ EKRANI
        // ============================
        static void GirisEkrani(ref bool programCalisiyor)
        {
            aktifHesap = null;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n" + Lang["login_type_title"]);
            Console.ResetColor();

            Console.WriteLine(Lang["login_user"]);
            Console.WriteLine(Lang["login_admin"]);
            Console.WriteLine(Lang["login_exit"]);

            Console.Write(Lang["enter_choice"]);
            string secim = Console.ReadLine().ToUpper();

            switch (secim)
            {
                case "1": KullaniciGiris(); break;
                case "2": AdminGiris(); break;
                case "X": programCalisiyor = false; break;
                default: Console.WriteLine("Hatalı seçim."); break;
            }
        }

        // ============================
        // ŞİFRE GİRİŞİ
        // ============================
        static string MaskeliSifreAl()
        {
            string sifre = "";
            ConsoleKeyInfo key;

            while (true)
            {
                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                else if (key.Key == ConsoleKey.Backspace && sifre.Length > 0)
                {
                    sifre = sifre.Substring(0, sifre.Length - 1);
                    Console.Write("\b \b");
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    sifre += key.KeyChar;
                    Console.Write("*");
                }
            }

            return sifre;
        }

        // ============================
        // KULLANICI GİRİŞİ
        // ============================
        static void KullaniciGiris()
        {
            int hak = 3;

            while (hak > 0)
            {
                Console.Write(Lang["enter_account"]);
                string no = Console.ReadLine();

                Console.Write(Lang["enter_password"]);
                string sifre = MaskeliSifreAl();

                var h = banka.HesapBul(no);

                if (h != null && h.Sifre == sifre)
                {
                    aktifHesap = h;
                    Console.WriteLine($"\nHoş geldiniz, {h.Sahip}");
                    return;
                }

                hak--;
                Console.WriteLine($"{Lang["login_failed"]} {Lang["login_try_left"]}{hak}");
            }

            Console.WriteLine(Lang["login_blocked"]);
        }

        // ============================
        // ADMIN GİRİŞİ
        // ============================
        static void AdminGiris()
        {
            Console.Write(Lang["admin_user"]);
            string user = Console.ReadLine();

            Console.Write(Lang["admin_pass"]);
            string pass = MaskeliSifreAl();

            if (user == "admin" && pass == "0000")
            {
                Console.WriteLine(Lang["admin_success"]);
                AdminMenu();
            }
            else
            {
                Console.WriteLine(Lang["admin_failed"]);
            }
        }

        // ============================
        // KULLANICI MENÜSÜ
        // ============================
        static void KullaniciMenu()
        {
            bool devam = true;

            while (devam)
            {
                Console.WriteLine("\n===== " + Lang["menu_title"] + " =====");
                Console.WriteLine(Lang["menu_balance"]);
                Console.WriteLine(Lang["menu_deposit"]);
                Console.WriteLine(Lang["menu_withdraw"]);
                Console.WriteLine(Lang["menu_transfer"]);
                Console.WriteLine(Lang["menu_logs"]);
                Console.WriteLine(Lang["menu_switch"]);
                Console.WriteLine(Lang["menu_exit_user"]);

                Console.Write(Lang["enter_choice"]);
                string secim = Console.ReadLine().ToUpper();

                switch (secim)
                {
                    case "1": BakiyeGoster(); break;
                    case "2": ParaYatir(); break;
                    case "3": ParaCek(); break;
                    case "4": ParaTransfer(); break;
                    case "5": HareketleriGoster(); break;
                    case "6": devam = false; break;
                    case "X": devam = false; break;
                    default: Console.WriteLine("Hatalı seçim."); break;
                }
            }
        }

        // ============================
        // ADMIN MENÜSÜ
        // ============================
        static void AdminMenu()
        {
            bool devam = true;

            while (devam)
            {
                Console.WriteLine("\n" + Lang["admin_menu_title"]);
                Console.WriteLine(Lang["admin_menu_list"]);
                Console.WriteLine(Lang["admin_menu_delete"]);
                Console.WriteLine(Lang["admin_menu_edit_balance"]);
                Console.WriteLine(Lang["admin_menu_logs"]);
                Console.WriteLine(Lang["admin_menu_create"]);
                Console.WriteLine(Lang["admin_menu_exit"]);

                Console.Write(Lang["enter_choice"]);
                string secim = Console.ReadLine().ToUpper();

                switch (secim)
                {
                    case "1": AdminHesaplariListele(); break;
                    case "2": AdminHesapSil(); break;
                    case "3": AdminBakiyeDuzenle(); break;
                    case "4": AdminLogGor(); break;
                    case "5": AdminHesapOlustur(); break;
                    case "X": devam = false; break;
                }
            }
        }

        // ============================
        // MENÜ FONKSİYONLARI
        // ============================
        static void BakiyeGoster()
        {
            Console.WriteLine(aktifHesap.BakiyeGoster());
        }

        static void ParaYatir()
        {
            Console.Write("Miktar: ");
            decimal miktar = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine(aktifHesap.ParaYatir(miktar));
        }

        static void ParaCek()
        {
            Console.Write("Miktar: ");
            decimal miktar = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine(aktifHesap.ParaCek(miktar));
        }

        static void ParaTransfer()
        {
            Console.Write("Alıcı hesap no: ");
            string aNo = Console.ReadLine();

            Console.Write("Miktar: ");
            decimal miktar = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine(banka.ParaTransfer(aktifHesap.HesapNo, aNo, miktar));
        }

        static void HareketleriGoster()
        {
            Console.WriteLine("\n--- Loglar ---");

            foreach (var log in aktifHesap.Log)
                Console.WriteLine(log);
        }

        // ============================
        // ADMIN FONKSİYONLARI
        // ============================
        static void AdminHesaplariListele()
        {
            foreach (var h in banka.Hesaplar)
                Console.WriteLine(h.BakiyeGoster());
        }

        static void AdminHesapSil()
        {
            Console.Write("Silinecek hesap no: ");
            string no = Console.ReadLine();
            Console.WriteLine(banka.HesapSil(no));
        }

        static void AdminBakiyeDuzenle()
        {
            Console.Write("Hesap no: ");
            string no = Console.ReadLine();

            var h = banka.HesapBul(no);
            if (h == null)
            {
                Console.WriteLine("Hesap bulunamadı.");
                return;
            }

            Console.Write("Yeni bakiye: ");
            h.Bakiye = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Bakiye güncellendi.");
        }

        static void AdminLogGor()
        {
            Console.Write("Hesap no: ");
            string no = Console.ReadLine();

            var h = banka.HesapBul(no);
            if (h == null)
            {
                Console.WriteLine("Hesap bulunamadı.");
                return;
            }

            foreach (var log in h.Log)
                Console.WriteLine(log);
        }

        static void AdminHesapOlustur()
        {
            Console.Write("Yeni hesap no: ");
            string no = Console.ReadLine();

            Console.Write("Sahip: ");
            string sahip = Console.ReadLine();

            Console.Write("Bakiye: ");
            decimal bakiye = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Şifre: ");
            string sifre = Console.ReadLine();

            Console.Write("Hesap türü (Vadesiz/Vadeli): ");
            string tur = Console.ReadLine();

            var h = new Hesap(no, sahip, bakiye, sifre)
            {
                HesapTuru = tur
            };

            banka.HesapEkle(h);
            Console.WriteLine("Hesap oluşturuldu.");
        }
    }
}