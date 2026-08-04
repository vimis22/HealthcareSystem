using Language.Models;

namespace Language.Interfaces;

public interface ILanguageService
{
    Models.Language CreateLanguage(LanguageInfo languageInfo);
    Models.Language GetLanguageById(string languageId);
    List<Models.Language> GetAllLanguages();
    Models.Language UpdateLanguageById(string languageId, LanguageInfo languageInfo);
    bool DeleteLanguageById(string languageId);
    
}