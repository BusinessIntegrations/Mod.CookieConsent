#region Using
using Orchard.ContentManagement;
#endregion

namespace Mod.CookieConsent.Models {
    public class CookieConsentSettingsPart : ContentPart, ICookieConsentSettingsPart {
        #region ICookieConsentSettingsPart Members
        public string Dismiss { get { return this.Retrieve(x => x.Dismiss); } set { this.Store(x => x.Dismiss, value); } }
        public bool Enabled { get { return this.Retrieve(x => x.Enabled); } set { this.Store(x => x.Enabled, value); } }
        public int ExpiryDays { get { return this.Retrieve(x => x.ExpiryDays, 365); } set { this.Store(x => x.ExpiryDays, value); } }
        public string LearnMore { get { return this.Retrieve(x => x.LearnMore); } set { this.Store(x => x.LearnMore, value); } }
        public string Link { get { return this.Retrieve(x => x.Link); } set { this.Store(x => x.Link, value); } }
        public string Message { get { return this.Retrieve(x => x.Message); } set { this.Store(x => x.Message, value); } }
        public string Path { get { return this.Retrieve(x => x.Path); } set { this.Store(x => x.Path, value); } }
        public string Target { get { return this.Retrieve(x => x.Target); } set { this.Store(x => x.Target, value); } }
        public string Theme { get { return this.Retrieve(x => x.Theme); } set { this.Store(x => x.Theme, value); } }
        public bool UseCdn => true;
        #endregion
    }
}
