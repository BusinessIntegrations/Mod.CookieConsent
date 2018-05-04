#region Using
using Mod.CookieConsent.Models;
using Orchard;
using Orchard.Caching;
using Orchard.ContentManagement;
#endregion

namespace Mod.CookieConsent.Services {
    public class CacheService : ICacheService {
        private readonly ICacheManager _cacheManager;
        private readonly IOrchardServices _orchardServices;
        private readonly ISignals _signals;

        public CacheService(ICacheManager cacheManager, IOrchardServices orchardServices, ISignals signals) {
            _cacheManager = cacheManager;
            _orchardServices = orchardServices;
            _signals = signals;
        }

        #region ICacheService Members
        public ICacheModel GetData() {
            return _cacheManager.Get(Constants.CacheKey,
                context => {
                    context.Monitor(_signals.When(Constants.CacheTrigger));
                    var part = GetSettingsPart();
                    return new CacheModel(part);
                });
        }

        public ICookieConsentSettingsPart GetSettings() {
            return GetSettingsPart();
        }

        public void ReleaseCache() {
            _signals.Trigger(Constants.CacheTrigger);
        }

        public void UpdateSettings(ICookieConsentSettingsPart settings) {
            var part = GetSettingsPart();
            part.Theme = settings.Theme;
            part.Dismiss = settings.Dismiss;
            part.Enabled = settings.Enabled;
            part.ExpiryDays = settings.ExpiryDays;
            part.LearnMore = settings.LearnMore;
            part.Link = settings.Link;
            part.Message = settings.Message;
            part.Path = settings.Path;
            part.Target = settings.Target;
            ReleaseCache();
        }
        #endregion

        #region Methods
        private CookieConsentSettingsPart GetSettingsPart() {
            return _orchardServices.WorkContext.CurrentSite.As<CookieConsentSettingsPart>();
        }
        #endregion
    }
}
