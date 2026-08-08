using HealthCard.Interfaces;
using HealthCard.Models;

namespace DataManager.Services.HealthCard;

public class HealthCardService : IHealthCardService
{
    private readonly AppDbContext _db;

    public HealthCardService(AppDbContext db)
    {
        _db = db;
    }

    public global::HealthCard.Models.HealthCard CreateHealthCard(string clientId, string clinicId, HealthCardInfo healthCardInfo)
    {
        var card = new global::HealthCard.Models.HealthCard
        {
            Id = Guid.NewGuid().ToString(),
            Cpr = healthCardInfo.Cpr,
            Sikringsgruppe = healthCardInfo.Sikringsgruppe,
            ValidFrom = healthCardInfo.ValidFrom,
            ClientId = clientId,
            ClinicId = clinicId
        };
        _db.HealthCards.Add(card);
        _db.SaveChanges();
        return card;
    }

    public global::HealthCard.Models.HealthCard GetHealthCardById(string healthCardId)
    {
        return _db.HealthCards.FirstOrDefault(h => h.Id == healthCardId);
    }

    public global::HealthCard.Models.HealthCard GetHealthCardByClientId(string clientId)
    {
        return _db.HealthCards.FirstOrDefault(h => h.ClientId == clientId);
    }

    public global::HealthCard.Models.HealthCard GetHealthCardByCpr(string cpr)
    {
        return _db.HealthCards.FirstOrDefault(h => h.Cpr == cpr);
    }

    public global::HealthCard.Models.HealthCard UpdateHealthCardById(string healthCardId, HealthCardInfo healthCardInfo)
    {
        var card = _db.HealthCards.FirstOrDefault(h => h.Id == healthCardId);
        if (card == null) return null;
        card.Cpr = healthCardInfo.Cpr;
        card.Sikringsgruppe = healthCardInfo.Sikringsgruppe;
        card.ValidFrom = healthCardInfo.ValidFrom;
        _db.SaveChanges();
        return card;
    }

    public bool DeleteHealthCardById(string healthCardId)
    {
        var card = _db.HealthCards.FirstOrDefault(h => h.Id == healthCardId);
        if (card == null) return false;
        _db.HealthCards.Remove(card);
        _db.SaveChanges();
        return true;
    }
}
