using System.Collections.Generic;

namespace GameWideSystems.LocalizationWrapper
{
    public class LocalizationManager : ILocalizationManager
    {
        public bool TryGetLocalized(string key, TranslationCategory category, out string localizedLine)
        {
            return I2.Loc.LocalizationManager.TryGetTranslation($"{category}/{key}", out localizedLine);
        }

        public bool TryGetLocalized(string key, TranslationCategory category, out string localizedLine, Dictionary<string, string> replacements)
        {
            return I2.Loc.LocalizationManager.TryGetTranslation($"{category}/{key}", replacements, out localizedLine);
        }
    }
}
