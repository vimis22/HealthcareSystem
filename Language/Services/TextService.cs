using Language.Interfaces;
using Language.Models;

namespace Language.Services;

public class TextService : ITextService
{
    public Text CreateText(string languageId, TextInfo textInfo)
    {
        throw new NotImplementedException();
    }

    public Text GetTextById(string textId)
    {
        throw new NotImplementedException();
    }

    public List<Text> GetTextsByLanguageId(string languageId)
    {
        throw new NotImplementedException();
    }

    public Text GetTextByLanguageAndFieldname(string languageId, string fieldname)
    {
        throw new NotImplementedException();
    }

    public Text UpdateTextById(string textId, TextInfo textInfo)
    {
        throw new NotImplementedException();
    }

    public bool DeleteTextById(string textId)
    {
        throw new NotImplementedException();
    }
}