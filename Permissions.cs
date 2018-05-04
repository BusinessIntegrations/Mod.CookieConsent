#region Using
using System.Collections.Generic;
using Orchard.Environment.Extensions.Models;
using Orchard.Security.Permissions;
#endregion

namespace Mod.CookieConsent {
    public class Permissions : IPermissionProvider {
        public static readonly Permission ManageCookieConsent = new Permission {
            Description = "Managing Cookie Consent Settings",
            Name = nameof(ManageCookieConsent)
        };

        private static readonly Permission[] permissions = {ManageCookieConsent};

        #region IPermissionProvider Members
        public IEnumerable<PermissionStereotype> GetDefaultStereotypes() {
            return new[] {
                new PermissionStereotype {
                    Name = "Administrator",
                    Permissions = permissions
                }
            };
        }

        public IEnumerable<Permission> GetPermissions() {
            return permissions;
        }

        public virtual Feature Feature { get; set; }
        #endregion
    }
}
