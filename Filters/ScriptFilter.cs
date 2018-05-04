#region Using
using System.Web.Mvc;
using Mod.CookieConsent.Services;
using Orchard;
using Orchard.Mvc.Filters;
using Orchard.UI.Admin;
#endregion

namespace Mod.CookieConsent.Filters {
    public class ScriptFilter : FilterProvider, IResultFilter {
        private readonly ICacheService _cacheService;
        private readonly IWorkContextAccessor _wca;

        public ScriptFilter(ICacheService cacheService, IWorkContextAccessor wca) {
            _cacheService = cacheService;
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

            var cacheModel = _cacheService.GetData();
            if (string.IsNullOrEmpty(cacheModel.Script)) {
                return;
            }

            var context = _wca.GetContext();
            var tail = context.Layout.Tail;
            tail.Add(new MvcHtmlString(cacheModel.Script));
        }
        #endregion
    }
}
