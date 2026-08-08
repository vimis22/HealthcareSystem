using Language.Interfaces;
using Language.Models;

namespace DataManager.Services.Language;

public class LanguageService : ILanguageService
{
    private readonly AppDbContext _db;

    public LanguageService(AppDbContext db)
    {
        _db = db;
    }

    public global::Language.Models.Language CreateLanguage(LanguageInfo languageInfo)
    {
        var language = new global::Language.Models.Language { Id = Guid.NewGuid().ToString() };
        _db.Languages.Add(language);
        _db.SaveChanges();
        return language;
    }

    public global::Language.Models.Language GetLanguageById(string languageId)
    {
        return _db.Languages.FirstOrDefault(l => l.Id == languageId);
    }

    public List<global::Language.Models.Language> GetAllLanguages()
    {
        return _db.Languages.ToList();
    }

    public global::Language.Models.Language UpdateLanguageById(string languageId, LanguageInfo languageInfo)
    {
        var language = _db.Languages.FirstOrDefault(l => l.Id == languageId);
        if (language == null) return null;
        _db.SaveChanges();
        return language;
    }

    public bool DeleteLanguageById(string languageId)
    {
        var language = _db.Languages.FirstOrDefault(l => l.Id == languageId);
        if (language == null) return false;
        _db.Languages.Remove(language);
        _db.SaveChanges();
        return true;
    }
}
