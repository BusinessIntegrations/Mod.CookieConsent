#region Using
using System.Text;
using Orchard.ContentManagement;
#endregion

namespace Mod.CookieConsent.Models {
    public class CookieConsentSettingsPart : ContentPart {
        #region Properties
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

        #region Methods
        public string BuildScript() {
            if (!Enabled) {
                return null;
            }
            var sb = new StringBuilder();
            sb.Append("<script type=\"text/javascript\">window.cookieconsent_options = {");
            sb.Append(AppendString("message", Message));
            sb.Append(AppendString("dismiss", Dismiss));
            sb.Append(AppendString("learnMore", LearnMore));
            sb.Append(AppendString("link", Link));
            sb.Append(AppendString("theme", Theme));
            sb.Append(AppendString("path", Path));
            sb.Append($"expiryDays: {ExpiryDays},");
            sb.Append(AppendString("target", Target));
            sb.Append("}</script>");
            if (UseCdn) {
                sb.Append(
                    "<script type=\"text/javascript\" src=\"//cdnjs.cloudflare.com/ajax/libs/cookieconsent2/1.0.10/cookieconsent.min.js\"></script>");
            }
            return sb.ToString();
        }

        private static string AppendString(string property, string val) {
            return !string.IsNullOrWhiteSpace(val)
                ? $"{property}: '{val}',"
                : "";
        }
        #endregion
    }
}
