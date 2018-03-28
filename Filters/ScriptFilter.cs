#region Using
using System.Web.Mvc;
using Mod.CookieConsent.Models;
using Orchard;
using Orchard.Caching;
using Orchard.ContentManagement;
using Orchard.Mvc.Filters;
using Orchard.UI.Admin;
#endregion

namespace Mod.CookieConsent.Filters {
    public class ScriptFilter : FilterProvider, IResultFilter {
        private readonly ICacheManager _cacheManager;
        private readonly ISignals _signals;
        private readonly IWorkContextAccessor _wca;

        public ScriptFilter(ICacheManager cacheManager, ISignals signals, IWorkContextAccessor wca) {
            _cacheManager = cacheManager;
            _signals = signals;
            _wca = wca;
        }

        #region IResultFilter Members
        public void OnResultExecuted(ResultExecutedContext filterContext) { }

        public void OnResultExecuting(ResultExecutingContext filterContext) {
            if (AdminFilter.IsApplied(filterContext.RequestContext)) {
                return;
            }

            // should only run on a full view rendering result
            if (!(filterContext.Result is ViewResult)) {
                return;
            }
            var script = _cacheManager.Get(Constants.ModCookieConsentCacheKey,
                ctx => {
                    ctx.Monitor(_signals.When(Constants.ModCookieConsentChanged));
                    var settings = _wca.GetContext()
                        .CurrentSite.As<CookieConsentSettingsPart>();
                    return settings.BuildScript();
                });
            if (string.IsNullOrEmpty(script)) {
                return;
            }
            var context = _wca.GetContext();
            var tail = context.Layout.Tail;
            tail.Add(new MvcHtmlString(script));
        }
        #endregion
    }
}
