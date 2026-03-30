namespace ATMUygulamasi
{
    internal class UserSettings
    {
        // Kullanıcının seçtiği dil (TR / EN / DE)
        public string Dil { get; set; } = "TR";

        // Tema (light / dark / colorful)
        public string Tema { get; set; } = "dark";

        // Günlük para çekme limiti
        public decimal GunlukLimit { get; set; } = 5000;

        // Ses açık mı?
        public bool SesAcik { get; set; } = true;
    }
}