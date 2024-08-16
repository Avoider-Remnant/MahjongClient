using System.Collections.Generic;

namespace GameWideSystems.LocalizationWrapper
{
    public interface ILocalizationManager
    {
        public bool TryGetLocalized(string key, TranslationCategory category, out string localizedLine);
        public bool TryGetLocalized(string key, TranslationCategory category, out string localizedLine, Dictionary<string, string> replacements);
    }
}