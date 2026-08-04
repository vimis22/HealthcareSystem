using Language.Models;

namespace Language.Interfaces;

public interface ISettingsService
{
    Settings CreateSettings(string languageId, SettingsInfo settingsInfo);
    Settings GetSettingsById(string settingsId);
    List<Settings> GetSettingsByLanguageId(string languageId);
    Settings UpdateSettingsById(string settingsId, SettingsInfo settingsInfo);
    bool DeleteSettingsById(string settingsId);
} 