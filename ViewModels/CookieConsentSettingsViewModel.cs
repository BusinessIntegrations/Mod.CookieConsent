#region Using
using Mod.CookieConsent.Models;
#endregion

namespace Mod.CookieConsent.ViewModels {
    public class CookieConsentSettingsViewModel : ICookieConsentSettingsPart {
        #region ICookieConsentSettingsPart Members
        public string Dismiss { get; set; }
        public bool Enabled { get; set; }
        public int ExpiryDays { get; set; }
        public string LearnMore { get; set; }
        public string Link { get; set; }
        public string Message { get; set; }
        public string Path { get; set; }
        public string Target { get; set; }
        public string Theme { get; set; }
        public bool UseCdn { get; set; }
        #endregion
    }
}
