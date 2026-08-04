using Language.Interfaces;
using Language.Models;

namespace Language.Services;

public class LanguageService : ILanguageService
{
    public Models.Language CreateLanguage(LanguageInfo languageInfo)
    {
        throw new NotImplementedException();
    }

    public Models.Language GetLanguageById(string languageId)
    {
        throw new NotImplementedException();
    }

    public List<Models.Language> GetAllLanguages()
    {
        throw new NotImplementedException();
    }

    public Models.Language UpdateLanguageById(string languageId, LanguageInfo languageInfo)
    {
        throw new NotImplementedException();
    }

    public bool DeleteLanguageById(string languageId)
    {
        throw new NotImplementedException();
    }
}