﻿using System;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Mod.CookieConsent.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Caching;

// This code was generated by Orchardizer

namespace Mod.CookieConsent.Drivers {
    public class CookieConsentSettingsPartDriver : ContentPartDriver<CookieConsentSettingsPart> {
        private readonly ISignals _signals;

        public CookieConsentSettingsPartDriver(ISignals signals) {
            _signals = signals;
        }

        protected override string Prefix {
            get { return "CookieConsentSettingsPart"; }
        }


        protected override DriverResult Editor(CookieConsentSettingsPart part, dynamic shapeHelper) {
            return ContentShape("Parts_CookieConsentSettingsPart_Edit",
                () => shapeHelper.EditorTemplate(
                        TemplateName: "Parts/CookieConsentSettingsPart",
                        Model: part,
                        Prefix: Prefix))
                    .OnGroup("Cookie Consent");
        }

        protected override DriverResult Editor(CookieConsentSettingsPart part, IUpdateModel updater, dynamic shapeHelper) {
            if (updater.TryUpdateModel(part, Prefix, null, null)) {
                _signals.Trigger("Mod.CookieConsent.Changed");
            }
            return Editor(part, shapeHelper);
        }

        protected override void Importing(CookieConsentSettingsPart part, ImportContentContext context) {
            var partName = part.PartDefinition.Name;
            var _Message = context.Attribute(partName, "Message");
            if (_Message != null) {
                part.Message = _Message;
            }
            var _Dismiss = context.Attribute(partName, "Dismiss");
            if (_Dismiss != null) {
                part.Dismiss = _Dismiss;
            }
            var _LearnMore = context.Attribute(partName, "LearnMore");
            if (_LearnMore != null) {
                part.LearnMore = _LearnMore;
            }
            var _Link = context.Attribute(partName, "Link");
            if (_Link != null) {
                part.Link = _Link;
            }
            var _Theme = context.Attribute(partName, "Theme");
            if (_Theme != null) {
                part.Theme = _Theme;
            }
            var _Path = context.Attribute(partName, "Path");
            if (_Path != null) {
                part.Path = _Path;
            }
            var _ExpiryDate = context.Attribute(partName, "ExpiryDate");
            if (_ExpiryDate != null) {
                part.ExpiryDays = Convert.ToInt32(_ExpiryDate);
            }
            var _Target = context.Attribute(partName, "Target");
            if (_Target != null) {
                part.Target = _Target;
            }
        }

        protected override void Exporting(CookieConsentSettingsPart part, ExportContentContext context) {
            context.Element(part.PartDefinition.Name).SetAttributeValue("Message", part.Message);
            context.Element(part.PartDefinition.Name).SetAttributeValue("Dismiss", part.Dismiss);
            context.Element(part.PartDefinition.Name).SetAttributeValue("LearnMore", part.LearnMore);
            context.Element(part.PartDefinition.Name).SetAttributeValue("Link", part.Link);
            context.Element(part.PartDefinition.Name).SetAttributeValue("Theme", part.Theme);
            context.Element(part.PartDefinition.Name).SetAttributeValue("Path", part.Path);
            context.Element(part.PartDefinition.Name).SetAttributeValue("ExpiryDate", part.ExpiryDays);
            context.Element(part.PartDefinition.Name).SetAttributeValue("Target", part.Target);
        }
    }
}