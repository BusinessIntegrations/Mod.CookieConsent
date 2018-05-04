#region Using
using System.Text;
using Mod.CookieConsent.Models;
#endregion

namespace Mod.CookieConsent.Services {
    public class CacheModel : ICacheModel {
        public CacheModel(ICookieConsentSettingsPart part) {
            Script = BuildScript(part);
        }

        #region ICacheModel Members
        public string Script { get; }
        #endregion

        #region Methods
        public string BuildScript(ICookieConsentSettingsPart part) {
            if (!part.Enabled) {
                return null;
            }

            var sb = new StringBuilder();
            sb.Append("<script type=\"text/javascript\">window.cookieconsent_options = {");
            sb.Append(AppendString("message", part.Message));
            sb.Append(AppendString("dismiss", part.Dismiss));
            sb.Append(AppendString("learnMore", part.LearnMore));
            sb.Append(AppendString("link", part.Link));
            sb.Append(AppendString("theme", part.Theme));
            sb.Append(AppendString("path", part.Path));
            sb.Append(AppendString("expiryDays", part.ExpiryDays.ToString()));
            sb.Append(AppendString("target", part.Target));
            sb.Append("}</script>");
            if (part.UseCdn) {
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
