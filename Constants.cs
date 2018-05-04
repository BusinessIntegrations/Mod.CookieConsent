#region Using
using Mod.CookieConsent.Controllers;
#endregion

namespace Mod.CookieConsent {
    public static class Constants {
        public const string AdminControllerName = "Admin";
        public const string AdminMenuName = "Cookie Consent";
        public const string AreaName = "Mod.CookieConsent";
        public const string BiMenuSection = "bi-menu-section";
        public const string CacheKey = "Mod.CookieConsent.Script";
        public const string CacheTrigger = "Mod.CookieConsent.Changed";
        public const string CannotManageText = "Can't manage Cookie Consent Settings";
        public const string IndexActionName = nameof(AdminController.Index);
        public const string SiteContentTypeName = "Site";
        public const string SiteSettings = "SiteSettings";
        public const string ValidationErrorText = "Validation error";
    }
}
