using Language.Interfaces;
using Language.Models;

namespace Language.Services;

public class SettingsService : ISettingsService
{
    public Settings CreateSettings(string languageId, SettingsInfo settingsInfo)
    {
        throw new NotImplementedException();
    }

    public Settings GetSettingsById(string settingsId)
    {
        throw new NotImplementedException();
    }

    public List<Settings> GetSettingsByLanguageId(string languageId)
    {
        throw new NotImplementedException();
    }

    public Settings UpdateSettingsById(string settingsId, SettingsInfo settingsInfo)
    {
        throw new NotImplementedException();
    }

    public bool DeleteSettingsById(string settingsId)
    {
        throw new NotImplementedException();
    }
}