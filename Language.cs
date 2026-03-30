using System.Collections.Generic;

namespace ATMUygulamasi
{
    internal static class Language
    {
        // ============================
        // TÜRKÇE
        // ============================
        public static Dictionary<string, string> TR = new Dictionary<string, string>()
        {
            ["welcome"] = "ATM Uygulamasına Hoş Geldiniz!",
            ["login_type_title"] = "--- Giriş Türü Seçin ---",
            ["login_user"] = "1 - Kullanıcı Girişi",
            ["login_admin"] = "2 - Admin Girişi",
            ["login_exit"] = "X - Programdan Çık",
            ["enter_choice"] = "Seçiminiz: ",
            ["enter_account"] = "Hesap No: ",
            ["enter_password"] = "Şifre: ",
            ["login_failed"] = "Hatalı hesap numarası veya şifre.",
            ["login_try_left"] = "Kalan deneme hakkı: ",
            ["login_blocked"] = "3 kez hatalı giriş yaptınız. Ana menüye dönülüyor.",
            ["admin_title"] = "--- Admin Girişi ---",
            ["admin_user"] = "Kullanıcı adı: ",
            ["admin_pass"] = "Şifre: ",
            ["admin_failed"] = "Admin bilgileri hatalı.",
            ["admin_success"] = "Admin girişi başarılı.",
            ["menu_title"] = "ATM UYGULAMASI",
            ["menu_balance"] = "1 - Bakiye Görüntüle",
            ["menu_deposit"] = "2 - Para Yatır",
            ["menu_withdraw"] = "3 - Para Çek",
            ["menu_transfer"] = "4 - Para Transferi",
            ["menu_logs"] = "5 - Hesap Hareketleri",
            ["menu_switch"] = "6 - Hesap Değiştir",
            ["menu_exit_user"] = "X - Ana Menüye Dön",
            ["admin_menu_title"] = "========== ADMIN PANEL ==========",
            ["admin_menu_list"] = "1 - Tüm Hesapları Listele",
            ["admin_menu_delete"] = "2 - Hesap Sil",
            ["admin_menu_edit_balance"] = "3 - Hesap Bakiyesini Düzenle",
            ["admin_menu_logs"] = "4 - Hesap Loglarını Görüntüle",
            ["admin_menu_create"] = "5 - Yeni Hesap Oluştur",
            ["admin_menu_exit"] = "X - Ana Menüye Dön",
            ["lang_select_title"] = "Dil Seçiniz / Select Language / Sprache wählen:",
            ["lang_tr"] = "1 - Türkçe",
            ["lang_en"] = "2 - English",
            ["lang_de"] = "3 - Deutsch",
            ["lang_choice"] = "Seçim: "
        };

        // ============================
        // ENGLISH
        // ============================
        public static Dictionary<string, string> EN = new Dictionary<string, string>()
        {
            ["welcome"] = "Welcome to the ATM System!",
            ["login_type_title"] = "--- Select Login Type ---",
            ["login_user"] = "1 - User Login",
            ["login_admin"] = "2 - Admin Login",
            ["login_exit"] = "X - Exit Program",
            ["enter_choice"] = "Your choice: ",
            ["enter_account"] = "Account Number: ",
            ["enter_password"] = "Password: ",
            ["login_failed"] = "Invalid account number or password.",
            ["login_try_left"] = "Remaining attempts: ",
            ["login_blocked"] = "3 failed attempts. Returning to main menu.",
            ["admin_title"] = "--- Admin Login ---",
            ["admin_user"] = "Username: ",
            ["admin_pass"] = "Password: ",
            ["admin_failed"] = "Admin credentials are incorrect.",
            ["admin_success"] = "Admin login successful.",
            ["menu_title"] = "ATM SYSTEM",
            ["menu_balance"] = "1 - View Balance",
            ["menu_deposit"] = "2 - Deposit Money",
            ["menu_withdraw"] = "3 - Withdraw Money",
            ["menu_transfer"] = "4 - Transfer Money",
            ["menu_logs"] = "5 - Transaction History",
            ["menu_switch"] = "6 - Switch Account",
            ["menu_exit_user"] = "X - Back to Main Menu",
            ["admin_menu_title"] = "========== ADMIN PANEL ==========",
            ["admin_menu_list"] = "1 - List All Accounts",
            ["admin_menu_delete"] = "2 - Delete Account",
            ["admin_menu_edit_balance"] = "3 - Edit Account Balance",
            ["admin_menu_logs"] = "4 - View Account Logs",
            ["admin_menu_create"] = "5 - Create New Account",
            ["admin_menu_exit"] = "X - Back to Main Menu",
            ["lang_select_title"] = "Select Language / Dil Seçiniz / Sprache wählen:",
            ["lang_tr"] = "1 - Turkish",
            ["lang_en"] = "2 - English",
            ["lang_de"] = "3 - German",
            ["lang_choice"] = "Choice: "
        };

        // ============================
        // DEUTSCH
        // ============================
        public static Dictionary<string, string> DE = new Dictionary<string, string>()
        {
            ["welcome"] = "Willkommen beim ATM-System!",
            ["login_type_title"] = "--- Anmeldetyp wählen ---",
            ["login_user"] = "1 - Benutzeranmeldung",
            ["login_admin"] = "2 - Admin-Anmeldung",
            ["login_exit"] = "X - Programm beenden",
            ["enter_choice"] = "Ihre Auswahl: ",
            ["enter_account"] = "Kontonummer: ",
            ["enter_password"] = "Passwort: ",
            ["login_failed"] = "Ungültige Kontonummer oder Passwort.",
            ["login_try_left"] = "Verbleibende Versuche: ",
            ["login_blocked"] = "3 Fehlversuche. Zurück zum Hauptmenü.",
            ["admin_title"] = "--- Admin-Anmeldung ---",
            ["admin_user"] = "Benutzername: ",
            ["admin_pass"] = "Passwort: ",
            ["admin_failed"] = "Admin-Daten sind falsch.",
            ["admin_success"] = "Admin-Anmeldung erfolgreich.",
            ["menu_title"] = "ATM SYSTEM",
            ["menu_balance"] = "1 - Kontostand anzeigen",
            ["menu_deposit"] = "2 - Geld einzahlen",
            ["menu_withdraw"] = "3 - Geld abheben",
            ["menu_transfer"] = "4 - Geld überweisen",
            ["menu_logs"] = "5 - Transaktionsverlauf",
            ["menu_switch"] = "6 - Konto wechseln",
            ["menu_exit_user"] = "X - Zum Hauptmenü",
            ["admin_menu_title"] = "========== ADMIN PANEL ==========",
            ["admin_menu_list"] = "1 - Alle Konten anzeigen",
            ["admin_menu_delete"] = "2 - Konto löschen",
            ["admin_menu_edit_balance"] = "3 - Kontostand bearbeiten",
            ["admin_menu_logs"] = "4 - Kontologs anzeigen",
            ["admin_menu_create"] = "5 - Neues Konto erstellen",
            ["admin_menu_exit"] = "X - Zum Hauptmenü",
            ["lang_select_title"] = "Sprache wählen / Select Language / Dil Seçiniz:",
            ["lang_tr"] = "1 - Türkisch",
            ["lang_en"] = "2 - Englisch",
            ["lang_de"] = "3 - Deutsch",
            ["lang_choice"] = "Auswahl: "
        };
    }
}