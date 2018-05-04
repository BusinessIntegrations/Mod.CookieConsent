#region Using
using Mod.CookieConsent.Models;
using Orchard.ContentManagement.Handlers;
#endregion

namespace Mod.CookieConsent.Handlers {
    public class CookieConsentSettingsPartHandler : ContentHandler {
        public CookieConsentSettingsPartHandler() {
            Filters.Add(new ActivatingFilter<CookieConsentSettingsPart>(Constants.SiteContentTypeName));
        }
    }
}
