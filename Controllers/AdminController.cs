#region Using
using System.Web.Mvc;
using Mod.CookieConsent.Models;
using Mod.CookieConsent.Services;
using Mod.CookieConsent.ViewModels;
using Orchard;
using Orchard.Localization;
using Orchard.Themes;
using Orchard.UI.Admin;
using Orchard.UI.Notify;
#endregion

namespace Mod.CookieConsent.Controllers {
    [Themed]
    [Admin]
    public class AdminController : Controller {
        private readonly ICacheService _cacheService;
        private readonly IOrchardServices _orchardServices;

        public AdminController(IOrchardServices orchardServices, ICacheService cacheService) {
            _orchardServices = orchardServices;
            _cacheService = cacheService;
            T = NullLocalizer.Instance;
        }

        #region Properties
        public Localizer T { get; set; }
        #endregion

        #region Methods
        public ActionResult Index() {
            if (!_orchardServices.Authorizer.Authorize(Permissions.ManageCookieConsent, T(Constants.CannotManageText))) {
                return new HttpUnauthorizedResult();
            }

            var viewModel = GetViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult IndexPost(CookieConsentSettingsViewModel viewModel) {
            if (!_orchardServices.Authorizer.Authorize(Permissions.ManageCookieConsent, T(Constants.CannotManageText))) {
                return new HttpUnauthorizedResult();
            }

            if (ModelState.IsValid) {
                if (TryUpdateModel(viewModel)) {
                    UpdateData(viewModel);
                    _orchardServices.Notifier.Information(T("Cookie Consent settings saved successfully."));
                    _orchardServices.Notifier.Information(T("Remember if you are using the Output Cache that you need to clear it."));
                }
                else {
                    _orchardServices.Notifier.Information(T("Could not save Cookie Consent settings."));
                }
            }
            else {
                _orchardServices.Notifier.Error(T(Constants.ValidationErrorText));
                return View(viewModel);
            }

            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        ///     Retrieves cached data and converts to viewmodel
        /// </summary>
        /// <returns></returns>
        private CookieConsentSettingsViewModel GetViewModel() {
            var cacheModel = _cacheService.GetSettings();
            return new CookieConsentSettingsViewModel {
                Theme = cacheModel.Theme,
                Dismiss = cacheModel.Dismiss,
                LearnMore = cacheModel.LearnMore,
                Link = cacheModel.Link,
                Message = cacheModel.Message,
                Path = cacheModel.Path,
                Target = cacheModel.Target,
                Enabled = cacheModel.Enabled,
                ExpiryDays = cacheModel.ExpiryDays,
                UseCdn = cacheModel.UseCdn
            };
        }

        private void UpdateData(ICookieConsentSettingsPart model) {
            _cacheService.UpdateSettings(model);
        }
        #endregion
    }
}
