using Language.Interfaces;
using Language.Models;

namespace DataManager.Services.Language;

public class TextService : ITextService
{
    private readonly AppDbContext _db;

    public TextService(AppDbContext db)
    {
        _db = db;
    }

    public Text CreateText(string languageId, TextInfo textInfo)
    {
        var text = new Text
        {
            Id = Guid.NewGuid().ToString(),
            Fieldname = textInfo.Fieldname,
            Textvalue = textInfo.Textvalue,
            LanguageId = languageId
        };
        _db.Texts.Add(text);
        _db.SaveChanges();
        return text;
    }

    public Text GetTextById(string textId)
    {
        return _db.Texts.FirstOrDefault(t => t.Id == textId);
    }

    public List<Text> GetTextsByLanguageId(string languageId)
    {
        return _db.Texts.Where(t => t.LanguageId == languageId).ToList();
    }

    public Text GetTextByLanguageAndFieldname(string languageId, string fieldname)
    {
        return _db.Texts.FirstOrDefault(t => t.LanguageId == languageId && t.Fieldname == fieldname);
    }

    public Text UpdateTextById(string textId, TextInfo textInfo)
    {
        var text = _db.Texts.FirstOrDefault(t => t.Id == textId);
        if (text == null) return null;
        text.Fieldname = textInfo.Fieldname;
        text.Textvalue = textInfo.Textvalue;
        _db.SaveChanges();
        return text;
    }

    public bool DeleteTextById(string textId)
    {
        var text = _db.Texts.FirstOrDefault(t => t.Id == textId);
        if (text == null) return false;
        _db.Texts.Remove(text);
        _db.SaveChanges();
        return true;
    }
}
