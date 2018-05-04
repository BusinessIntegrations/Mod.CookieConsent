namespace Mod.CookieConsent.Models {
    public interface ICookieConsentSettingsPart {
        #region Properties
        string Dismiss { get; }
        bool Enabled { get; }
        int ExpiryDays { get; }
        string LearnMore { get; }
        string Link { get; }
        string Message { get; }
        string Path { get; }
        string Target { get; }
        string Theme { get; }
        bool UseCdn { get; }
        #endregion
    }
}
