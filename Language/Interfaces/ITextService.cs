using Language.Models;

namespace Language.Interfaces;

public interface ITextService
{
    Text CreateText(string languageId, TextInfo textInfo);
    Text GetTextById(string textId);
    List<Text> GetTextsByLanguageId(string languageId);
    Text GetTextByLanguageAndFieldname(string languageId, string fieldname);
    Text UpdateTextById(string textId, TextInfo textInfo);
    bool DeleteTextById(string textId);
}