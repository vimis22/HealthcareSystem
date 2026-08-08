using Language.Interfaces;
using Language.Models;

namespace DataManager.Services.Language;

public class SettingsService : ISettingsService
{
    private readonly AppDbContext _db;

    public SettingsService(AppDbContext db)
    {
        _db = db;
    }

    public Settings CreateSettings(string languageId, SettingsInfo settingsInfo)
    {
        var settings = new Settings
        {
            Id = Guid.NewGuid().ToString(),
            Dark = settingsInfo.Dark,
            Light = settingsInfo.Light,
            LanguageId = languageId
        };
        _db.Settings.Add(settings);
        _db.SaveChanges();
        return settings;
    }

    public Settings GetSettingsById(string settingsId)
    {
        return _db.Settings.FirstOrDefault(s => s.Id == settingsId);
    }

    public List<Settings> GetSettingsByLanguageId(string languageId)
    {
        return _db.Settings.Where(s => s.LanguageId == languageId).ToList();
    }

    public Settings UpdateSettingsById(string settingsId, SettingsInfo settingsInfo)
    {
        var settings = _db.Settings.FirstOrDefault(s => s.Id == settingsId);
        if (settings == null) return null;
        settings.Dark = settingsInfo.Dark;
        settings.Light = settingsInfo.Light;
        _db.SaveChanges();
        return settings;
    }

    public bool DeleteSettingsById(string settingsId)
    {
        var settings = _db.Settings.FirstOrDefault(s => s.Id == settingsId);
        if (settings == null) return false;
        _db.Settings.Remove(settings);
        _db.SaveChanges();
        return true;
    }
}
