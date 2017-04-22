using System;
using System.Text;
using Orchard.ContentManagement;

namespace Mod.CookieConsent.Models
{
    public class CookieConsentSettingsPart : ContentPart {
        public string Message {
            get { return this.Retrieve(x => x.Message); }
            set { this.Store(x => x.Message, value); }
        }

        public string Dismiss {
            get { return this.Retrieve(x => x.Dismiss); }
            set { this.Store(x => x.Dismiss, value); }
        }

        public string LearnMore {
            get { return this.Retrieve(x => x.LearnMore); }
            set { this.Store(x => x.LearnMore, value); }
        }

        public string Link {
            get { return this.Retrieve(x => x.Link); }
            set { this.Store(x => x.Link, value); }
        }

        public string Theme {
            get { return this.Retrieve(x => x.Theme); }
            set { this.Store(x => x.Theme, value); }
        }

        public string Path {
            get { return this.Retrieve(x => x.Path); }
            set { this.Store(x => x.Path, value); }
        }

        public int ExpiryDays {
            get { return this.Retrieve(x => x.ExpiryDays, 365); }
            set { this.Store(x => x.ExpiryDays, value); }
        }

        public string Target {
            get { return this.Retrieve(x => x.Target); }
            set { this.Store(x => x.Target, value); }
        }

        public bool UseCdn {
            get { return true; } // add property here at some point to either use local or cdn value
        }

        public string BuildScript() {
            var sb = new StringBuilder();
            sb.Append("<script type=\"text/javascript\">window.cookieconsent_options = {");
            sb.Append(AppendString("message", Message));
            sb.Append(AppendString("dismiss", Dismiss));
            sb.Append(AppendString("learnMore", LearnMore));
            sb.Append(AppendString("link", Link));
            sb.Append(AppendString("theme", Theme));
            sb.Append(AppendString("path", Path));
            sb.Append(String.Format("expiryDays: {0},", ExpiryDays));
            sb.Append(AppendString("target", Target));
            sb.Append("}</script>");
            if(UseCdn)
                sb.Append("<script type=\"text/javascript\" src=\"//cdnjs.cloudflare.com/ajax/libs/cookieconsent2/1.0.10/cookieconsent.min.js\"></script>");

            return sb.ToString();
        }

        private string AppendString(string property, string val) {
            if (!String.IsNullOrWhiteSpace(val)) return String.Format("{0}: '{1}',", property, val);
            return "";            
        }
    }
}