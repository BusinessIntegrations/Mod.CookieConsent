#region Using
using Mod.CookieConsent.Models;
using Orchard;
#endregion

namespace Mod.CookieConsent.Services {
    public interface ICacheService : IDependency {
        #region Methods
        ICacheModel GetData();
        ICookieConsentSettingsPart GetSettings();
        void ReleaseCache();
        void UpdateSettings(ICookieConsentSettingsPart settings);
        #endregion
    }
}
